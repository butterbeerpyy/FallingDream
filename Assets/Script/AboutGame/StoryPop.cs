
using System.Diagnostics;
using UnityEngine;

public class StoryPopup : MonoBehaviour
{
    public GameObject popupUI; // 弹窗UI
    public float yOffset = 2.0f; // 弹窗距离物体顶部的距离
    private bool isShowing = false;

    void Start()
    {
        if (popupUI == null)
        {
            popupUI = Instantiate(Resources.Load<GameObject>("Canvas_Tanchunag"), transform);
        }
        else
        {
            popupUI.SetActive(false); // 确保初始状态隐藏
        }
        Collider2D collider = GetComponent<Collider2D>();
        if (!collider.isTrigger)
        {
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")&& !isShowing )
        {
            UnityEngine.Debug.Log("Player 已触发");
            ShowPopup();
        }
    }

    // 离开触发器时隐藏弹窗
    private void OnTriggerExit2D(Collider2D other)
    {
        UnityEngine.Debug.Log($"{other.gameObject.name} 离开触发器");
        if (other.CompareTag("Player") && isShowing)
        {
            UnityEngine.Debug.LogWarning("Player 已离开");
            HidePopup();
        }
    }

    void ShowPopup()
    {
        if (popupUI != null)
        {
            popupUI.SetActive(true);
            isShowing = true;

            // 将弹窗位置设置为物体顶部的屏幕坐标
            Vector3 worldPosition = transform.position + new Vector3(0, yOffset, 0);
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
            popupUI.transform.position = screenPosition;
        }
    }

    void HidePopup()
    {
        if (popupUI != null)
        {
            popupUI.SetActive(false);
            isShowing = false;
        }
    }
}
