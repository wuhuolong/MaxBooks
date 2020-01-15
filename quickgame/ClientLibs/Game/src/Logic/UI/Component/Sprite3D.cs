using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Sprite3D : MonoBehaviour
{
	float width = 1;
	float height = 1;
	float mScale = 0.5f;
    public Material mat;
	MeshRenderer mMeshRender;

	public bool UseDefaultMaterial = true;

    //public Material MainMat
    //{
    //    get { return  mat; }
    //    set { MainMat = value; }
    //}

	public Texture MainTexture {
		get{ return mat.mainTexture;}
		set {
			if (mat != null) {
				mat.mainTexture = value;
				if (value != null) {
					Transform cacheTransform = transform;
					Vector3 scale;
					scale.x = mScale;
					scale.y = mScale * (float)mat.mainTexture.height / mat.mainTexture.width;
					scale.z = 1;
					cacheTransform.localScale = scale;
					
					mMeshRender.enabled = true;
				} else {
					mMeshRender.enabled = false;
				}
			}
		}
	}
	
	public void SetTexute (Texture tex)
	{
		if (mat != null) {
			mat.mainTexture = tex;
			if (tex != null) {
				mMeshRender.enabled = true;
			} else {
				mMeshRender.enabled = false;
			}
		}
	}
	
	public bool RenderEnable
    {
		set
        {
			if (mMeshRender == null)
				mMeshRender = GetComponent<MeshRenderer> ();
			
			mMeshRender.enabled = value;
		}
	}
	
	// Use this for initialization
	void Awake ()
	{

		Mesh quadMesh = new Mesh ();

		float x = width / 2;
		float y = height / 2;
		
		Vector3[] vertices = new Vector3[4];
		vertices [0] = new Vector3 (-x, -y, 0);
		vertices [1] = new Vector3 (x, -y, 0);
		vertices [2] = new Vector3 (-x, y, 0);
		vertices [3] = new Vector3 (x, y, 0);
		quadMesh.vertices = vertices;
		
		int[] trigle = new int[6];
		trigle [0] = 0;
		trigle [1] = 2;
		trigle [2] = 1;
		trigle [3] = 2;
		trigle [4] = 3;
		trigle [5] = 1;
		quadMesh.triangles = trigle;
		
		Vector3[] normal = new Vector3[4];
		normal [0] = -Vector3.forward;
		normal [1] = -Vector3.forward;
		normal [2] = -Vector3.forward;
		normal [3] = -Vector3.forward;
		quadMesh.normals = normal;
		
		Vector2[] uv = new Vector2[4];
		uv [0] = new Vector2 (0, 0);
		uv [1] = new Vector2 (1, 0);
		uv [2] = new Vector2 (0, 1);
		uv [3] = new Vector2 (1, 1);
		quadMesh.uv = uv;
		
		MeshFilter filter = GetComponent<MeshFilter> ();
		filter.mesh = quadMesh;
		
		mMeshRender = GetComponent<MeshRenderer> ();
        mMeshRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		mMeshRender.receiveShadows = false;
		
		if(mMeshRender.material == null || UseDefaultMaterial == true)
		{
			Shader shader = Shader.Find ("Unlit/Transparent");
			if(shader != null){
				mat = new Material (shader);
				mMeshRender.material = mat;
			}else
				GameDebug.LogError("Unlit/Transparent shader cannot find.");
		}

        mat = mMeshRender.material;
    } 
	
	void OnEnable()
	{
		if (gameObject)
		{
			gameObject.SetActive(true);
		}
	}
	
	void OnDisable()
	{
		if (gameObject)
		{
			gameObject.SetActive(false);
		}
	}
	
	public float Scale
    {
		set
        {
			if (value <= 0 || mScale == value)
				return;
			
			mScale = value;
			if (mat != null && mat.mainTexture != null) {
				Transform cacheTransform = transform;
				Vector3 scale;
				scale.x = mScale;
				scale.y = mScale * (float)mat.mainTexture.height / mat.mainTexture.width;
				scale.z = 1;
				cacheTransform.localScale = scale;
			}
		}

		get
        {
            return mScale;
        }
	}
}
