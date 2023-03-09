using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class MoneyManager : MonoBehaviour
{

    public ComboMultiplier comMult;
    public WealthButtons wB;
    public TextMeshProUGUI moneyText;
    public double currentGold;
    float elapsed = 0f;
    float c;
    

    public string[] ranks = {"K", "M", "B", "T", "Qu", "Qi", "Sx", "Sp", "Oc", "De", "Un", "Hk" };
    void Start()
    {
        wB = FindObjectOfType<WealthButtons>();
        comMult = FindObjectOfType<ComboMultiplier>();
        PlayerPrefs.SetFloat("CurrentGold", (float)currentGold);
        for (int i = 0; i < 12; i++)
        {
            c = (float)Math.Pow(10, 3 * (i+1));

            if (currentGold > c)

            {
                moneyText.text = (currentGold / c).ToString("F1") + ranks[i];
            }
            else if (currentGold < 1000)
            {
                moneyText.text = currentGold.ToString("F1");
            }

        }
    }


    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = 0;
            AddGold(comMult.comboMultiplier + wB.totalYield);
        }
    }


    public void AddGold(double goldToAdd)
    {
        currentGold += goldToAdd;
        moneyText.text = "" + currentGold;
        for (int i = 0; i < 12; i++)
        {
            c = (float)Math.Pow(10, 3 * (i + 1));
            
            if (currentGold > c)

                 {
                    moneyText.text = (currentGold / c).ToString("F1") + ranks[i];
                }
            else if (currentGold < 1000)
            {
                moneyText.text = currentGold.ToString("F1");
            }
        }
            
    }





}
