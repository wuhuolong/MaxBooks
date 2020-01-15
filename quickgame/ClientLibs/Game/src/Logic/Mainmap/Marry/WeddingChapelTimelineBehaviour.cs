//------------------------------------------------------------------------------
// Desc   :  婚宴拜堂剧情动画组件
// Author :  ljy
// Date   :  2018.11.20
//------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using xc.ui.ugui;
using xc;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[wxb.Hotfix]
public class WeddingChapelTimelineBehaviour : MonoBehaviour
{
    List<uint> mModelIds = null;

    public void Awake()
    {
        if (SceneHelp.Instance.IsInWeddingInstance == true) // 婚宴副本外面使用第二套模型
        {
            mModelIds = GameConstHelper.GetUintList("GAME_WEDDING_DRAMA_TIMELINE_COUPLE_MODEL_IDS");
        }
        else
        {
            mModelIds = GameConstHelper.GetUintList("GAME_WEDDING_DRAMA_TIMELINE_COUPLE_MODEL_IDS_2");
        }

        PlayableDirector playableDirector = gameObject.GetComponent<PlayableDirector>();
        if (playableDirector != null)
        {
            uint rid1 = 0;
            uint rid2 = 0;
            MarryHelper.GetWeddingCoupleJobs(out rid1, out rid2);

            TimelineAsset asset = playableDirector.playableAsset as TimelineAsset;
            foreach (TrackAsset track in asset.GetOutputTracks())
            {
                GroupTrack group = track.GetGroup();
                if (group != null)
                {
                    if (group.name.Equals("Mate") == true)
                    {
                        foreach (PlayableBinding output in track.outputs)
                        {
                            if (output.sourceObject != null)
                            {
                                Object binding = playableDirector.GetGenericBinding(output.sourceObject);
                                if (binding == null)
                                {
                                    GameDebug.LogError("Player wedding chapel timeline " + this.name + " error!!! " + output.sourceObject.name + " 's binding object is null!!!");
                                    continue;
                                }
                                GameObject bindingObj = binding as GameObject;

                                // 根据职业显示主角的模型
                                if (bindingObj != null)
                                {
                                    if (bindingObj.name.Equals("Mate_R") == true)
                                    {
                                        if (rid1 > 0)
                                        {
                                            bindingObj.SetActive(false);
                                            ReplaceActorModel(playableDirector, output, bindingObj, rid1, bindingObj.name);
                                        }
                                    }
                                    if (bindingObj.name.Equals("Mate_L") == true)
                                    {
                                        if (rid2 > 0)
                                        {
                                            bindingObj.SetActive(false);
                                            ReplaceActorModel(playableDirector, output, bindingObj, rid2, bindingObj.name);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // 跳过按钮
        Transform skipButtonTrans = gameObject.transform.Find("UI/Canvas/SkipButton");
        if (skipButtonTrans != null)
        {
            Button skipButton = skipButtonTrans.GetComponent<Button>();
            if (skipButton != null)
            {
                skipButton.onClick.RemoveAllListeners();
                skipButton.onClick.AddListener(() =>
                {
                    TimelineManager.Instance.StopAll();
                });
            }
        }

        GameInput.Instance.EnableInput(true, true);
    }

    void OnDestroy()
    {
        GameInput.Instance.EnableInput(false, true);
    }

    void ReplaceActorModel(PlayableDirector playableDirector, PlayableBinding playableBinding, GameObject obj, uint rid, string gameObjectName)
    {
        Transform parent = obj.transform.parent;
        SGameEngine.ResourceLoader.Instance.StartCoroutine(LoadActorPrefabCoroutine(obj, playableDirector, playableBinding, parent, rid, gameObjectName));
    }

    IEnumerator LoadActorPrefabCoroutine(GameObject oldObj, PlayableDirector playableDirector, PlayableBinding playableBinding, Transform parent, uint rid, string gameObjectName)
    {
        if (mModelIds == null)
        {
            yield break;
        }
        uint modelId = mModelIds[(int)rid - 1];
        ModelInfo modelInfo = ModelHelper.GetModel(modelId);
        if (modelInfo == null)
        {
            GameDebug.LogError("Load actor prefab error, can not find model:" + modelId);
            yield break;
        }
        string prefabPath = modelInfo.Model;

        SGameEngine.PrefabResource pr = new SGameEngine.PrefabResource();
        yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_prefab(string.Format("Assets/Res/{0}.prefab", prefabPath), pr));

        GameObject obj = pr.obj_;
        if (obj == null)
        {
            GameDebug.LogError("Load actor prefab " + prefabPath + " error, can not load prefab!");
            yield break;
        }

        obj.name = gameObjectName;

        OnActorPrefabLoadSuccess(oldObj, obj, playableDirector, playableBinding, parent, modelInfo);
    }

    void OnActorPrefabLoadSuccess(GameObject oldObj, GameObject obj, PlayableDirector playableDirector, PlayableBinding playableBinding, Transform parent, ModelInfo modelInfo)
    {
        Transform trans = obj.transform;
        trans.SetParent(parent);
        trans.localPosition = Vector3.zero;
        trans.localScale = new Vector3(modelInfo.Scale, modelInfo.Scale, modelInfo.Scale);
        trans.localRotation = Quaternion.identity;

        // 添加Animator组件
        Animator animator = obj.GetComponent<Animator>();
        if (animator == null)
        {
            animator = obj.AddComponent<Animator>();
        }
        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.Normal;
            animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        }

        // 删除旧模型
        GameObject.DestroyImmediate(oldObj);

        playableDirector.SetGenericBinding(playableBinding.sourceObject, obj);
    }
}
