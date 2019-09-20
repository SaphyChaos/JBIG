using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCheck : MonoBehaviour
{
    public charControl myChar;
    public GameObject[] innerWalls;
    public bool inWall;
    public bool canCling;
    public bool wallCling;
    void OnTriggerEnter2D(Collider2D wallBox)
    {
        //print(groundBox.otherCollider);
        if (wallBox.tag == "wallInner")
        {
            if(myChar.jumping == false)
                inWall = true;
        }
        if(wallBox.tag == "wall")
        {
            print("f");
        }
    }
    void OnTriggerExit2D(Collider2D wallBox)
    {
        if (wallBox.tag == "wallInner")
        {
            inWall = false;
        }
        if (wallBox.tag == "wall")
        {
            print("e");
        }
        //print(groundBox.collider);
        //print(groundBox.otherCollider);
    }
    // Start is called before the first frame update
    void Start()
    {
        innerWalls = GameObject.FindGameObjectsWithTag("wallInner");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myChar.climbing == false && inWall == false && myChar.jumping == true)
        {
            for(int i = 0; i < innerWalls.Length; i++)
            {
                innerWalls[i].GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
        else
        {
            for (int i = 0; i < innerWalls.Length; i++)
            {
                innerWalls[i].GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }
}
