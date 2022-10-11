using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
    int timer = 1;
	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
       Destroy(gameObject, 0.4f);
    }
    // Update is called once per frame
    void Update () {
        
	}
}
