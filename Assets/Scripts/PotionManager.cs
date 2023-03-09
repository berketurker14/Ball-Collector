using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PotionManager : MonoBehaviour
{
    public TextMeshProUGUI potionText;
    public float currentPotion;
    float c;


    public string[] ranks = { "K", "M", "B", "T", "Qu", "Qi", "Sx", "Sp", "Oc", "De", "Un", "Hk" };
    void Start()
    {
        PlayerPrefs.SetFloat("CurrentPotion", (float)currentPotion);
        potionText.text = "" + currentPotion;

    }

    public void AddPotion(float potionToAdd)
    {
        currentPotion += potionToAdd;
        PlayerPrefs.SetFloat("CurrentPotion", currentPotion);
        potionText.text = "" + currentPotion;
        for (int i = 0; i < 12; i++)
        {
            c = (float)Math.Pow(10, 3 * (i + 1));

            if (currentPotion > c)

            {
                potionText.text = (currentPotion / c).ToString("F2") + ranks[i];
            }
        }

    }
}
