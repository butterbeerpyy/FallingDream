using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class ReturnToMenu : MonoBehaviour
{
    public string menuSceneName = "Menu"; // Ä¿Â¼³¡¾°Ãû³Æ

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
          
            ReturnToMainMenu();
        }
    }

    void ReturnToMainMenu()
    {  UnityEngine.Debug.Log("1");
            SceneManager.LoadScene(menuSceneName);
    }
}
