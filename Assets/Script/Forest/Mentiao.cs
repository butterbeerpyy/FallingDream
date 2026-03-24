using UnityEngine;
using UnityEngine.SceneManagement;

public class Mentiao : MonoBehaviour
{
    public FadeManager fadeManager;

    void Awake()
    {
        if (!enabled)
        {
            enabled = true;
            Debug.Log("脚本已启用！");
        }

        if (fadeManager == null)
        {
            fadeManager = FindObjectOfType<FadeManager>();
            if (fadeManager == null)
            {
                Debug.LogError("FadeManager 未找到！");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.LogError("玩家触发事件！");
            fadeManager.FadeOut(11);
        }
    }
}
