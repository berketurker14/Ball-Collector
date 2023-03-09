using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    public GameObject soundObject;
    public GameObject cross;

    public void Start()
    {
        if (PlayerPrefs.HasKey("musicMuted"))
        {
            if (PlayerPrefs.GetInt("musicMuted") == 0)
            {
                soundObject.GetComponent<AudioSource>().volume = 100;
                cross.SetActive(false);
            }
            if (PlayerPrefs.GetInt("musicMuted") == 1)
            {
                soundObject.GetComponent<AudioSource>().volume = 0;
                cross.SetActive(true);
            }
        }

    }
    public void Mute()
    {
        if (soundObject.GetComponent<AudioSource>().volume == 0)
        {
            PlayerPrefs.SetInt("musicMuted", 0);
            cross.SetActive(false);
            soundObject.GetComponent<AudioSource>().volume = 100;
        }
        else
        {
            PlayerPrefs.SetInt("musicMuted", 1);
            cross.SetActive(true);
            soundObject.GetComponent<AudioSource>().volume = 0;
        }
    }
}
