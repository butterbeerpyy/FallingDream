using UnityEngine;
using TMPro; 

public class StoryProgressUI : MonoBehaviour
{
    public TextMeshProUGUI progressText; 
    public TextMeshProUGUI unlockMessageText; 

    private int totalStories = 4;
    private int unlockedCount = 0;

    void Start()
    {
        UpdateProgressUI(); 
        unlockMessageText.gameObject.SetActive(false); // 初始时隐藏
    }

    public void UnlockStory(string storyName)
    {
        unlockedCount++;
        UpdateProgressUI();

        unlockMessageText.text = $"{storyName} 已解锁";
        unlockMessageText.gameObject.SetActive(true);
        Invoke(nameof(HideUnlockMessage), 2f);
    }

    void UpdateProgressUI()
    {
        progressText.text = $"剧情碎片进度 {unlockedCount}/{totalStories}";
    }

    void HideUnlockMessage()
    {
        unlockMessageText.gameObject.SetActive(false);
    }
}
