using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public FadeManager fadeManager;

    // Start is called before the first frame update
    void Start()
    {
        

            fadeManager.FadeIn();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}