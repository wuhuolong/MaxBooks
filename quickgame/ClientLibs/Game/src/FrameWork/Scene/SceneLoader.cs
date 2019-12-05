using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;
using Net;
using SGameEngine;
using Utils;
using System;

public class SceneLoader : MonoBehaviour
{
    protected AsyncOperation m_LoadingAsyncOp;

    protected float mTipUpdateTimeInteval = 30.0f;
    protected float mTipUpdateTime = 0;
    protected List<string> mTips = new List<string>();
    protected bool mIsInPatch = false;

    // Use this for initialization
    protected void Awake()
    {
        Game.GetInstance().SetLoadAsyncOp(null);

        mTipUpdateTime = 0;

        mTips.Clear();
        foreach (Dictionary<string, string> row in DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "tips")) {
            foreach (string tips in row.Values) {
                mTips.Add(tips);
            }
        }
        //SetRandomTip();
    }

    protected void Start ()
    {
        Load();
    }

    protected void SetRandomTip()
    {
        if (mTips != null && mTips.Count > 0) {
            int max = mTips.Count - 1;
            int rand = xc.Maths.Random_.Range(0, max);
            string tip = mTips[rand];
            xc.ui.ugui.UIManager.GetInstance().SetLoadingTip(tip);
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        if (mIsInPatch) {
            return;
        }

        if (mTips != null && mTips.Count > 0) {
            mTipUpdateTime += Time.deltaTime;
            if (mTipUpdateTime >= mTipUpdateTimeInteval) {
                mTipUpdateTime = 0;

                //SetRandomTip();
            }
        }

        m_LoadingAsyncOp = ResourceLoader.Instance.sceneLoadAsyncOp;

        if (m_LoadingAsyncOp != null) {
            double progress = m_LoadingAsyncOp.progress;

            if (m_LoadingAsyncOp.isDone) {
                progress = 1.0f;
            }

            var mapInfo = SceneHelp.Instance.MapInfo;
            if (mapInfo != null && mapInfo.IsDynamic == true)
            {
                xc.ui.ugui.UIManager.GetInstance().UpdateLoadingBar((1f - QuadTreeSceneManager.Instance.StartLoadPercentage) * progress);
            }
            else
            {
                xc.ui.ugui.UIManager.GetInstance().UpdateLoadingBar(progress);
            }
        }
    }

    void OnDestroy()
    {
        var mapInfo = SceneHelp.Instance.MapInfo;
        if (mapInfo != null && mapInfo.IsDynamic == true)
        {
            xc.ui.ugui.UIManager.GetInstance().UpdateLoadingBar((1f - QuadTreeSceneManager.Instance.StartLoadPercentage));
        }
        else
        {
            xc.ui.ugui.UIManager.GetInstance().UpdateLoadingBar(1.0f);
        }
    }

    public void Load()
    {
        if (xc.MainGame.GetGlobalMono() == null) {
            return;
        }

        xc.MainGame.GetGlobalMono().StartCoroutine(LoadScene());
    }

    protected IEnumerator LoadScene()
    {
        string asset_path = SceneHelp.Instance.CurSceneResPath;
        string level_name = SceneHelp.Instance.CurSceneName;

        int patch_id;
        if (!xpatch.XPatchManager.Instance.IsAssetDownloaded(asset_path, out patch_id)) {
            // 由于loading界面层级太高，无法用正常界面来显示，所以在Loading界面内嵌了一个简单的messageBox
            var message_box = xc.ui.ugui.UIManager.Instance.LoadingWindow.MessageBox;

            yield return xc.MainGame.GetGlobalMono().StartCoroutine(
                message_box.ShowRoutine(DBConstText.GetText("SCENE_NEED_DOWNLOAD"), xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel));

            if (message_box.Result == MessageBoxUI.EResult.Cancel) {
                Application.Quit();

                yield break;
            }

            var patch_mgr = xpatch.XPatchManager.Instance;
            var need_download_patch_list = new List<xpatch.DL_PatchContext>();
            for (var i = 1; i <= patch_id; ++i) {
                if (!patch_mgr.IsPatchDownloaded(i)) {
                    var patch = patch_mgr.GetExtendPatchProgress(i);
                    if (patch.PatchContext != null) {
                        need_download_patch_list.Add(patch.PatchContext);
                    }
                }
            }

            var progress = patch_mgr.CreatePatchProcess();
            yield return xc.MainGame.GetGlobalMono().StartCoroutine(patch_mgr.CollectPatchContextByList(progress, need_download_patch_list));

            // 磁盘空间检查
            var free_space_in_mb = DBOSManager.getOSBridge().getStorageFreeSize();

            var total_bytes_to_download = progress.TotalBytesToDownload;
            var total_bytes_to_download_in_mb = total_bytes_to_download / 1024.0f / 1024.0f;

            // 计算需要的磁盘空间（预留多点空间，是下载需求大1.5倍，最多不多于50Mb）
            var need_space_in_mb = total_bytes_to_download_in_mb * 1.5;
            if (need_space_in_mb - total_bytes_to_download_in_mb > 50) {
                need_space_in_mb = total_bytes_to_download_in_mb + 50;
            }

            if (free_space_in_mb < need_space_in_mb) {
                yield return xc.MainGame.GetGlobalMono().StartCoroutine(
                    message_box.ShowRoutine(DBConstText.GetText("SCENE_DISK_NOTENOUGH"), xc.TextHelper.BtnConfirm));

                Application.Quit();
            }

            // 移动数据网络
            var cur_network_state = Application.internetReachability;
            if (cur_network_state == NetworkReachability.ReachableViaCarrierDataNetwork) {
                if (total_bytes_to_download_in_mb > 10) {
                    // wait messagebox 提示下载
                    yield return xc.MainGame.GetGlobalMono().StartCoroutine(
                        message_box.ShowRoutine(string.Format(DBConstText.GetText("SCENE_PATCH_DOWNLOAD"), total_bytes_to_download_in_mb), xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel));

                    if (message_box.Result == MessageBoxUI.EResult.Cancel) {
                        Application.Quit();

                        yield break;
                    }
                }
            }

            // 不限速
            patch_mgr.LimitBytesPerSec = 0;

            mIsInPatch = true;

            progress.Start();

            while (!progress.IsFinish) {
                if (patch_mgr.FatalError) {
                    yield return xc.MainGame.GetGlobalMono().StartCoroutine(
                        message_box.ShowRoutine(DBConstText.GetText("SCENE_DOWNLOAD_FAIL"), xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel));

                    if (message_box.Result == MessageBoxUI.EResult.Cancel) {
                        Application.Quit();

                        yield break;
                    }

                    patch_mgr.Resume();
                }

                var download_speed_str = patch_mgr.DownloadSpeedStr;

                string progress_tips;
                if (total_bytes_to_download_in_mb < 1) {
                    var total_bytes_to_download_in_kb = total_bytes_to_download / 1024.0f;
                    var bytes_download_in_kb = progress.BytesDownloaded / 1024.0f;

                    progress_tips = string.Format(DBConstText.GetText("SCENE_DOWNLOAD_NOTICE"), bytes_download_in_kb, total_bytes_to_download_in_kb, download_speed_str);
                }
                else {
                    var bytes_download_in_mb = progress.BytesDownloaded / 1024.0f / 1024.0f;
                    progress_tips = string.Format(DBConstText.GetText("SCENE_DOWNLOAD_NOTICE2"), bytes_download_in_mb, total_bytes_to_download_in_mb, download_speed_str);
                }

                xc.ui.ugui.UIManager.GetInstance().SetLoadingTip(progress_tips);
                xc.ui.ugui.UIManager.GetInstance().UpdateLoadingBar(progress.Value);

                yield return null;
            }

            mIsInPatch = false;

            // 去掉更新的进度
            //SetRandomTip();
            xc.ui.ugui.UIManager.GetInstance().UpdateLoadingBar(0);
        }

        ResourceLoader.Instance.sceneLoadAsyncOp = null;

        QuadTreeSceneManager.Instance.StartLoadPercentage = 0.2f + UnityEngine.Random.Range(-0.1f, 0.1f);

        xc.MainGame.GetGlobalMono().StartCoroutine(ResourceLoader.Instance.load_scene(asset_path, level_name, null));
        xc.MainGame.GetGlobalMono().StartCoroutine(Game.WaitForSceneLoadAsyncOp());
    }
}
