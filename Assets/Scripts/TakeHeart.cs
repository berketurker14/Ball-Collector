using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeHeart : MonoBehaviour
{
    public Slider slimy;

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            slimy.value += 35;
            GetComponent<Animator>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
