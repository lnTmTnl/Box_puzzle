using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int GridSize { get; } = 1;
    public Vector3 Position { get; set; }
    public GameObject PlacedGameObj { get; set; }

    public Grid(Vector3 Position, GameObject PlacedGameObj)
    {
        this.Position = Position;
        this.PlacedGameObj = PlacedGameObj;
        if(this.PlacedGameObj.GetComponent<InstanceController>() != null)
        {
            this.PlacedGameObj.GetComponent<InstanceController>().GridObj = this;
        }
    }
}

/*public class Switch:Grid
{
    public bool isTrigger;
    public GameObject switchObject;
    public Switch(Vector3 Position, GameObject PlacedGameObj, GameObject switchObject) : base(Position, PlacedGameObj)
    {
        this.isTrigger = false;
        this.switchObject = switchObject;
    }
}
*/