using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public GameObject laserPrefab;

    // Use this for initialization
    void Start () {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
        
    }

    void FixedUpdate(){
        //Laser movement
        transform.position += new Vector3(0, 1, 0);

        if (transform.position.y >= 7)
        {
            Destroy(gameObject);
        }
    }
}
