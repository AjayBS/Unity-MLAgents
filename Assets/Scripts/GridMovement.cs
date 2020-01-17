using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION { UP, DOWN, LEFT, RIGHT }

public class GridMovement : MonoBehaviour
{
    private bool canMove = true, moving = false;
    private int speed = 5, buttonCoolDown = 0;
    private DIRECTION verticalMovement;
    private DIRECTION horizontalMovement;
    int currentNumber;

    // Start is called before the first frame update
    void Start()
    {
        verticalMovement = DIRECTION.DOWN;
        horizontalMovement = DIRECTION.RIGHT;
        currentNumber = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int move(DIRECTION arrowPressed)
    {
        if (arrowPressed == horizontalMovement || arrowPressed == verticalMovement)
        {
            return -1;
        }

        if(arrowPressed == DIRECTION.LEFT)
        {
            horizontalMovement = arrowPressed;
            currentNumber = currentNumber - 1;
            return currentNumber;
        }

        if (arrowPressed == DIRECTION.RIGHT )
        {
            horizontalMovement = arrowPressed;
            currentNumber = currentNumber + 1;
            return currentNumber;
        }

        if (arrowPressed == DIRECTION.UP)
        {
            verticalMovement = arrowPressed;
            currentNumber = currentNumber - 2;
            return currentNumber;
        }

        if (arrowPressed == DIRECTION.DOWN)
        {
            verticalMovement = arrowPressed;
            currentNumber = currentNumber + 2;
            return currentNumber;
        }

        return -1;
    }
}
