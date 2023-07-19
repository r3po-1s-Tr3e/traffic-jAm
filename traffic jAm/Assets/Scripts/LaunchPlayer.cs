using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{
    Rigidbody Player;

    void Start()
    {
        Player = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.y <= 5.65f && pos.x == 0) 
            if (Input.GetKeyDown("space"))
            { {
                if (pos.y <= 5.65f && pos.y > 4.5f)
                {
                    Player.AddForce(new Vector3(15f, 70f, 0f), ForceMode.Impulse);
                }
                if (pos.y <= 4.5f && pos.y > 4f)
                {
                    Player.AddForce(new Vector3(40f, 60f, 0f), ForceMode.Impulse);
                }
                if (pos.y <= 4f && pos.y > 3f)
                {
                    Player.AddForce(new Vector3(80f, 70f, 0f), ForceMode.Impulse);
                }
                if (pos.y <= 3f && pos.y > 2.5f)
                {
                    Player.AddForce(new Vector3(60f, 45f, 0f), ForceMode.Impulse);
                }
                if (pos.y <= 2.5f)
                {
                    Player.AddForce(new Vector3(40f, 10f, 0f), ForceMode.Impulse);
                }
            } }
        

        if (pos.x >= 0.1)
        {
            Player.AddForce(new Vector3(0f, -((Player.mass * 9.81f)/5f), 0f));
        } 
    }
}
