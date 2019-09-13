using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControl : MonoBehaviour
{
    public GameObject protag;
    public float speed;
    public float maxSpeed;
    public float accel;
    public float dashMax;
    public float decel;
    public float dashDecel;
    public float jogMax;
    // Start is called before the first frame update
    void Start()
    {
        /*
        protag = GameObject.Find("protag");
        maxSpeed = .05f;
        accel = .02f;
        dashMax = .1f;
        decel = .01f;
        jogMax = .05f;
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)// && speed < maxSpeed)
        {
            speed += accel;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)// && Mathf.Abs(speed) < maxSpeed)
        {
            speed -= accel;
            if (Mathf.Abs(speed) > maxSpeed)
            {
                speed = -maxSpeed;
            }
        }
        else
        {
            if (speed > 0) speed -= decel;
            else if (speed < 0) speed += decel;
        }
        if(speed == 0)
        {
            maxSpeed = dashMax;//not moving resets dashing
        }
        else
        {
            if(maxSpeed > jogMax)
            {
                maxSpeed -= dashDecel;//maybe this shouldn't be the same variable
            }
        }
        if(maxSpeed < jogMax)
        {
            maxSpeed = jogMax;//jogMax is the slowest maxSpeed
        }
        /*
        if(speed > maxSpeed)
        {
            speed -= .01f;
        }
        else if(speed < -maxSpeed)
        {
            speed += .01f;
        }
        */
        print(speed);
        protag.transform.position = new Vector3(protag.transform.position.x + speed, protag.transform.position.y, protag.transform.position.z);
    }
}
