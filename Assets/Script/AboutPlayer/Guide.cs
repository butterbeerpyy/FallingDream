using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform player;
    public  string[] storyTags = { "Story1", "Story2", "Story3", "Story4" };
    public  string aimTag = "Aim";
    public GameProgressUI storyProgressUI;
    public GameObject uiPrefab;

    public  int currentStoryIndex = 0;
    public Transform currentTarget;
    public bool allTargetsCollected = false;

    void Start()
    {
        FindNextTarget(); // 初始时找到第一个目标
    }

    void Update()
    {
        if (currentTarget == null)
        {
            FindNextTarget();
        }
        else
        {
            // 平滑指向当前目标
            Vector2 direction = (currentTarget.position - player.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle -= 90f;

            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

            // 将箭头位置锁定在 player 的上方
            Vector3 offset = new Vector3(0, 3f, 0);
            transform.position = player.position + offset;
        }
    }

    // 供外部调用，更新目标状态
    public void OnStoryCollected()
    {
        if (currentStoryIndex < storyTags.Length)
        {
            if (storyProgressUI != null)
            {
                storyProgressUI.UnlockStory(storyTags[currentStoryIndex]);
            }
            currentStoryIndex++;

            if (currentStoryIndex >= storyTags.Length)
            {
                allTargetsCollected = true;
                FindNextTarget(); // 重新指向 aim
            }
            else
            {
                Invoke(nameof(FindNextTarget), 1f);
            }
        }
    }

    void FindNextTarget()
    {
        if (allTargetsCollected)
        {
            // 如果已经收集所有目标，则指向 aim
            GameObject aimObject = GameObject.FindWithTag(aimTag);
            if (aimObject != null)
            {
                currentTarget = aimObject.transform;
                ShowCompletionMessage();
            }
            return;
        }

        if (currentStoryIndex < storyTags.Length)
        {
            GameObject targetObject = GameObject.FindWithTag(storyTags[currentStoryIndex]);
            if (targetObject != null)
            {
                currentTarget = targetObject.transform;
            }
        }
    }

    void ShowCompletionMessage()
    {
        if (uiPrefab != null)
        {
            GameObject message = Instantiate(uiPrefab, GameObject.Find("Canvas").transform);
            message.GetComponent<UnityEngine.UI.Text>().text = "已收集本地图所有剧情碎片，现在奔向结局吧";

            // 2 秒后销毁提示
            Destroy(message, 2f);
        }
    }
}
