using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VaseBreaker : MonoBehaviour
{
    public GameObject vaseShardPrefab;  // 碎片预制体
    public AudioClip breakSound;        // 在 Inspector 中拖入的音效
    private AudioSource audioSource;    // AudioSource 组件
    private int Flag = 0;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>(); // 获取 AudioSource 组件
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // 如果没有，动态添加
        }
        audioSource.playOnAwake = false; // 防止自动播放
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            BreakVase();
        }
    }
    public FadeManager fadeManager;
    private void BreakVase()
    {
        
            audioSource.PlayOneShot(breakSound);

        // 在花瓶原来的位置生成碎片图片
        if (vaseShardPrefab != null && Flag==0)
        {
            Instantiate(vaseShardPrefab, transform.position, Quaternion.identity);
        }
        Invoke("Sce", 1f);
        Flag = 1;
        // 销毁花瓶对象
        Destroy(gameObject, 2.0f); // 延迟 2 秒后销毁花瓶
    }
    public void Sce()
    {
        UnityEngine.Debug.Log("ooo");
        SceneManager.LoadScene(3);
    }
 /*  IEnumerator WaitAndLoadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.Debug.Log("AAA");
        SceneManager.LoadScene(3); // 2 秒后加载场景
    }*/
}
