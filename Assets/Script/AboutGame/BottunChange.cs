using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public int index;
    public FadeManager fadeManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene()
    {
 
        // 使用SceneManager加载指定场景
        fadeManager.FadeOut(index);
    }

    public void quit()
    {
        UnityEngine.Debug.Log("quit");
        UnityEngine.Application.Quit();
    }
}
