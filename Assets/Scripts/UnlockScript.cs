using UnityEngine;
using UnityEngine.UI;

public class UnlockScript : MonoBehaviour
{

    //parayı çek-fiyatla kıyasla-fazlaysa yeşile boya-tıklanırsa parayı azalt


    public double[]prices;
    public int level = 0;
    public GameObject redPlus;
    public GameObject greenPlus;
    public GameObject bluePlus;
    float potion;
    public Text price;
    public PotionManager thePM;
    public GameObject[] needs;

    // Start is called before the first frame update
    void Start()
    {
        prices = new double[6];
        prices[0] = 10;
        prices[1] = 60;
        prices[2] = 180;
        prices[3] = 560;
        prices[4] = 1120;
        prices[5] = 3600;

        GeneralCheckZ();
        GetComponent<Button>().onClick.AddListener(Upgrade);
        thePM = FindObjectOfType<PotionManager>();

        for (int i = 1; i < 5; i++)
        {
            if (level == i)
            {
                needs[i-1].SetActive(true);
            }
        }
    }


    public void Upgrade()
    {

        if (level != 6)
        {
            potion = thePM.currentPotion;
            level += 1;


            if (level == 1)
            {
                redPlus.GetComponent<Button>().interactable = true;
                thePM.AddPotion(-10);
                price.GetComponent<Text>().text = "60";
                needs[0].SetActive(true);

            }
            if (level == 2)
            {
                needs[0].SetActive(false);
                greenPlus.GetComponent<Button>().interactable = true;
                thePM.AddPotion(-60);
                price.GetComponent<Text>().text = "180";
                needs[1].SetActive(true);
            }

            if (level == 3)
            {
                needs[1].SetActive(false);
                bluePlus.GetComponent<Button>().interactable = true;
                thePM.AddPotion(-180);
                price.GetComponent<Text>().text = "560";
                needs[2].SetActive(true);
            }

            if (level == 4)
            {
                needs[2].SetActive(false);
                redPlus.GetComponent<Button>().interactable = true;
                thePM.AddPotion(-560);
                price.GetComponent<Text>().text = "1120";
                needs[3].SetActive(true);
            }
            if (level == 5)
            {
                needs[3].SetActive(false);
                greenPlus.GetComponent<Button>().interactable = true;
                thePM.AddPotion(-1120);
                price.GetComponent<Text>().text = "3600";
                needs[4].SetActive(true);
            }

            if (level == 6)
            {
                bluePlus.GetComponent<Button>().interactable = true;
                GetComponent<Button>().interactable = false;
                price.GetComponent<Text>().text = "Limit";
                thePM.AddPotion(-3600);
            }
            potion = thePM.currentPotion;

        }



    }

    public void GeneralCheckZ()
    {
        if (level == 1)
        {
            price.GetComponent<Text>().text = "60";
        }
        if (level == 2)
        {
            price.GetComponent<Text>().text = "180";
        }

        if (level == 3)
        {
            price.GetComponent<Text>().text = "560";
        }

        if (level == 4)
        {
            price.GetComponent<Text>().text = "1120";
        }
        if (level == 5)
        {

            price.GetComponent<Text>().text = "3600";
        }

        if (level == 6)
        {
            GetComponent<Button>().interactable = false;
            price.GetComponent<Text>().text = "Limit";
        }
    }
}

