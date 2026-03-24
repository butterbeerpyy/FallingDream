using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    //public string menuSceneName = "MenuScene";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 根据需要选择以下两种方式之一
            // 1. 切换到目录页场景
            // SceneManager.LoadScene(menuSceneName);

            // 2. 显示目录页UI
            // if (menuUI != null)
            //{
            SceneManager.LoadScene(0);
            //menuUI.SetActive(true);
            // }
        }
    }
}