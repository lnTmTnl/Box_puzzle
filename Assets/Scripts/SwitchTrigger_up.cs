using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger_up : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //����player����ʱ�ܴ�����ť
        if(other.gameObject.tag=="Player")
        {
            gameObject.GetComponent<InstanceController>().GridObj.Position += new Vector3(0, 1f, 0);
            other.GetComponent<PlayerController>().SetCurrentPosition(other.GetComponent<PlayerController>().GetCurrentPosition() + new Vector3(0, 1f, 0));        }
        //Debug.Log(Time.time + "���ڴ������Ķ����ǣ�" + other.gameObject.name);
    }
    void OnTriggerStay(Collider other)    //ÿ֡����һ��OnTriggerStay()����
    {
        //Debug.Log(Time.time + "���ڴ������Ķ����ǣ�" + other.gameObject.name);
    }
    void OnTriggerExit(Collider other)
    {
        //����player����ʱ�ܴ�����ť
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<InstanceController>().GridObj.Position -= new Vector3(0, 1f, 0);
            if (GridsController.FindGridByPos(other.GetComponent<PlayerController>().GetCurrentPosition() - new Vector3(0, 1, 0)) == null)
            {
                other.GetComponent<PlayerController>().SetCurrentPosition(other.GetComponent<PlayerController>().GetCurrentPosition() - new Vector3(0, 1f, 0));
            }
        }
    }
}
