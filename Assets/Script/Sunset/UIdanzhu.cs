using UnityEngine;
using TMPro; // 引入 TextMeshPro

public class SunStoryPopup : MonoBehaviour
{
    public GameObject popupUI; // 弹窗UI
    public TextMeshProUGUI popupText; // 弹窗显示的文字
    public float yOffset = 2.0f; // 弹窗距离物体顶部的距离
    private bool isShowing = false;

    void Start()
    {
        if (popupUI != null)
        {
            popupUI.SetActive(false); // 确保初始状态隐藏
            //popupText = popupUI.GetComponentInChildren<TextMeshProUGUI>();
        }

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null && !collider.isTrigger)
        {
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isShowing)
        {
            UnityEngine.Debug.Log("Player 已触发");
            SunShowPopup();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isShowing)
        {
            UnityEngine.Debug.Log("Player 已离开");
            SunHidePopup();
        }
    }

    void SunShowPopup()
    {
        if (popupUI != null)
        {
            popupUI.SetActive(true);
            isShowing = true;

            // 将弹窗位置设置为物体顶部的世界坐标
            Vector3 worldPosition = transform.position + new Vector3(0, 100, 0) ;
            popupUI.transform.position = worldPosition; // 直接使用世界坐标
        }
    }

    void SunHidePopup()
    {
        if (popupUI != null)
        {
            popupUI.SetActive(false);
            isShowing = false;
        }
    }
}
