using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControl : MonoBehaviour
{
    public GameObject protag;
    public float speed;
    public float maxSpeed;
    public float groundAccel;
    public float accel;
    public float dashMax;
    public float decel;
    public float dashDecel;
    public float jogMax;
    public bool jumping;
    public bool grounded;
    public bool squat;
    public int squatFrames;
    private int squatCounter;
    public float jumpAccel;
    public float jumpSpeed;
    public float gravityAccel;
    public float termVel;
    public float airAccel;
    //public GameObject groundBox;
    public Collider2D groundBox;
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
    void OnCollisionEnter2D(Collision2D groundBox)
    {
        //print("ground");
        grounded = true;
        jumping = false;
        accel = groundAccel;
    }
    void jump(bool shortHop)
    {
        if (shortHop)
            jumpSpeed = jumpAccel;
        else
            jumpSpeed = jumpAccel*1.5f;
    }
    void OnCollisionExit2D(Collision2D groundBox)
    {
        grounded = false;
        jumping = true;
        accel = airAccel;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (squat)
        {
            squatCounter += 1;
            if(squatCounter > squatFrames)
            {
                squat = false;
                jumping = true;
                grounded = false;
                if (Input.GetAxisRaw("Jump") > 0)
                {
                    jump(false);
                }
                else
                {
                    jump(true);
                }
            }
            return;
        }
        else
        {
            squatCounter = 0;
        }
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
            if (grounded == true && squat == false)
            {
                if (Mathf.Abs(speed) < decel)
                {
                    speed = 0;
                }
                if (speed > 0) speed -= decel;
                else if (speed < 0) speed += decel;
            }
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
        //print(speed);

        if (jumping)
        {
            protag.transform.position = new Vector3(protag.transform.position.x + (speed), protag.transform.position.y + jumpSpeed, protag.transform.position.z);
            jumpSpeed -= gravityAccel;
            if(jumpSpeed < termVel)
            {
                jumpSpeed = termVel;
            }
        }
        else
        {
            protag.transform.position = new Vector3(protag.transform.position.x + speed, protag.transform.position.y, protag.transform.position.z);
            if (speed < 0)
            {
                transform.localScale = new Vector3(-1.5f, 1.5f, 1);

            }
            else if (speed > 0)
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 1);
            }
        }
        if (Input.GetAxisRaw("Jump") > 0 && grounded == true && squat == false)
        {
            squat = true;
        }
    }
}
