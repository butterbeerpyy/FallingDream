using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PlayerCollisionHandler : MonoBehaviour
{
    public ArrowController arrowController;

    private bool isHandlingCollision = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isHandlingCollision && arrowController != null)
        {
            StartCoroutine(HandleCollision(other));
        }
    }

    IEnumerator HandleCollision(Collider2D other)
    {
        isHandlingCollision = true;

        // 检查当前目标是否匹配
        if (arrowController != null && arrowController.storyTags.Length > arrowController.currentStoryIndex)
        {
            string currentTargetTag = arrowController.storyTags[arrowController.currentStoryIndex];
            if (other.CompareTag(currentTargetTag))
            {
                //Debug.Log($"剧情触发：{other.gameObject.name}");

                // 触发剧情事件
                arrowController.OnStoryCollected();

                // 模拟触发间隔，防止连击
                yield return new WaitForSeconds(0.5f);
            }
        }

        isHandlingCollision = false;
    }
}
