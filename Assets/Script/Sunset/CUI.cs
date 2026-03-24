using UnityEngine;
using UnityEngine.SceneManagement;
using TarodevController;
public class ChangeUI : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        void Start()
        {
            if (!enabled)
            {
                enabled = true; // 确保脚本启用
            }
        }
        if (other.CompareTag("Player"))
        {
            //PlayerController player = other.GetComponent<PlayerController>();

            //FadeManager.FadeOut(1);
            Debug.LogError("1");


        }
    }
}
