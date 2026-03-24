using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TarodevController;
//减速带物体脚本
public class SlowZone : MonoBehaviour
{
    void Start()
    {
        if (!enabled)
        {
            enabled = true; // 确保脚本启用
        }
    }
    public float slowMultiplier = 0.1f;  // 减速倍数
    private void OnTriggerStay2D(Collider2D other)
    {
        UnityEngine.Debug.Log("Triggered!!!!!!");
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetSpeedMultiplier(slowMultiplier);  // 设置减速倍数
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
