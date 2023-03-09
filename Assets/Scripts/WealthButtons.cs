using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WealthButtons : MonoBehaviour
{
    public Button[] buttons;
    private double[] baseCost;
    public uint[] owned;
    public double[] nextPrice;
    private ulong[] yield;
    private ulong income;
    public ulong totalYield;
    public MoneyManager theMM;
    public ComboMultiplier cM;
    public string[] ranks = { "K", "M", "B", "T", "Qu", "Qi", "Sx", "Sp", "Oc", "De", "Un", "Hk" };
    public string x,y;
    int num;
    public void Start()
    {



        baseCost = new double[9];
        nextPrice = new double[9];
        yield = new ulong[9];
        theMM = FindObjectOfType<MoneyManager>();
        cM = FindObjectOfType<ComboMultiplier>();

        for (int i = 0; i < 9; i++)
        {
            int temp = i;
            buttons[i].onClick.AddListener(() => { ButtonMove(temp); });
        }

        

        yield[0] = 20;
        yield[1] = 400;
        yield[2] = 6000;
        yield[3] = 12000;
        yield[4] = 38000;
        yield[5] = 180000;
        yield[6] = 960000;
        yield[7] = 3650000;
        yield[8] = 16500000;

        baseCost[0] = 1e3;
        baseCost[1] = 5e4;
        baseCost[2] = 4.6e6;
        baseCost[3] = 1.8e8;
        baseCost[4] = 9.05e9;
        baseCost[5] = 8.6e10;
        baseCost[6] = 2.86e11;
        baseCost[7] = 6.8e12;
        baseCost[8] = 9.68e14;


        for (int i = 0; i < 9; i++)
        {
            owned[i] = owned[i];
            income = owned[i] * yield[i];
            nextPrice[i] = (ulong)(baseCost[i] * Math.Pow(1.15, owned[i]));


            for (int j = 0; j < 11; j++)
            {
                num = j * 1000;
                if (nextPrice[i] >= 1e36/ num)
                {
                    x = (nextPrice[i] / num).ToString("F2") + ranks[11-j];
                }
                else
                {
                    x = nextPrice[i].ToString("F2");
                }
            }
            
            


            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = ("Lv." + owned[i] +"\nBuy : " + x);
        }
        cM.comboMultiplier += income;

    }

    public void ButtonMove(int i)
    {
        owned[i]++;
        income = yield[i] * owned[i];
        theMM.AddGold(-nextPrice[i]);

        nextPrice[i] = (ulong)(baseCost[i] * Math.Pow(1.15, owned[i]));

        for (int j = 0; j < ranks.Length; j++)
        {
            if (nextPrice[j] >= Math.Pow(10, 36 - 3 * j))
            {
                x = (nextPrice[j] / Math.Pow(10, 36 - 3 * j)).ToString("F2") + ranks[11 - j];
                break;
            }
        }

        if (x == "")
        {
            x = nextPrice[ranks.Length].ToString("F2");
        }

        buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = ("Lv." + owned[i] + "\nBuy : " + x); ;


        

        cM.comboMultiplier += income - yield[i] * (owned[i]-1);

    }
}
