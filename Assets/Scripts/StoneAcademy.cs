using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class StoneAcademy : Academy
{
    private SpawnManager spawnManager;

    public override void InitializeAcademy()
    {
        if (spawnManager == null)
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }

        FloatProperties.RegisterCallback("bullet_speed", f => { spawnManager.bulletSpeed = 20; });
    }

    public override void AcademyStep()
    {
    }
}
