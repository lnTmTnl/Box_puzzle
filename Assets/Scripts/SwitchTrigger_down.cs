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
    void OnTriggerStay(Collider other)    //ÿ֡����һ��OnTriggerStay()����
    {
        //Debug.Log(Time.time + "���ڴ������Ķ����ǣ�" + other.gameObject.name);
    }
    void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<InstanceController>().GridObj.Position += new Vector3(0, 1f, 0);
        SwitchObject.GetComponent<InstanceController>().GridObj.Position += new Vector3(0, 1f, 0);
    }
}
