using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using System;

public enum CURRENTCELL { LEFT, RIGHT }

public class PlayerAgent : Agent
{
    private RayPerception m_RayPer;

    public GameObject[] cells;
    public GameObject spawnManager;
    public GameObject bullet;
    GridMovement gridScript;


    public override void InitializeAgent()
    {
        m_RayPer = GetComponent<RayPerception>();
        gridScript = GetComponent<GridMovement>();
    }

    public override void CollectObservations()
    {
        //AddVectorObs(transform.position);  

        AddVectorObs(transform.position - bullet.transform.position);
        AddVectorObs((transform.position - bullet.transform.position).normalized);
        //const float rayDistance = 12f;
        //float[] rayAngles = { 90f };

        //string[] detectableObjects = { "Bullet" };
        //List<float> rayobs = m_RayPer.Perceive(rayDistance, rayAngles, detectableObjects, 0.7f, 0.7f);
        //AddVectorObs(rayobs);
    }

    public override void AgentAction(float[] vectorAction)
    {
        // 1 is left, 2 is right
        var movement = (int)vectorAction[0];

        Move(movement);
    }

    private void Move(int movement)
    {
        int newMovement = -1;
        if (movement == 1)
        {
            newMovement = gridScript.move(DIRECTION.LEFT);
        }

        else if (movement == 2)
        {
            newMovement = gridScript.move(DIRECTION.RIGHT);
        }

        else if(movement == 3)
        {
            newMovement = gridScript.move(DIRECTION.UP);
        }

        else if(movement == 4)
        {
            newMovement = gridScript.move(DIRECTION.DOWN);
        }

        if (newMovement != -1)
        {
            transform.position = cells[newMovement].transform.position;
        }
    }

    public override float[] Heuristic()
    {
        if (Input.GetKey(KeyCode.D))
        {
            return new float[] { 2 };
        }
        if (Input.GetKey(KeyCode.A))
        {
            return new float[] { 1 };
        }
        if (Input.GetKey(KeyCode.W))
        {
            return new float[] { 3 };
        }

        if (Input.GetKey(KeyCode.S))
        {
            return new float[] { 4 };
        }
        return new float[] { 0 };
    }

    public override void AgentReset()
    {
        gameObject.transform.position = cells[3].transform.position;

        spawnManager.GetComponent<SpawnManager>().SpawnBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            AddReward(-1f);
            Done();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void SuccessfullyDodged()
    {
        AddReward(2f);
    }

    public override void AgentOnDone()
    {
        base.AgentOnDone();
    }
}
