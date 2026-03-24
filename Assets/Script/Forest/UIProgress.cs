using UnityEngine;
using TMPro;
//using System.Diagnostics;

public class LevelProgressUI : MonoBehaviour
{
    public TextMeshProUGUI levelProgressText;
    public EggCollision eggCollision;
    public LevelManager levelManager;

    void Start()
    {
        UpdateProgressUI();
    }

    void Update()
    {
        UpdateProgressUI();
    }

    void UpdateProgressUI()
    {
        if (eggCollision != null && levelManager != null)
        {
            int progress = (eggCollision.IsEgg ? 1 : 0) + (levelManager.IsVictory ? 1 : 0);
            int maxProgress = 2;
            levelProgressText.text = $"当前关卡进度 ({progress}/{maxProgress})";
            // 输出调试信息
            Debug.LogError($"Progress updated: {progress}/{maxProgress}");
        }
        else
        {
            Debug.LogError("EggCollision 或 LevelManager 未设置");
        }
    }
}
