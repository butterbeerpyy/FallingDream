using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    // 指定的正确顺序
    private int[] correctOrder = { 1,2,3,2,1,  1,2,3,2,4,  4,5,6,  6,5,4,3,2,3,4};
    public bool IsVictory = false;
    private int flag = 0;
    // 当前玩家踩到的方块顺序
    private List<int> currentOrder = new List<int>();

    // 胜利提示
    //public GameObject victoryPanel;

    // 引用 UIManager
    public UIManager uiManager;

    private void Start()
    {
        // 初始化
        currentOrder.Clear();
        //victoryPanel.SetActive(false);

        // 检查 correctOrder 是否设置
        if (correctOrder == null || correctOrder.Length == 0)
        {
            Debug.LogError("Correct Order is not set!");
        }
    }

    // 玩家踩到方块时调用
    public void PlayerStepOnBlock(int blockID)
    {
        // 添加当前方块到顺序列表
        currentOrder.Add(blockID);
        //Debug.Log(blockID);
        if(blockID == 1){
            flag = 1;
        }
        else{
            flag = 0;
        }


        // 检查顺序是否正确
        if (IsOrderCorrect())
        {
            // 如果顺序正确，检查是否完成所有步骤
            if (currentOrder.Count == correctOrder.Length)
            {
                // 玩家胜利
                IsVictory = true;
                uiManager.SetBlockIndicatorActive(currentOrder.Count - 1);
            }
            else
            {
                // 更新对应的 UI 标识方块
                if (uiManager != null)
                {
                    uiManager.SetBlockIndicatorActive(currentOrder.Count - 1);
                }
            }
        }
        else
        {
            // 如果顺序错误，重置当前顺序
            currentOrder.Clear();
            if (uiManager != null && !IsVictory)
            {
                uiManager.ClearBlockIndicators();
            }
            if(flag == 1){
                currentOrder.Add(1);
                uiManager.SetBlockIndicatorActive(0);
            }
                

            Debug.Log("Order was incorrect. Please start over.");
        }
    }

    // 检查当前顺序是否正确
    private bool IsOrderCorrect()
    {
        // 确保当前顺序的长度不会超过正确顺序的长度
        if (currentOrder.Count > correctOrder.Length)
        {
            return false;
        }

        // 检查当前顺序是否与正确顺序一致
        for (int i = 0; i < currentOrder.Count; i++)
        {
            if (currentOrder[i] != correctOrder[i])
            {
                return false;
            }
        }
        return true;
    }

    // 胜利逻辑
    private void Victory()
    {
        //victoryPanel.SetActive(true);
        Debug.Log("Congratulations! You Win!");
    }
}