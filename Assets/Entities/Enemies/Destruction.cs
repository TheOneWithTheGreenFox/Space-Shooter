using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

    public GameObject EnemyLaserPrefab;
    public GameObject ExplosionPrefab;
    public int Health;

	// Use this for initialization
	void Start () {
        Health = 2;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health -= 1;
        if (Health <= 0)
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            formation.Score += 10;
            print(formation.Score);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Random.value < 0.001)
        {
            Instantiate(EnemyLaserPrefab, transform.position, Quaternion.identity);
        }
    }
}
