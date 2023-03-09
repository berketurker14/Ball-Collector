using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public int tutorialCounter;
    [SerializeField]private GameObject hand1;
    [SerializeField]public GameObject hand2;
    [SerializeField]public GameObject hand3;

    public void Start()
    {
        if (PlayerPrefs.HasKey("tutorial"))
        {
            Destroy(gameObject);
        }

        else
        {
            gameObject.SetActive(true);
            PlayerPrefs.SetString("tutorial", "1");
        }
            

    }
    public void Next()
    {
        
            if (tutorialCounter == 0)
            {
            
            }

            if (tutorialCounter == 1)
            {
                hand1.SetActive(false);
                hand3.SetActive(true);
                tmp.text = "Hitting a brick gives you money (sometimes gems)";
            
            }

            if (tutorialCounter == 2)
            {
                hand3.SetActive(false);
                hand2.SetActive(true);
                tmp.text = "Your Lifetime Decreases every second.If it reaches 0 you will return to the level before";
            }

            if (tutorialCounter == 3)
            {
                tmp.text = "Everytime You Touch Somewhere You Lose Extra Lifetime!";
                hand2.SetActive(false);
            }

            if (tutorialCounter == 4)
            {
                tmp.text = "I think you will figure out the Upgrade Menu down below :)";
            }

            if (tutorialCounter == 5)
            {
                tmp.text = "Good Luck";
            }
            if(tutorialCounter == 6)
            {
                Destroy(gameObject);
            }

            tutorialCounter++;
    }
}
