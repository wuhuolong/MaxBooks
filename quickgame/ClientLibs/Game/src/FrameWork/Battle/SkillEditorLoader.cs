using UnityEngine;

public class SkillEditorLoader : MonoBehaviour
{
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(GameObject.Find("SkillPanel"));
        xc.Game.Instance.IsSkillEditorScene = true;
        gameObject.AddComponent<SGameFirstPass.NewInitSceneLoader>();
    }
}
