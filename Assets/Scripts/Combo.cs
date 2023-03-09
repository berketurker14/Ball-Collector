using UnityEngine;
using UnityEngine.UI;
public class Combo : MonoBehaviour
{
    public int comboValue=0;
    public PauseManagement pauseManagement;
    void Update()
    {
        if (!pauseManagement.paused)
        {
            GetComponent<Slider>().value -= 0.05f;
        }
    }
}
