using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridsController : MonoBehaviour
{
    static public List<Grid> GridsList { get; } = new List<Grid>();

    public void Init()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject Destination = GameObject.FindGameObjectWithTag("Destination");
        GameObject[] Boxs = GameObject.FindGameObjectsWithTag("Box");
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        GameObject []Switchs = GameObject.FindGameObjectsWithTag("Switch");


        GridsList.Clear();
        GridsList.Add(new Grid(Player.transform.position, Player));
        GridsList.Add(new Grid(Destination.transform.position, Destination));
        for (int i = 0; i < Boxs.Length; i++)
        {
            GridsList.Add(new Grid(Boxs[i].transform.position, Boxs[i]));
        }
        for (int i=0;i<Obstacles.Length;i++)
        {
            GridsList.Add(new Grid(Obstacles[i].transform.position, Obstacles[i]));
        }
        for (int i = 0; i < Switchs.Length; i++)
        {
            GridsList.Add(new Grid(Switchs[i].transform.position, Switchs[i]));
        }
/*        for (int i = 0; i < Pads.Length; i++)
        {
            GridsList.Add(new Grid(Pads[i].transform.position, Pads[i]));
        }*/

        /*for(int i=0;i< GridsList.Count;i++)
        {
            Debug.Log(GridsList[i].PlacedGameObj.transform.position);
        }*/
        //Debug.Log(GridsList.Count);

    }

    static public Grid FindGridByPos(Vector3 position)
    {
        for(int i = 0; i < GridsList.Count; i++)
        {
            if (GridsList[i].Position == position && GridsList[i].PlacedGameObj.tag != "Player")
            {
                return GridsList[i];
            }
        }
        return null;
    }

    static public void Gravity()
    {
        for (int i = 0; i < GridsList.Count; i++)
        {
            //if (GridsList[i].PlacedGameObj.tag == "Switch"|| GridsList[i].PlacedGameObj.tag == "obstacle" || GridsList[i].PlacedGameObj.tag == "Player") continue;
            
            //按钮不受重力控制
            if (GridsList[i].PlacedGameObj.tag == "Switch") continue;
            while(FindGridByPos(GridsList[i].Position - new Vector3(0, 1, 0)) == null && GridsList[i].Position.y > -1)
            {
                GridsList[i].Position -= new Vector3(0, 1, 0);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
