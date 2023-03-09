using UnityEngine;
using UnityEngine.UI;

public class TouchReduce : MonoBehaviour
{
    public GameObject ballFind;
    public Vector3 ballPos;
    public Slider slidy;



    public void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            slidy.value -= 0.2f;
            Touch touch = Input.GetTouch(0);
            Vector3 touchposition = Camera.main.ScreenToWorldPoint(touch.position);
            touchposition.z = 0;
            ballPos = ballFind.GetComponent<ShopButtons>().currentBall.GetComponent<Transform>().position;

            if ((touchposition - ballPos).magnitude > 1.2)
            {
                ballFind.GetComponent<ShopButtons>().currentBall.GetComponent<Rigidbody2D>().velocity = 14 * (touchposition - ballPos);

            }
        }




    }
}