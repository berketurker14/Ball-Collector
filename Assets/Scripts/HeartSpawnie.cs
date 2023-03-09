using UnityEngine;
using UnityEngine.UI;

public class HeartSpawnie : MonoBehaviour
{
    public GameObject[] hearts;
    public Slider slidy;
    public bool isHeartOn = true;

    void Update()
    {
        if (slidy.value < 45 & isHeartOn)
        {
            int rand = Random.Range(0,21);
            hearts[rand].SetActive(true);
            hearts[rand].GetComponent<PolygonCollider2D>().enabled = true;
            hearts[rand].GetComponent<Animator>().enabled = true;
            isHeartOn = false;
        }
    }
}
