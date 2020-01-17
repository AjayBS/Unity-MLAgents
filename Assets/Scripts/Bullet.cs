using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject spawnPoint;
    public GameObject manager;
    public GameObject player;
    public GameObject destroyer;
    public GameObject destroyer1;
    public GameObject destroyer2;
    public GameObject destroyer3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;
        transform.Translate(spawnPoint.transform.forward * Time.deltaTime * speed);
        if(transform.position.z < destroyer.transform.position.z || transform.position.x < destroyer1.transform.position.x 
            || transform.position.z > destroyer2.transform.position.z || transform.position.x > destroyer3.transform.position.x)
        {
            player.GetComponent<PlayerAgent>().SuccessfullyDodged();
            manager.GetComponent<SpawnManager>().SpawnBullet();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Destroyer")
        {
            player.GetComponent<PlayerAgent>().SuccessfullyDodged();
            manager.GetComponent<SpawnManager>().SpawnBullet();
        }
    }
}
