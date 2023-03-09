using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ComboMultiplier : MonoBehaviour
{
    public string[] ranks = { "K", "M", "B", "T", "Qu", "Qi", "Sx", "Sp", "Oc", "De", "Un", "Hk" };
    public float comboMultiplier;
    public TextMeshProUGUI textie;
    [HideInInspector] public int[,] referenceBrickCoordinates;
    [HideInInspector] public int destroyedBrickCounterForLXZVariations = 0;

    private void Awake()
    {
        referenceBrickCoordinates = new int[4, 7];
    }
    public void Start()
    {
        textie = textie.GetComponent<TextMeshProUGUI>();
    }
    public void Update()
    {


        for (int i = 0; i < 12; i++)
        {
            float c = (float)Math.Pow(10, 3 * (i + 1));

            if (comboMultiplier > c)
            {
                String x = (comboMultiplier / c).ToString("F2");
                textie.text = "+"+x+ranks[i]+"/s";
            }
            else if (comboMultiplier < 1000)
            {
                textie.text = "+"+comboMultiplier.ToString("F2")+"/s";
            }

        }
    }


}
