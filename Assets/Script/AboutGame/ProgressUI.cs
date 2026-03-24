using UnityEngine;
using TMPro; // ✅ 使用 TextMeshPro

public class GameProgressUI : MonoBehaviour // ✅ 修改类名
{
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI unlockMessageText;

    private int totalStories = 4;
    private int unlockedCount = 0;

    void Start()
    {
        //LockToTopLeft();  // 锁定到左上角
        UpdateProgressUI();
        unlockMessageText.gameObject.SetActive(false);
    }


    public void UnlockStory(string storyName)
    {
        unlockedCount++;
        UpdateProgressUI();

        // 显示解锁信息
        unlockMessageText.text = $"{storyName} 已解锁";
        unlockMessageText.gameObject.SetActive(true);

        // 2秒后隐藏
        Invoke(nameof(HideUnlockMessage), 2f);
    }

    void UpdateProgressUI()
    {
        progressText.text = $"剧情碎片进度{unlockedCount}/{totalStories}";
    }

    void HideUnlockMessage()
    {
        unlockMessageText.gameObject.SetActive(false);
    }
}
