using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxDisplay : MonoBehaviour
{

    public Box box;
    public Image artWorkImage;

    void Start()
    {
        artWorkImage.sprite = box.artWork;


        
    }


}
