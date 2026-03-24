//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class UIManager : MonoBehaviour
{
    // 引用标识方块的 Image 组件数组
    public UnityEngine.UI.Image[] blockIndicators;

    // 调整指定的标识方块为红色
    public void SetBlockIndicatorActive(int index)
    {
        if (index >= 0 && index < blockIndicators.Length)
        {
            blockIndicators[index].color = Color.green;
        }
        else
        {
            Debug.LogError("Index out of range for block indicators!");
        }
    }

    public void ClearBlockIndicators()
    {
        foreach (var indicator in blockIndicators)
        {
            indicator.color = Color.gray; // 将所有标识方块恢复为默认颜色（灰色）
        }
    }
}