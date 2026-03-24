using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject victoryUI;
    public GameObject failUI;
    // 游戏结果
    public enum GameResult
    {
        Victory,
        Failure
    }

    // 加载 UI 的方法
    public void LoadUI(GameResult result)
    {
        // 根据游戏结果加载对应的 UI Prefab
       
        GameObject uiPrefab = result == GameResult.Victory ? victoryUI : failUI;

        if (uiPrefab != null)
        {
            // 实例化 Prefab 并添加到场景中
            GameObject uiInstance = Instantiate(uiPrefab, Vector3.zero, Quaternion.identity);
            uiInstance.name = uiPrefab.name;  // 设置名称方便调试
        }
        else
        {
            Debug.LogError("UI Prefab not found ");
        }
    }

    // 示例：调用加载 UI 的方法
    public void EndGame(GameResult result)
    {
        // 加载对应的 UI
        LoadUI(result);

        // 可以在这里添加其他游戏结束的逻辑
    }
}