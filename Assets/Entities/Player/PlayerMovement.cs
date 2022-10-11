using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour {
    //variables
    public GameObject laserPrefab;
    public GameObject ExplosionPrefab;
    public GameObject PortalPrefab;
    public AudioClip EngineSound;
    public AudioClip OutOfAmmo;
    float Speed = 0.2f;
    float Xmin;
    float Xmax;
    float Ymin;
    float Ymax;
    public static int lives = 3;
    int Ammo = 10;
    public TextMeshProUGUI ammoText;

    // Use this for initialization
    void Start () {
        Instantiate(PortalPrefab, transform.position, Quaternion.identity);
        lives = 3;
        ammoText.text = Ammo.ToString();
        //Code to lock player position to the camera
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        Vector3 topmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 bottommost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        Xmin = leftmost.x;
        Xmax = rightmost.x;
        Ymin = topmost.y;
        Ymax = bottommost.y;
        
    }

    //Detects collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives -= 1;
        print(lives);
        Instantiate(PortalPrefab, transform.position, Quaternion.identity);
        transform.position = new Vector3(0, -5, 0);
        Instantiate(PortalPrefab, transform.position, Quaternion.identity);
        if (lives == 0)
        {
            Destroy(gameObject, 0.4f);
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Application.LoadLevel("Lose");
        }
    }

    // Update is called once per frame
    void Update(){
        //firing controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Ammo > 0)
            {
                Instantiate(laserPrefab, transform.position, Quaternion.identity);
                Ammo -= 1;
                ammoText.text = Ammo.ToString();
            }
            if (Ammo == 0)
            {
                AudioSource.PlayClipAtPoint(OutOfAmmo, transform.position);
                ammoText.text = "Reloading";
            }
        }
        if (Ammo == 0)
        {
            Invoke("Recharge", 1);
        }

        //Win detection
        if(formation.Score == 180)
        {
            Application.LoadLevel("Win");
        }
    }

    public void Recharge()
    {
        Ammo = 10;
        ammoText.text = Ammo.ToString();
    }

    //FixedUpdate is called a set number of time per second
    void FixedUpdate(){
        //player movement
        //Pressing shift increases speed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = 0.4f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = 0.2f;
        }
        //Code to allow Y movement
        //Arrows
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += new Vector3(0, 1, 0) * Speed;
        //    AudioSource.PlayClipAtPoint(EngineSound, transform.position);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += new Vector3(0, -1, 0) * Speed;
        //    AudioSource.PlayClipAtPoint(EngineSound, transform.position);
        //}
        ////WASD
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += new Vector3(0, 1, 0) * Speed;
        //    AudioSource.PlayClipAtPoint(EngineSound, transform.position);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += new Vector3(0, -1, 0) * Speed;
        //    AudioSource.PlayClipAtPoint(EngineSound, transform.position);
        //}
        //X movement
        //Arrows
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * Speed;
            AudioSource.PlayClipAtPoint(EngineSound, transform.position);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0) * Speed;
            AudioSource.PlayClipAtPoint(EngineSound, transform.position);
        }
        //WASD
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Speed;
            AudioSource.PlayClipAtPoint(EngineSound, transform.position);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * Speed;
            AudioSource.PlayClipAtPoint(EngineSound, transform.position);
        }

        //Code to lock player position to the camera
        float PlayerX = Mathf.Clamp(transform.position.x, Xmin, Xmax);
        transform.position = new Vector3(PlayerX, transform.position.y, transform.position.z);
        float PlayerY = Mathf.Clamp(transform.position.y, Ymin, Ymax);
        transform.position = new Vector3(transform.position.x, PlayerY, transform.position.z);
    }
}

