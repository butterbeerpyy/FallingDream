using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change34 : MonoBehaviour
{
    public FadeManager fadeManager;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Sce", 8f);
    }


    public void Sce()
    {
        UnityEngine.Debug.Log("ooo");
        fadeManager.FadeOut(4);

    }


}
