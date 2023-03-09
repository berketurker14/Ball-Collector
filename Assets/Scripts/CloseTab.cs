using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseTab : MonoBehaviour
{
    public GameObject image;

    public void closeImage()
    {
        image.SetActive(false);
    }

}
