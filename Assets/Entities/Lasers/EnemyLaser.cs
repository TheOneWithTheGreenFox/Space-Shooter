using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour {

    public GameObject EnemtLaserPrefab;
    float LaserSpeed = 1;
    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            LaserSpeed = 2;
        }
    }

    void FixedUpdate()
    {
        //Laser movement
        transform.position += new Vector3(0, -0.1f * LaserSpeed, 0);

        if (transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
