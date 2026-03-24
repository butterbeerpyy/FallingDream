using UnityEngine;
using TMPro;

public class WorldPositionUI : MonoBehaviour
{
    public Transform targetPosition; // 目标世界坐标（比如角色的位置）
    public TextMeshProUGUI messageText; // 提示的 UI 文本

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        // 设置提示内容
        if (messageText != null)
        {
            messageText.text = "本关中，一些地形比较难跳。\n" +
                               "如果你对精细操作感到厌倦--\n" +
                               "用Q键查看地图，重新规划路线吧\n" ;
            messageText.gameObject.SetActive(true);

            // 5秒后隐藏
            Invoke(nameof(HideMessage), 10f);
        }
    }


    void Update()
    {
        if (targetPosition != null && messageText != null)
        {
            // 将世界坐标转换为屏幕坐标
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(targetPosition.position);

            // 👉 这里的 (-100, -50) 是向左下角偏移的值，根据需要调整
            screenPosition.x -= 100;
            screenPosition.y -= 50;

            messageText.transform.position = screenPosition;
        }
    }


    void HideMessage()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }
}
