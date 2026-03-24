using UnityEngine;
using UnityEngine.UI; // 如果用 Unity 的 UI 组件
using TMPro; // 如果用 TextMeshPro

public class EggCollision : MonoBehaviour
{
    public GameObject uiPopup;  // UI弹窗对象
    public TextMeshProUGUI popupText;
    public bool IsEgg = false;

    void Start()
    {
        uiPopup.SetActive(false); // 初始时隐藏弹窗
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 输出碰撞物体的信息
        Debug.LogError("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Egg"))
        {
            Debug.LogError("Egg collision detected! Showing popup.");
            ShowPopup();
            IsEgg = true;
        }
        else
        {
            Debug.LogError("The collided object is not tagged as 'egg'.");
        }
    }

    void ShowPopup()
    {
        uiPopup.SetActive(true);  // 显示弹窗
        popupText.text = "Mr.Kevin Rabbit 提醒你：向左走，翻过高高的树桩，前往池塘[用Q查看地图]"; // 更新提示文本
        Debug.LogError("Popup displayed: " + popupText.text);
    }
}
