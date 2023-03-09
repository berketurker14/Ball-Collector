using UnityEngine;

public class MuteSound : MonoBehaviour
{
    public GameObject soundObject;
    public GameObject cross;

    public void Start()
    {
        if (PlayerPrefs.HasKey("sfxMuted"))
        {
            if (PlayerPrefs.GetInt("sfxMuted") == 0)
            {
                soundObject.GetComponent<AudioSource>().volume = 100;
                cross.SetActive(false);
            }
            if (PlayerPrefs.GetInt("sfxMuted") == 1)
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
            PlayerPrefs.SetInt("sfxMuted", 0);
            cross.SetActive(false);
            soundObject.GetComponent<AudioSource>().volume = 100;
        }
        else
        {
            PlayerPrefs.SetInt("sfxMuted", 1);
            cross.SetActive(true);
            soundObject.GetComponent<AudioSource>().volume = 0;
        }
    }


}
