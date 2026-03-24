using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class HealthSystem : MonoBehaviour
{
    public int health = 3; // 血量上限
    public GameObject[] hearts;  // 直接存储心形 GameObject
    public Sprite fullHeart; // 满血心
    public Sprite emptyHeart; // 空血心

    [Header("音效")]
    public AudioSource audioSource; // 用于播放音效
    public AudioClip hitSound; // 受击音效
    public AudioClip eatSound; // 吃苹果音效
    public AudioClip drinkSound;
    void Start()
    {
        health = 3;
        UpdateHearts();
        UpdateSpeed(); // 初始化时更新速率
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            PlaySound(hitSound);
            TakeDamage(1);
        }
        else if (collision.CompareTag("Eat"))
        {
            PlaySound(eatSound);
            Heal(1);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Drink"))
        {
            PlaySound(drinkSound);
            Heal(1);
            Destroy(collision.gameObject);
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            Invoke("StopSound", 2f);
        }
    }
    void StopSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        UpdateHearts();
        UpdateSpeed(); // 受伤后更新速率
    }

    void Heal(int amount)
    {
        health += amount;
        if (health > 3) health = 3;
        UpdateHearts();
        UpdateSpeed(); // 治疗后更新速率
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            UnityEngine.UI.Image heartImage = hearts[i].GetComponent<UnityEngine.UI.Image>(); // 获取 Image 组件
            if (heartImage != null)
            {
                heartImage.sprite = (i < health) ? fullHeart : emptyHeart;
            }
        }
    }

    void UpdateSpeed()
    {
        // 根据血量调整玩家速率
        if (health == 3)
            TarodevController.PlayerController.rate = 0.8f;
        else if (health == 2)
            TarodevController.PlayerController.rate = 0.5f;
        else if (health == 1)
            TarodevController.PlayerController.rate = 0.3f;
        else
            TarodevController.PlayerController.rate = 0.2f;
    }
}
