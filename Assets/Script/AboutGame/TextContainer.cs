using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    public RectTransform container; // 挂载的容器（RectTransform）
    public string fullText;         // 完整的文字内容，每行用\n分隔
    public float lineInterval = 1f; // 每行文字之间的间隔时间
    public float fadeInDuration = 1f; // 每行文字渐变显示的时间
    public TextMeshProUGUI textPrefab; // TextMeshProUGUI组件的预制体（用于动态创建）
    public  float Hangjianju; 
    public float waitTimeAfterFastForward = 2f; // 快进后停留的时间

    public FadeManager fadeManager; // 用于场景切换
    private TextMeshProUGUI[] textObjects; // 存储所有动态创建的TextMeshPro组件
    private bool isDisplaying = false; // 是否正在显示剧情
    private bool isFastForwarding = false; // 是否处于快进状态
    public int sceneindex;

    private void Start()
    {
        // 初始化剧情文本
        textObjects = new TextMeshProUGUI[fullText.Split('n').Length];
        StartCoroutine(DisplayDialogue());
    }

    private IEnumerator DisplayDialogue()
    {
        if (isDisplaying) yield break; // 如果已经在显示剧情，直接退出
        isDisplaying = true;

        string[] lines = fullText.Split('n');
        for (int i = 0; i < lines.Length; i++)
        {
            if (isFastForwarding) // 如果处于快进状态，直接显示所有文本
            {
                ShowAllText(lines);
                yield break;
            }

            // 动态创建TextMeshPro组件
            TextMeshProUGUI newText = Instantiate(textPrefab, container);
            newText.text = lines[i]; // 设置当前行文字
            newText.color = new Color(newText.color.r, newText.color.g, newText.color.b, 0); // 初始透明度为0

            // 设置TextMeshPro组件的位置
            newText.rectTransform.anchoredPosition = new Vector2(0, -i * Hangjianju); // 每行向下偏移50像素

            // 透明度从0渐变到1
            newText.DOFade(1, fadeInDuration).SetEase(Ease.Linear);

            // 存储当前TextMeshPro组件
            textObjects[i] = newText;

            // 等待当前行文字渐变完成
            yield return new WaitForSeconds(fadeInDuration);

            // 等待行与行之间的间隔时间
            yield return new WaitForSeconds(lineInterval);
        }

        // 剧情显示完毕
        isDisplaying = false;
        fadeManager.FadeOut(sceneindex); // 触发场景切换
    }

    private void Update()
    {
        // 检测空格键按下
        if (Input.GetKeyDown(KeyCode.Space) && !isFastForwarding)
        {
            if (isDisplaying)
            {
                isFastForwarding = true; // 开启快进模式
            }
            else
            {
                StartCoroutine(DisplayDialogue()); // 重新开始剧情显示
            }
        }
    }

    // 快进显示所有剧情文本
    private void ShowAllText(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (textObjects[i] != null)
            {
                textObjects[i].DOFade(1, 0); // 立即显示文本
            }
            else
            {
                // 如果文本尚未创建，直接创建并显示
                TextMeshProUGUI newText = Instantiate(textPrefab, container);
                newText.text = lines[i];
                newText.color = new Color(newText.color.r, newText.color.g, newText.color.b, 1); // 设置为完全不透明
                newText.rectTransform.anchoredPosition = new Vector2(0, -i * Hangjianju); // 每行向下偏移50像素
            }
        }

        isFastForwarding = false; // 重置快进状态
        isDisplaying = false; // 重置显示状态

        // 添加延时，等待一段时间后切换场景
        StartCoroutine(WaitAndFadeOut());
    }

    // 延时后切换场景
    private IEnumerator WaitAndFadeOut()
    {
        yield return new WaitForSeconds(waitTimeAfterFastForward); // 等待指定时间
        fadeManager.FadeOut(sceneindex); // 触发场景切换
    }
}