using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallScripts : MonoBehaviour
{
    int notCollided=0;
    // Update is called once per frame
    Vector3 targetvector =  new Vector3(2,3.464f, 0);
    public int magnitude = 5;
    Vector3 xrestrict = new Vector3(3, 3);


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.tag.Equals("Brick"))
        {
            notCollided += 1;

            if (notCollided > 4)
            {
                notCollided = 0;
                xrestrict = GetComponent<Rigidbody2D>().velocity;
                if (Math.Abs(xrestrict.x) < 1 || Math.Abs(xrestrict.y) < 1)
                {
                    GetComponent<Rigidbody2D>().velocity = magnitude * Vector3.Cross(GetComponent<Rigidbody2D>().velocity.normalized,(targetvector.normalized));
                }
                
            }

        }
        else
        {
            notCollided = 0;
        }
    }
}
