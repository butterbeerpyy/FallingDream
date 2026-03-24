using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using TarodevController;
public class GlueCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("Trigged!!");
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>(); 
                
                //FadeManager.FadeOut(1);
                SceneManager.LoadScene(1);

           
        }
    }
}
