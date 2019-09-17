using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    public charControl myCharScript;
    public Animator myAnim;
    /*
    public AnimationClip idle;
    public AnimationClip run;
    public AnimationClip squat;
    public AnimationClip jump;
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myCharScript.squat == true)
        {
            myAnim.Play("squat");
        }
        else if(myCharScript.jumping == true)
        {
            myAnim.Play("jump");
        }
        else if(Mathf.Abs(myCharScript.speed) > 0)
        {
            myAnim.Play("running");
        }
        else
        {
            myAnim.Play("idle");
        }
    }
}
