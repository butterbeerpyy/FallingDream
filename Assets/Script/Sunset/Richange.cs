using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Richange : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SwitchScene());
        }
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(6);
    }
}
