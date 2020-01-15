using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 变灰材质的组件
/// </summary>
/// 
[RequireComponent(typeof(Image))]
public class GreyMaterialComponent : MonoBehaviour
{
    private Image mImage;
    private bool mIsGrey = false;
    public bool IsGrey = false;
    static bool m_is_loading_mat = false;
    static Material m_default_mat = null;
    static Shader m_default_shader = null;
    static string m_default_mat_name = "";

    bool m_wait_loading = false;
    public void Awake()
    {
        mIsGrey = IsGrey;//同步新旧2个变量
        mImage = transform.GetComponent<Image>();
    }

    void CheckAndSetGrey()
    {
        if (mImage == null)
            return;

        if (string.IsNullOrEmpty(m_default_mat_name))
            m_default_mat_name = xc.GameConstHelper.GetString("GAME_GREY_MAT_NAME");

        //不是指定的材质，主动更换
        var imageMat = mImage.material;
        if (imageMat == null || imageMat.name.Contains(m_default_mat_name) == false)
        {
            if (m_default_mat != null)
            {
                mImage.material = m_default_mat;
            }
            else if (m_is_loading_mat == false && SGameEngine.ResourceLoader.Instance != null)
            {
                m_is_loading_mat = true;
                SGameEngine.ResourceLoader.Instance.LoadAssetAsync("Assets/" + xc.ResPath.MAT_UI_IMAGE_GREY_MAT, MatFinishLoad);
                m_wait_loading = true;
                return;
            }
            else
            {
                m_wait_loading = true;
                return;
            }
        }

        //更换Shader
        imageMat = mImage.material;
        if (imageMat != null && imageMat.shader != m_default_shader)
        {
            if (m_default_shader != null)
            {
                mImage.material.shader = m_default_shader;
            }
            else
            {
                m_wait_loading = true;
                return;
            }
        }

        SetGrey(mIsGrey);
    }

    static void MatFinishLoad(SGameEngine.AssetResource asset)
    {
        m_is_loading_mat = false;
        if (asset != null && asset.asset_ != null)
        {
            m_default_mat = asset.asset_ as Material;
            if(m_default_mat != null)
            {
                string shader_name = "";
#if UNITY_IOS || UNITY_ANDROID
                shader_name = xc.ResPath.MAT_UI_IMAGE_GREY_ETC_SHADER; //GreyShaderPathName_ETC;
#else
                shader_name = xc.ResPath.MAT_UI_IMAGE_GREY_SHADER;//GreyShaderPathName;
#endif
                SGameEngine.ResourceLoader.Instance.LoadAssetAsync("Assets/" + shader_name, ShaderFinishLoad);
            }
        }
        else
        {
            m_default_mat = null;
            m_default_shader = null;
        }
    }

    static void ShaderFinishLoad(SGameEngine.AssetResource asset)
    {
        if (asset != null && asset.asset_ != null)
        {
            m_default_shader = asset.asset_ as Shader;
            m_default_mat.shader = m_default_shader;
        }
        else
        {
            m_default_shader = null;
        }
    }
    
    void Update()
    {
        if (mImage == null)
            return;

        if (m_wait_loading)
        {
            //需要更新材质
            if (m_default_mat != null && m_default_shader != null)
            {
                m_wait_loading = false;
                mImage.material = m_default_mat;
                SetGrey(mIsGrey);
            }
        }
        else
        {
            if(mIsGrey != IsGrey)
            {
                mIsGrey = IsGrey;
                CheckAndSetGrey();
            }
        }
    }

    void SetGrey(bool is_grey)
    {
        if (mImage == null)
            return;

        var imageMat = mImage.material;
        if (imageMat == null)
            return;

        if (is_grey)
        {
            Material m = GameObject.Instantiate(imageMat) as Material;
            m.name = "GreyInstance";
            m.SetFloat("_Grey", 0);   //灰白色
            mImage.material = m;
        }
        else
        {
            mImage.material = null;
        }
        if (imageMat.name == "GreyInstance")
            GameObject.Destroy(imageMat);
    }
}