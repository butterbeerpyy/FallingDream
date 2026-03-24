using UnityEngine;

public class Block : MonoBehaviour
{
    // 方块的编号，用于标记顺序
    public int blockID;

    // 引用音效文件
    public AudioClip soundClip;

    // 引用全局的 AudioSource 组件
    public AudioSource audioSource;

    // 管理器引用，用于通知顺序
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检测玩家进入触发器
        if (collision.CompareTag("Player"))
        {
            // 播放音效
            if (soundClip != null && audioSource != null)
            {
                audioSource.clip = soundClip;
                audioSource.Play();
                Debug.Log(blockID);
            }

            // 通知管理器玩家踩到了方块
            levelManager.PlayerStepOnBlock(blockID);
        }
    }
}