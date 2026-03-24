using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player 碰撞到物体，准备切换场景...");
            StartCoroutine(SwitchScene());
        }
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(6);
    }
}
