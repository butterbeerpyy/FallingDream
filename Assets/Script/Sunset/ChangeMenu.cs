using UnityEngine;
using UnityEngine.SceneManagement;
public class CUI : MonoBehaviour
{
    public FadeManager fadeManager;
    void Start()
    {
        if (fadeManager == null)
        {
            fadeManager = FindObjectOfType<FadeManager>();
            if (fadeManager == null)
            {
                Debug.LogError("FadeManager 未找到！");
            }
        }
        gameObject.SetActive(true);
        if (!enabled)
        {
            enabled = true; // 确保脚本启用
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //PlayerController player = other.GetComponent<PlayerController>();

            //FadeManager.FadeOut(1);
            //Debug.LogError("1");
            fadeManager.FadeOut(1);


        }
    }
}
