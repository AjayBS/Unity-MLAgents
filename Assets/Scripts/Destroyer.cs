using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject player;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        player.GetComponent<PlayerAgent>().SuccessfullyDodged();
        manager.GetComponent<SpawnManager>().SpawnBullet();
    }
}
