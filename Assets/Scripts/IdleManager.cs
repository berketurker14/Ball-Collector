using UnityEngine;
using UnityEngine.UI;
using System;

public class IdleManager : MonoBehaviour
{
    public long quitTime;
    public long startTime;
    public long timePassed;
    public MoneyManager theMM;
    public ComboMultiplier cM;
    public string[] ranks = { "K", "M", "B", "T", "Qu", "Qi", "Sx", "Sp", "Oc", "De", "Un", "Hk" };
    public GameObject offlinePopUp;
    public Text goldText;
    public GameObject idleTimer;
    public int maxIdleTime;
    public double earn;
    public Button skipButton;
    public void Start()
    {

        startTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        timePassed = startTime - quitTime;
        
        
        maxIdleTime = idleTimer.GetComponent<DamageVelocityIdleUpgrade>().maxIdleTime * 3600;
        if (timePassed > 30)
        {
            if (timePassed > 100000000000)
            {
                earn = 0;
            }
            else if (timePassed > maxIdleTime & (cM.comboMultiplier * maxIdleTime) > 1300)
            {
                for (int i = 0; i < 12; i++)
                {
                    double c = (float)Math.Pow(10, 3 * (i + 1));

                    if (cM.comboMultiplier * maxIdleTime > c)

                    {
                        goldText.text = ((cM.comboMultiplier * maxIdleTime)/ c).ToString("F2") + ranks[i];
                    }
                    else if (cM.comboMultiplier * maxIdleTime < 1000)
                    {
                        goldText.text = (cM.comboMultiplier * maxIdleTime).ToString("F2");
                    }
                    earn = cM.comboMultiplier * maxIdleTime;

                }
                offlinePopUp.SetActive(true);
            }
            else if ((cM.comboMultiplier * timePassed) > 1300 & timePassed<maxIdleTime)
            {
                for (int i = 0; i < 12; i++)
                {
                    double c = (float)Math.Pow(10, 3 * (i + 1));

                    if (cM.comboMultiplier * timePassed > c)

                    {
                        goldText.text = ((cM.comboMultiplier * timePassed) / c).ToString("F2") + ranks[i];
                    }
                    else if (cM.comboMultiplier * timePassed < 1000)
                    {
                        goldText.text = (cM.comboMultiplier * timePassed).ToString("F2");
                    }

                    earn = cM.comboMultiplier * timePassed;
                }
                offlinePopUp.SetActive(true);
            }
            skipButton.onClick.AddListener(() => theMM.AddGold((float)earn));
        }
    }
}


