using UnityEngine;
using DG.Tweening;

public class SpikeBlink : MonoBehaviour
{
    public float blinkDuration = 1f; // 闪烁周期
    public float minAlpha = 0.8f; // 最低透明度
    public float maxAlpha = 1.0f; // 最高透明度

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 启动闪烁动画（往返透明度变化）
        StartBlinking();
    }

    void StartBlinking()
    {
        // 使用 DOTween 做往返透明度动画
        spriteRenderer.DOFade(minAlpha, blinkDuration)
            .SetLoops(-1, LoopType.Yoyo) // 无限循环，Yoyo 表示来回
            .SetEase(Ease.InOutSine); // 平滑效果
    }
}
