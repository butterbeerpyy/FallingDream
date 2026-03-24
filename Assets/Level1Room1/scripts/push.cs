/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    public float pushForce = 10f; // 推动的力度
    private Rigidbody objectToPush; // 当前接触的可推物体的 Rigidbody
    private bool isTouchingPushableObject = false; // 是否接触可推物体

    private void Update()
    {
        // 如果接触了可推物体，并且按下 A 或 D 键
        if (isTouchingPushableObject)
        {
            if (Input.GetKey(KeyCode.A)) // 按下 A 键向左推
            {
                PushObject(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.D)) // 按下 D 键向右推
            {
                PushObject(Vector3.right);
            }
        }
    }

    private void PushObject(Vector3 direction)
    {
        if (objectToPush != null)
        {
            // 使用 Rigidbody 推动物体
            objectToPush.AddForce(direction * pushForce, ForceMode.Force);
        }
    }

    // 检测角色是否接触可推物体
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pushable"))
        {
            objectToPush = other.GetComponent<Rigidbody>(); // 获取物体的 Rigidbody
            isTouchingPushableObject = true; // 标记为接触可推物体
        }
    }

    // 检测角色是否离开可推物体
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pushable"))
        {
            objectToPush = null; // 清空当前接触的物体
            isTouchingPushableObject = false; // 标记为未接触可推物体
        }
    }
}