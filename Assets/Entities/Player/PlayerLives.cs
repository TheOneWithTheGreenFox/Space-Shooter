using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {

    public GameObject PlayerLifePrefab;
    List<GameObject> lifeObjects = new List<GameObject>();
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(6, 6));
    }

    // Use this for initialization
    void Start () {
        
        foreach (Transform child in transform)
        {
            GameObject PlayerLife = Instantiate(PlayerLifePrefab, child.transform.position,Quaternion.identity);
            lifeObjects.Add(PlayerLife);
        }

    }

    // Update is called once per frame
    void Update () {
        if (PlayerMovement.lives == 2)
        {
            Destroy(lifeObjects[lifeObjects.Count - 1]);
        }
        else if (PlayerMovement.lives == 1)
        {
            Destroy(lifeObjects[lifeObjects.Count - 2]);
        }
        else if(PlayerMovement.lives == 0)
        {
            Destroy(lifeObjects[lifeObjects.Count - 3]);
        }
    }
}
