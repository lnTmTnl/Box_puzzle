using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InstanceController : MonoBehaviour
{
    public Grid GridObj { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position != GridObj.Position)   
        {
            gameObject.transform.DOMove(GridObj.Position, 0.25f);
/*
            Debug.Log("¶¯");
            Debug.Log(gameObject.transform.position);
            Debug.Log(GridObj.Position);*/
            //Time.timeScale = 0;
            //gameObject.transform.position = GridObj.Position;
        }
    }
}
