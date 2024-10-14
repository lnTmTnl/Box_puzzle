using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public GameObject PlayerInstance;
    private Vector3 currentPosition;
    private Vector3 currentRotation;
    private Vector3 nextStep;
    private Vector3 nextPosition;
    private Vector3 afterNextPosition;
    private Grid nextGrid;
    private Grid afterNextGrid;

    public void SetCurrentPosition(Vector3 position)
    {
        this.currentPosition = position;
    }
    public Vector3 GetCurrentPosition()
    {
        return this.currentPosition ;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!(GameController.gameState == GameState.Running))
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentRotation = new Vector3(0, -90, 0);

            nextStep = new Vector3(-1, 0, 0);
            UpdateFutureDatas();

            if (CheckStep())
            {
                //currentPosition += nextStep;
                Walk();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentRotation = new Vector3(0, 90, 0);

            nextStep = new Vector3(1, 0, 0);
            UpdateFutureDatas();

            if (CheckStep())
            {
                //currentPosition += nextStep;
                Walk();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentRotation = new Vector3(0, 180, 0);

            nextStep = new Vector3(0, 0, -1);
            UpdateFutureDatas();

            if (CheckStep())
            {
                //currentPosition += nextStep;
                Walk();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentRotation = new Vector3(0, 0, 0);

            nextStep = new Vector3(0, 0, 1);
            UpdateFutureDatas();

            if (CheckStep())
            {
                //currentPosition += nextStep;
                Walk();
            }
            //Debug.Log(currentPosition);
        }

        gameObject.GetComponent<InstanceController>().GridObj.Position = currentPosition;
        PlayerInstance.transform.DORotate(currentRotation, 0.1f);
        //PlayerInstance.transform.localEulerAngles = currentRotation;

        GridsController.Gravity();

        if(GameController.gameState != GameState.Finished && GridsController.FindGridByPos(currentPosition) != null && GridsController.FindGridByPos(currentPosition).PlacedGameObj.tag == "Destination")
        {
            GameController.gameState = GameState.BeforeFinish;
        }
        
    }

    private void UpdateFutureDatas()
    {
        currentPosition = gameObject.GetComponent<InstanceController>().GridObj.Position;
        nextPosition = currentPosition + nextStep;
        afterNextPosition = nextPosition + nextStep;
        nextGrid = GridsController.FindGridByPos(nextPosition);
        afterNextGrid = GridsController.FindGridByPos(afterNextPosition);
    }

    public bool CheckStep()
    {
        if (nextGrid == null)
        {
            return true;
        }
        else if(nextGrid.PlacedGameObj.tag == "Box")
        {
            if(afterNextGrid == null|| afterNextGrid.PlacedGameObj.tag == "Switch")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(nextGrid.PlacedGameObj.tag == "Destination")
        {
            return true;
        }
        else if(nextGrid.PlacedGameObj.tag == "Switch")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Walk()
    {
        if(nextGrid != null && nextGrid.PlacedGameObj.tag == "Box")
        {
            Grid nextUpGrid = GridsController.FindGridByPos(nextGrid.Position + new Vector3(0, 1, 0));
            if (nextUpGrid != null && nextUpGrid.PlacedGameObj.tag == "Box")
            {
                nextUpGrid.Position += nextStep;
            }
            nextGrid.Position += nextStep;
        }
        currentPosition += nextStep;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "WoodBox10")
        {
            Debug.Log(GridsController.FindGridByPos(collision.gameObject.transform.position + nextStep));
            collision.gameObject.transform.position += nextStep;
        }
    }*/

}
