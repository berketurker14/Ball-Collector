using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserScript : MonoBehaviour
{
    public Slider slidey;

    public void Start()
    {
        slidey = FindObjectOfType<Slider>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            slidey.value -=100 ;
        }
    }
}
