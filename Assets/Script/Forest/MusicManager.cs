
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play(); // 场景开始时播放音乐
        }
        else
        {
            Debug.LogError("AudioSource is missing on " + gameObject.name);
        }
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("Background music stopped.");
        }
    }
}
