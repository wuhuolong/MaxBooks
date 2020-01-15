//---------------------------------------------
// QudtreeScenePart.cs
// 四叉树的资源节点，绑定在每个需要打包节点的prefab上
// @raorui comments
// 2017.6.11
//---------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SGameEngine;

public class QuadtreeScenePart : MonoBehaviour
{
    bool m_IsDynamicLightmap = false; // 是否动态加载的lightmap

    List<AssetResource> m_TexRes = new List<AssetResource>();

    /// <summary>
    /// 静态合批后的Mesh
    /// </summary>
    public Dictionary<int,Mesh> combinedMesh = new Dictionary<int,Mesh>();

    void Start()
    {
        if(m_IsDynamicLightmap)
        {
            StartCoroutine(ApplySceneNode());
        }
        else
        {
            var light_data = GetComponent<PrefabLightmapData>();
            ApplyLightmapData(light_data);
            CombineNode();
        }
    }

    /// <summary>
    /// 卸载的时候，卸载合批的Mesh资源
    /// </summary>
    void OnDestroy()
    {
        foreach (var item in combinedMesh.Values)
        {
            DestroyImmediate(item, true);
        }
        combinedMesh.Clear();

        foreach (var res in m_TexRes)
        {
            if (res != null)
                res.destroy();
        }
        m_TexRes.Clear();
    }

    private IEnumerator ApplySceneNode()
    {
        var light_data = GetComponent<PrefabLightmapData>();
        yield return StartCoroutine(ApplyLightmaps(light_data));

        CombineNode();
    }

    /// <summary>
    /// 进行节点的静态合批
    /// </summary>
    void CombineNode()
    {
        StaticBatchingUtility.Combine(gameObject);
        var root_trans = gameObject.transform;
        for(int i = 0; i < root_trans.childCount; ++i)
        {
            var child_trans = root_trans.GetChild(i);
            if (child_trans == null)
                continue;

            var filter = child_trans.GetComponent<MeshFilter>();
            if (filter == null)
                continue;

            var share_mesh = filter.sharedMesh;
            if (share_mesh == null)
                continue;

            if (share_mesh.name.StartsWith("Combined"))
            {
                int instId = share_mesh.GetInstanceID();
                if (!combinedMesh.ContainsKey(instId))
                    combinedMesh[instId] = share_mesh;
            }
        }
    }

    /// <summary>
    /// 使用PrefabLightmapData中的数据来设置lightmap的参数
    /// </summary>
    private IEnumerator ApplyLightmaps(PrefabLightmapData data)
    {
        if (data == null)
            yield break;

        RendererInfo[] rendererInfos = data.m_RendererInfos;
        if (rendererInfos == null)
        {
            Debug.LogWarning("<<PrefabLightmapData , ApplyLightmaps>> renderer info is null ! " + gameObject.name);
            yield break;
        }

        if (rendererInfos.Length <= 0)
        {
            yield break;
        }

        List<Texture2D> lightmapLights = Pool<Texture2D>.List.New(data.m_LightmapLightFiles.Length);
        for (int i = 0; i < data.m_LightmapLightFiles.Length; ++i)
        {
            AssetResource ar = new AssetResource();
            yield return StartCoroutine(ResourceLoader.Instance.load_asset(data.m_LightmapLightFiles[i], typeof(Texture2D), ar));
            m_TexRes.Add(ar);
            lightmapLights.Add(ar.asset_ as Texture2D);
        }

        List<Texture2D> lightmapDirs = Pool<Texture2D>.List.New(data.m_LightmapDirFiles.Length);
        for (int i = 0; i < data.m_LightmapDirFiles.Length; ++i)
        {
            AssetResource ar = new AssetResource();
            yield return StartCoroutine(ResourceLoader.Instance.load_asset(data.m_LightmapDirFiles[i], typeof(Texture2D), ar));
            m_TexRes.Add(ar);
            lightmapDirs.Add(ar.asset_ as Texture2D);
        }

        LightmapData[] settingLightMaps = LightmapSettings.lightmaps;//当前场景中已经存在的lightmap数据
        int[] lightmapOffsetIndex = new int[lightmapLights.Count];//定义
        List<LightmapData> combinedLightmaps = new List<LightmapData>();//合并后的lightmap数据

        bool exist = false;
        for (int i = 0; i < lightmapLights.Count; i++)
        {
            exist = false;
            for (int j = 0; j < settingLightMaps.Length; j++)
            {
                if (lightmapLights[i] == settingLightMaps[j].lightmapColor)//如果与当前场景中的lightmap贴图一致
                {
                    lightmapOffsetIndex[i] = j;
                    exist = true;
                    break;
                }
            }

            //如果在当前场景的光照贴图列表中找不到，则创建新的光照数据
            if (!exist)
            {
                // 添加到combinedLightmaps的最后
                lightmapOffsetIndex[i] = settingLightMaps.Length + combinedLightmaps.Count;

                LightmapData newLightData = new LightmapData();
                newLightData.lightmapColor = lightmapLights[i];
                newLightData.lightmapDir = lightmapDirs[i];
                combinedLightmaps.Add(newLightData);
            }
        }

        Pool<Texture2D>.List.Free(lightmapLights);
        Pool<Texture2D>.List.Free(lightmapDirs);

        //lightmap的组合数据
        LightmapData[] finalCombinedLightData = new LightmapData[combinedLightmaps.Count + settingLightMaps.Length];
        settingLightMaps.CopyTo(finalCombinedLightData, 0);
        combinedLightmaps.CopyTo(finalCombinedLightData, settingLightMaps.Length);
        combinedLightmaps.Clear();

        //重设所有Render的lightmapIndex和lightmapScaleOffset
        for (int i = 0; i < rendererInfos.Length; i++)
        {
            RendererInfo info = rendererInfos[i];

            info.renderer.lightmapIndex = lightmapOffsetIndex[info.LightmapIndex];
            info.renderer.lightmapScaleOffset = info.LightmapOffsetScale;
        }

        LightmapSettings.lightmapsMode = LightmapsMode.CombinedDirectional;////(LightmapsMode)(2);//.SeparateDirectional;
        LightmapSettings.lightmaps = finalCombinedLightData;
    }

    /// <summary>
    /// 使用PrefabLightmapData中的数据来设置lightmap的参数
    /// </summary>
    void ApplyLightmapData(PrefabLightmapData data)
    {
        if (data == null)
            return;

        RendererInfo[] rendererInfos = data.m_RendererInfos;
        if (rendererInfos == null)
        {
            Debug.LogWarning("<<PrefabLightmapData , ApplyLightmaps>> renderer info is null ! " + gameObject.name);
            return;
        }

        if (rendererInfos.Length <= 0)
        {
            return;
        }

        LightmapData[] settingLightMaps = LightmapSettings.lightmaps;//当前场景中已经存在的lightmap数据
        if (settingLightMaps == null)
        {
            Debug.LogWarning("<<PrefabLightmapData , ApplyLightmaps>> LightmapSettings.lightmaps is null !");
            return;
        }

        string[] lightmap_light_files = data.m_LightmapLightFiles;
        if (lightmap_light_files == null)
        {
            Debug.LogWarning("<<PrefabLightmapData , ApplyLightmaps>> lightmap_light_files is null !");
            return;
        }

        List<int> lightmapOffsetIndex = Pool<int>.List.New(lightmap_light_files.Length);//定义
        for(int i = 0; i< lightmap_light_files.Length; ++i)
        {
            lightmapOffsetIndex.Add(0);
        }

        bool exist = false;
        for (int i = 0; i < lightmap_light_files.Length; i++)
        {
            exist = false;
            for (int j = 0; j < settingLightMaps.Length; j++)
            {
                string filename = System.IO.Path.GetFileNameWithoutExtension(lightmap_light_files[i]);
                if (filename == settingLightMaps[j].lightmapColor.name)//如果与当前场景中的lightmap贴图一致
                {
                    lightmapOffsetIndex[i] = j;
                    exist = true;
                    break;
                }
            }

            //如果在当前场景的光照贴图列表中找不到
            if (!exist)
            {
                lightmapOffsetIndex[i] = -1;
            }
        }

        //重设所有Render的lightmapIndex和lightmapScaleOffset
        for (int i = 0; i < rendererInfos.Length; i++)
        {
            RendererInfo info = rendererInfos[i];

            int lightmap_index = lightmapOffsetIndex[info.LightmapIndex];

            if (lightmap_index == -1)
                continue;

            if (info.renderer == null)
                continue;

            // 开启ShadowMask
            Material mat = info.renderer.sharedMaterial;
            if (mat != null)
            {
                // 获取ShadowMask贴图
                Texture shadow_mask_tex = settingLightMaps[lightmap_index].shadowMask;
                if (shadow_mask_tex != null)
                {
                    mat.EnableKeyword("SHADOWS_SHADOWMASK");

                    // 设置unity_ShadowMask贴图
                    MaterialPropertyBlock property_block = new MaterialPropertyBlock();
                    info.renderer.GetPropertyBlock(property_block);
                    property_block.SetTexture("unity_ShadowMask", shadow_mask_tex);
                    info.renderer.SetPropertyBlock(property_block);
                }
                
                // 设置lightmap索引
                info.renderer.lightmapIndex = lightmap_index;
                info.renderer.lightmapScaleOffset = info.LightmapOffsetScale;
            }
            else
                Debug.Log("[ApplyLightmapData]object has no material", info.renderer);
        }

        Pool<int>.List.Free(lightmapOffsetIndex);
    }
}
