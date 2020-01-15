using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Sprite3DEx : MonoBehaviour
{
    public Material ShareMaterial;

    private MeshRenderer mMeshRender;
    private Material mMaterial;

    static Dictionary<string, Material> sIconMaterials = new Dictionary<string, Material>();

    /// <summary>
    /// 设置使用的Texture
    /// </summary>
    public void SetTexture(Texture tex, string iconPath)
    {
        if(tex == null)
        {
            mMeshRender.enabled = false;
            return;
        }

        mMaterial = SpriteMaterialManager.Instance.GetMaterial(iconPath);

        // 通过共享材质实例化新材质
        if(mMaterial == null)
        {
            mMaterial = new Material(ShareMaterial);
            mMaterial.name = tex.name;

            SpriteMaterialManager.Instance.SetMaterial(iconPath, mMaterial);
        }

        mMeshRender.sharedMaterial = mMaterial;
        mMaterial.mainTexture = tex;
        mMeshRender.enabled = true;
    }

    /// <summary>
    /// 设置贴图的UV
    /// </summary>
    public Rect UVOffset
    {
        set
        {
            if(mMeshRender != null)
            {
                var iconRect = value;

                // 设置_MainTex_ST属性
                MaterialPropertyBlock property_block = new MaterialPropertyBlock();
                mMeshRender.GetPropertyBlock(property_block);
                property_block.SetVector("_MainTex_ST", new Vector4(iconRect.width, iconRect.height, iconRect.x, iconRect.y));
                mMeshRender.SetPropertyBlock(property_block);
            }
            else
            {
                GameDebug.LogError("UVOffset mMeshRender is null");
            }
        }
    }

    /// <summary>
    /// 设置可渲染属性
    /// </summary>
    public bool RenderEnable
    {
        set
        {
            if (mMeshRender == null)
                mMeshRender = GetComponent<MeshRenderer>();

            mMeshRender.enabled = value;
        }
    }

    /// <summary>
    /// 回收到内存池之前的操作
    /// </summary>
    public void BeforeRecycle()
    {
        RenderEnable = true;
        mMeshRender.sharedMaterial = null;
        mMaterial = null;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    void Awake()
    {
        // 初始化Mesh数据
        Mesh quadMesh = new Mesh();

        float width = 1;
        float height = 1;

        float x = width / 2;
        float y = height / 2;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(-x, -y, 0);
        vertices[1] = new Vector3(x, -y, 0);
        vertices[2] = new Vector3(-x, y, 0);
        vertices[3] = new Vector3(x, y, 0);
        quadMesh.vertices = vertices;

        int[] trigle = new int[6];
        trigle[0] = 0;
        trigle[1] = 2;
        trigle[2] = 1;
        trigle[3] = 2;
        trigle[4] = 3;
        trigle[5] = 1;
        quadMesh.triangles = trigle;

        Vector3[] normal = new Vector3[4];
        normal[0] = -Vector3.forward;
        normal[1] = -Vector3.forward;
        normal[2] = -Vector3.forward;
        normal[3] = -Vector3.forward;
        quadMesh.normals = normal;

        Vector2[] uv = new Vector2[4];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0, 1);
        uv[3] = new Vector2(1, 1);
        quadMesh.uv = uv;

        MeshFilter filter = GetComponent<MeshFilter>();
        filter.mesh = quadMesh;

        mMeshRender = GetComponent<MeshRenderer>();
        mMeshRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        mMeshRender.receiveShadows = false;
    }
}
