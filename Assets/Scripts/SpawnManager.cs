using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    int size;
    public GameObject[] spawnPoints;
    public GameObject bullet;
    public PlayerAgent playerAgent;

    [HideInInspector]
    public float bulletSpeed = 20;
    public TextMeshPro cumulativeRewardText;

    // Start is called before the first frame update
    void Start()
    {
        size = spawnPoints.Length;
        SpawnBullet();
    }

    public void SpawnBullet()
    {
        int num = UnityEngine.Random.Range(0, size);
        Vector3 position = spawnPoints[num].transform.position;
        bullet.transform.position = position;
        bullet.GetComponent<Bullet>().spawnPoint = spawnPoints[num];
        bullet.GetComponent<Bullet>().speed = bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        cumulativeRewardText.text = playerAgent.GetCumulativeReward().ToString("0.00");
    }
}
