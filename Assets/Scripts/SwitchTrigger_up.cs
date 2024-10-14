using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger_up : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //仅当player经过时能触发按钮
        if(other.gameObject.tag=="Player")
        {
            gameObject.GetComponent<InstanceController>().GridObj.Position += new Vector3(0, 1f, 0);
            other.GetComponent<PlayerController>().SetCurrentPosition(other.GetComponent<PlayerController>().GetCurrentPosition() + new Vector3(0, 1f, 0));        }
        //Debug.Log(Time.time + "留在触发器的对象是：" + other.gameObject.name);
    }
    void OnTriggerStay(Collider other)    //每帧调用一次OnTriggerStay()函数
    {
        //Debug.Log(Time.time + "留在触发器的对象是：" + other.gameObject.name);
    }
    void OnTriggerExit(Collider other)
    {
        //仅当player经过时能触发按钮
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
