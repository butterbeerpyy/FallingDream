using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundbh : MonoBehaviour
{
    void Start()
{
    if (!enabled)
    {
        enabled = true; // 确保脚本启用
    }
}
    void Update(){
        Debug.Log("aaaaa");
    }
    private void OnTriggerEnter(Collider other){
        Debug.Log("BBBBB");
        if(other.CompareTag("vase")){
            Debug.Log("AAAAA");
        }
    }
}
