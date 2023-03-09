using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InactiveControl : MonoBehaviour
{
    public GameObject[] brick;
    public static int inactive;
    // Update is called once per frame
    void Update()
    {
        inactive = 0;
        for (int i = 0; i < 28; i++)
        {
            if (brick[i].activeSelf == false)
            {

                inactive += 1;
            }
        }
    }
}


