using UnityEngine;

public class StopMusicOnCollision : MonoBehaviour
{
    public BackgroundMusicController musicController; // 引用背景音乐控制器

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lotus"))
        {
            Debug.Log("Lotus detected! Stopping music.");
            if (musicController != null)
            {
                musicController.StopMusic(); // 直接调用背景音乐停止方法
            }
            else
            {
                Debug.LogError("MusicController reference is missing!");
            }
        }
    }
}
