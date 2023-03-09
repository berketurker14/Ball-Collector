using System;
using UnityEngine;
using UnityEngine.UI;

public class DamageVelocityIdleUpgrade : MonoBehaviour
{
    public GameObject damageButton;
    public GameObject velocityButton;
    public GameObject idleButton;

    public Text damageText;
    public Text velocityText;
    public Text maxIdleText;

    public Image damageBar;
    public Image velocityBar;
    public Image idleBar;

    MoneyManager theMM;
    ShopButtons sBut;

    private double[] damagePrices = { 400, 1.6e3, 27e3 , 183e3 , 3.21e6 , 16.95e8 , 39.8e9 , 45.75e10 , 6.43e11 , 86e11 , 1.11e12 , 233.15e12 , 3.85e13 , 35e14 , 95e17 ,107e24};
    float c;
    public string[] ranks = { "K", "M", "B", "T", "Qu", "Qi", "Sx", "Sp", "Oc", "De", "Un", "Hk" };
    double gold;

    public int damageLevel;
    public int velocityLevel;
    public int idleLevel;
    public int maxIdleTime;

    public void Start()
    {
        theMM = FindObjectOfType<MoneyManager>();
        sBut = FindObjectOfType<ShopButtons>();
        damageBar.fillAmount = damageLevel * 0.06667f;
        velocityBar.fillAmount = velocityLevel * 0.06667f;
        idleBar.fillAmount = idleLevel * 0.06667f;
        maxIdleTime = idleLevel + 8;

        for (int i = 0; i < 12; i++)
        {
            c = (float)Math.Pow(10, 3 * (i + 1));

            if (damagePrices[damageLevel] > c)

            {
                damageText.text = "Lv:" + damageLevel + "\nUpgrade:" + (damagePrices[damageLevel] / c).ToString("F2") + ranks[i];
            }

            
        }
        for (int i = 0; i < 12; i++)
        {
            c = (float)Math.Pow(10, 3 * (i + 1));

            if (damagePrices[velocityLevel] > c)

            {
                velocityText.text = "Lv:" + velocityLevel + "\nUpgrade:" + (damagePrices[velocityLevel] / c).ToString("F2") + ranks[i];
            }
        }

    }
    public void DamageIncrease()
    {
        theMM.AddGold(-(float)damagePrices[damageLevel]);
        gold = PlayerPrefs.GetFloat("CurrentGold");
        damageLevel += 1;
        damageBar.fillAmount += 0.0667f;
        sBut.ObjectChanger();
        for (int i = 0; i < 12; i++)
        {
            c = (float)Math.Pow(10, 3 * (i + 1));

            if (damagePrices[damageLevel] > c)

            {
                
                damageText.text = "Lv:" + damageLevel + "\nUpgrade:" + (damagePrices[damageLevel]/c).ToString("F2") + ranks[i];
            }
        }
    }

    public void VelocityIncrease()
    {
        theMM.AddGold(-(float)damagePrices[velocityLevel]);
        gold = PlayerPrefs.GetFloat("CurrentGold");
        velocityLevel += 1;
        velocityBar.fillAmount += 0.0667f;
        sBut.ObjectChanger();

        for (int i = 0; i < 12; i++)
        {
            c = (float)Math.Pow(10, 3 * (i + 1));

            if (damagePrices[velocityLevel] > c)

            {
                velocityText.text = "Lv:" + velocityLevel + "\nUpgrade:" + (damagePrices[velocityLevel] / c).ToString("F2") + ranks[i];
            }
        }
    }

    public void IdleTimeIncrease()
    {
        theMM.AddGold(-(float)damagePrices[idleLevel]);
        gold = PlayerPrefs.GetFloat("CurrentGold");
        idleLevel += 1;
        maxIdleTime = idleLevel + 8;
        idleBar.fillAmount += 0.0667f;

        for (int i = 0; i < 12; i++)
        {
            c = (float)Math.Pow(10, 3 * (i + 1));

            if (damagePrices[idleLevel] > c)

            {
                maxIdleText.text = "Max Idle Time:" + maxIdleTime + "\nUpgrade:" + (damagePrices[idleLevel] / c).ToString("F2") + ranks[i];
            }
        }
    }


}
