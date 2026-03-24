using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup; // 遮罩的 Canvas Group 组件
    public float fadeDuration = 1.0f;  // 渐变持续时间
    public int sceneindex;

    private bool isFading = false;

    // 渐出效果：从透明到不透明
    public void FadeOut(int sceneindex)
    {
        if (!isFading)
        {
            StartCoroutine(FadeOutRoutine(sceneindex));
        }
    }

    // 渐入效果：从不透明到透明
    public void FadeIn()
    {
        if (!isFading)
        {
            StartCoroutine(FadeInRoutine());
        }
    }

    IEnumerator FadeOutRoutine(int sceneindex)
    {


        isFading = true;
        float elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            fadeCanvasGroup.alpha = elapsedTime / fadeDuration;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeCanvasGroup.alpha = 1; // 完全不透明
        SceneManager.LoadScene(sceneindex); // 切换场景
        isFading = false;
    }

    IEnumerator FadeInRoutine()
    {

        isFading = true;
        float elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            fadeCanvasGroup.alpha = 1 - (elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeCanvasGroup.alpha = 0; // 完全透明
        isFading = false;
    }
}