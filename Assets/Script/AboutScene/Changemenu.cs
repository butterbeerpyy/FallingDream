using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changemenu: MonoBehaviour
{
    public FadeManager fadeManager;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Sce2", 8f);
    }


    public void Sce2()
    {
        UnityEngine.Debug.Log("ooo");
        fadeManager.FadeOut(0);
    }


}
