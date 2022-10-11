using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formation : MonoBehaviour {

    public GameObject enemy1Prefab;
    public bool movingRight = true;
    public static int Score;
    public float Enemyspeed = 0.5f;
    float Xmin;
    float Xmax;
    float Ymin;
    float Ymax;
    public float SpawnDelay = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(6, 6));
    }

    // Use this for initialization
    void Start() {
        Score = 0;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        Xmin = leftmost.x;
        Xmax = rightmost.x;
        //Vector3 topmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        //Vector3 bottommost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        //Ymin = topmost.y;
        //Ymax = bottommost.y;
    }

    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {  
            GameObject enemy1 = Instantiate(enemy1Prefab, child.position, Quaternion.identity) as GameObject;
            enemy1.transform.parent = child;
        }
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();

        if (freePosition)
        {
            GameObject enemy = Instantiate(enemy1Prefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;

        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", SpawnDelay);
        }
    }


    // Update is called once per frame
    void Update() {

        float FormationX = Mathf.Clamp(transform.position.x, Xmin, Xmax);
        transform.position = new Vector3(FormationX, transform.position.y, transform.position.z);
        //float PlayerY = Mathf.Clamp(transform.position.y, Ymin + 3, Ymax - 3);
        //transform.position = new Vector3(transform.position.x, PlayerY, transform.position.z);

        if (transform.position.x > Xmax - 2)
        {
            movingRight = false;
            transform.position += new Vector3(0, -0.1f * Enemyspeed, 0);
        }

        if (transform.position.x < Xmin + 2)
        {
            movingRight = true;
            transform.position += new Vector3(0, -0.1f * Enemyspeed, 0);
        }

        if (movingRight)
        {
            transform.position += new Vector3(0.15f * Enemyspeed, 0);
        }

        else
        {
            transform.position += new Vector3(-0.15f * Enemyspeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Enemyspeed = 2;
        }

        if (AllMembersDead())
        {
            Debug.Log("Empty Formation");
            SpawnUntilFull();
        }
    }
}