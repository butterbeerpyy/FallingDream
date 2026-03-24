using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float MoveSpeed;
    public Transform Posa,Posb;
    private Transform MovePos;
    // Start is called before the first frame update
    void Start()
    {
        MovePos = Posa;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,Posa.position)<0.1f)
        {
            MovePos = Posb;
        }
        if(Vector2.Distance(transform.position,Posb.position)<0.1f)
        {
            MovePos = Posa;
        }
        transform.position = Vector2.MoveTowards(transform.position,MovePos.position,MoveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.parent = this.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.parent = null;
    }
}
