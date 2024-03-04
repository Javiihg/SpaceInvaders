using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 120;
    public float maxSpeed = 200;
    public float minSpeed = 50;
    public float rootSpeed1 = 20;
    public float rootSpeed2 = 20;


    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (speed<=maxSpeed)
            {
                speed += 5; ;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (speed>=minSpeed)
            {
                speed -= 5; ;
            }
        }


        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * rootSpeed1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.back * rootSpeed2 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left * rootSpeed1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * rootSpeed2 * Time.deltaTime);
        }
    }
}
