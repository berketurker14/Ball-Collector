using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using GoogleMobileAds.Api;

public class BallSpawner : MonoBehaviour
    {
    public GameObject[] brick;
    float temp,g,c,b,a = 0;
    public Sprite[] Textures;
    public GameObject combo;
    int newHp=1;
    public int level;
    public Text leveltext;
    public Image perfectImage;
    public Image perfectBonus;
    public Image niceImage;
    public Image wpImage;
    public Image tryagainImage;
    public HeartSpawnie heart;
    public GameObject[] lasers;
    public PotionManager pM;
    public ShopButtons sB;
    public TextMeshProUGUI perfectText;
    InterstitialAd fulladmob;
    public Canvas shineCanvas;
    public float j = 0.01f, k = 1f;

    public void Start()
    {
        Spawner();
        leveltext.text = "" + level;
        pM = FindObjectOfType<PotionManager>();
        sB = FindObjectOfType<ShopButtons>();
        RequestFull();


    }

    public IEnumerator FadeImage(bool fadeAway, Image img)
    {
        if (fadeAway)
        {
            for (float i = 2; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
            img.color = new Color(1, 1, 1, 0);
        }
        else
        {
            for (float i = 0; i <= 2; i += Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
            img.color = new Color(1, 1, 1, 0);
        }
    }
    private void Update()
    {
        if (InactiveControl.inactive == 27 )
        {
            level++;
            if (combo.GetComponent<Slider>().value > 70)
            {
                pM.AddPotion(level);
                SoundManager.PlaySound("perfect");
                StartCoroutine(FadeImage(true, perfectImage));
                StartCoroutine(FadeImage(true, perfectBonus));
                perfectText.text = ""+((int)(1 + level / 10));
                pM.AddPotion((int)(1 + level / 10));
                perfectText.GetComponent<Animation>().Play("perfectmove");
            }
            else if (combo.GetComponent<Slider>().value > 35)
            {
                pM.AddPotion(level);
                SoundManager.PlaySound("nice");
                StartCoroutine(FadeImage(true, niceImage));
            }
            else if (combo.GetComponent<Slider>().value > 0 & level != 1)
            {
                pM.AddPotion(level);
                SoundManager.PlaySound("wellplayed");
                StartCoroutine(FadeImage(true, wpImage));
            }
            else if (combo.GetComponent<Slider>().value >= 0 & level == 1)
            {
                pM.AddPotion(level);
                SoundManager.PlaySound("wellplayed");
                StartCoroutine(FadeImage(true, wpImage));
            }
            Spawner();
            leveltext.text = ""+level;
            
        }

        if(combo.GetComponent<Slider>().value == 0 & level !=1)
        {
            level--;
            

            SoundManager.PlaySound("tryagain");
            StartCoroutine(FadeImage(true, tryagainImage));

            Spawner();
            leveltext.text = "" + level;
        }
    }

    void Spawner()
    {
        temp += 1;
        c = 0;
        g = 0;
        combo.GetComponent<Slider>().value = 100;
        sB.currentBall.transform.position = new Vector3(1, 3, -1);
        heart.isHeartOn = true;
        if (level == 0)
        {
            level++;
        }
        else 
        {
            newHp = level; 
        }
        
        for (int j = 0; j < 28; j++)
        {

            a = UnityEngine.Random.Range(0.0f, 1.0f);

            if (a > 0 & a < (0.0000536))
            {
                //legendary
                brick[j].GetComponent<SpriteRenderer>().sprite = Textures[4];
                brick[j].transform.GetChild(0).GetComponent<TextMesh>().text = ""+Math.Pow(newHp,2);
                brick[j].SetActive(true);
                brick[j].GetComponent<GoldAnim>().goldValue = level * level * level * level * level;

            }

            else if (a > 0.0000536 & a < 0.000143)
            {
                //purple
                brick[j].GetComponent<SpriteRenderer>().sprite = Textures[3];
                brick[j].transform.GetChild(0).GetComponent<TextMesh>().text = "" +Math.Round(newHp*5.1);
                brick[j].SetActive(true);
                brick[j].GetComponent<GoldAnim>().goldValue = level * level * level * level;
            }

            else if (a > 0.000143 & a < 0.00038)
            {
                brick[j].GetComponent<SpriteRenderer>().sprite = Textures[2];
                brick[j].transform.GetChild(0).GetComponent<TextMesh>().text = ""+Math.Round(newHp*2.3);
                brick[j].SetActive(true);
                brick[j].GetComponent<GoldAnim>().goldValue = level * level * level;
                //blue
            }

            else if (a > 0.00038 & a < 0.01)
            {
                brick[j].GetComponent<SpriteRenderer>().sprite = Textures[1];
                brick[j].transform.GetChild(0).GetComponent<TextMesh>().text = ""+Math.Round(newHp*1.5);
                brick[j].SetActive(true);
                brick[j].GetComponent<GoldAnim>().goldValue = level * level * 4;
                //green
            }
            
            else
            {
                brick[j].GetComponent<SpriteRenderer>().sprite = Textures[0];
                brick[j].transform.GetChild(0).GetComponent<TextMesh>().text = ""+newHp;
                brick[j].SetActive(true);
                brick[j].GetComponent<GoldAnim>().goldValue = level*level;
                //gray
            }

        }
        if (g == 0)
        {
            int z = (int)UnityEngine.Random.Range(9.0f, 24.0f);
            brick[z].GetComponent<SpriteRenderer>().sprite = Textures[5];
            brick[z].transform.GetChild(0).GetComponent<TextMesh>().text = "" + newHp;
            brick[z].SetActive(true);
            g++;
        }
        if (temp >= 8)
        {
            StartCoroutine(Addie());
            temp = 0;
        }

        for (int k = 0; k < lasers.Length; k++)
        {
            b = UnityEngine.Random.Range(0.0f, 1.0f);

            if (b*level > 20 & c < Math.Log(level*4))
            {
                lasers[k].SetActive(true);
                c++;
            }
            else
            {
                lasers[k].SetActive(false);
            }

        }
            
    }
    void RequestFull()
    {
        string idFull = "ca-app-pub-2541398550104862/8826883641";
        fulladmob = new InterstitialAd(idFull);
        AdRequest adRequest = new AdRequest.Builder().Build();
        fulladmob.LoadAd(adRequest);
    }
    public void ShowFullAds()
    {
        if (fulladmob.IsLoaded())
        {
            fulladmob.Show();
            RequestFull();
        }
        else
        {
            RequestFull();
        }
    }



    IEnumerator Addie()
    {
        shineCanvas.GetComponent<Animation>().Play("adstitial");
        yield return new WaitForSeconds(1.5f);
        ShowFullAds();
    }




}

