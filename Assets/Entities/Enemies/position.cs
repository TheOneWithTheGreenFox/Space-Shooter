using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
