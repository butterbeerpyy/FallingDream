using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using TarodevController;
//蹦床物体脚本
public class BouncePad : MonoBehaviour
{
    public float bounceForce = 20f;
    void Start()
    {
        if (!enabled)
        {
            enabled = true; // 确保脚本启用
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 假设人物的标签是 "Player"
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                if (player.IsFalling())
                {
                    player.Bounce(bounceForce);  // 调用玩家的 Bounce 方法
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetSpeedMultiplier(1.0f);  // 恢复正常速度
            }
        }
    }
}
