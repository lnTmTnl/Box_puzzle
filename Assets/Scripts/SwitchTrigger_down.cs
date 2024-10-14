using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger_down : MonoBehaviour
{
    public GameObject SwitchObject;
    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<InstanceController>().GridObj.Position -= new Vector3(0, 1f, 0);
        SwitchObject.GetComponent<InstanceController>().GridObj.Position -= new Vector3(0, 1f, 0);
    }
    void OnTriggerStay(Collider other)    //每帧调用一次OnTriggerStay()函数
    {
        //Debug.Log(Time.time + "留在触发器的对象是：" + other.gameObject.name);
    }
    void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<InstanceController>().GridObj.Position += new Vector3(0, 1f, 0);
        SwitchObject.GetComponent<InstanceController>().GridObj.Position += new Vector3(0, 1f, 0);
    }
}
