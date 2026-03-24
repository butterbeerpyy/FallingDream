using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gobaba : MonoBehaviour
{
    public FadeManager fadeManager;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Sce", 12f);
    }


    public void Sce()
    {
        UnityEngine.Debug.Log("ooo");
        fadeManager.FadeOut(8);

    }


}
