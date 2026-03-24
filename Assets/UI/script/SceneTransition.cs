/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f; // 淡入/淡出时间

    private void Start()
    {
        // 场景加载时，进行淡入效果
        FadeIn();
    }

    public void LoadScene(string sceneName)
    {
        // 启动淡出协程，淡出结束后加载场景
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    void FadeIn()
    {
        // 初始化 CanvasGroup 为全黑
        fadeCanvasGroup.alpha = 1;
        // 使用 DoTween 将透明度从 1 变化到 0（即淡入）
        fadeCanvasGroup.DOFade(0, fadeDuration).SetEase(Ease.InOutQuad);
    }

    System.Collections.IEnumerator FadeOutAndLoad(string sceneName)
    {
        // 使用 DoTween 进行淡出
        fadeCanvasGroup.DOFade(1, fadeDuration).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(fadeDuration);

        // 场景加载
        SceneManager.LoadScene(sceneName);
    }
}*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f; // 淡入淡出时间

    private void Start()
    {
        // 场景加载完成后，执行淡入效果
        FadeIn();
    }

    public void LoadScene(string sceneName)
    {
        // 启动淡出协程，淡出结束后加载场景
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    private void FadeIn()
    {
        // 初始透明度为 1（全黑）
        fadeCanvasGroup.alpha = 1;
        fadeCanvasGroup.DOFade(0, fadeDuration).SetEase(Ease.InOutQuad);
    }

    private System.Collections.IEnumerator FadeOutAndLoad(string sceneName)
    {
        // 执行淡出效果（透明度从 0 → 1）
        fadeCanvasGroup.DOFade(1, fadeDuration).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(fadeDuration);

        // 场景加载
        SceneManager.LoadScene(sceneName);
    }
}

