using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallShop : MonoBehaviour
{
    public GameObject ballPanel;
    public GameObject upgradeButton;
    public GameObject upgradePanel1;
    public GameObject wealthPanel;
    public bool ballPanelisOpen;





    public void CheckGold()//çalışıyor
    {
        MoneyManager theMM = FindObjectOfType<MoneyManager>().GetComponent<MoneyManager>();
    }

    public void BallPanel()
    {
        if(ballPanel != null)
        {
            bool isActive = ballPanel.activeSelf;
            ballPanel.SetActive(!isActive);
            upgradePanel1.SetActive(false);
        }   
    }


    public void UpgradePanel1()
    {
        if (upgradePanel1 != null)
        {
            bool isActive = upgradePanel1.activeSelf;
            upgradePanel1.SetActive(!isActive);
            ballPanel.SetActive(false);
            wealthPanel.SetActive(false);
        }
    }


    public void WealthPanel()
    {
        if (wealthPanel != null)
        {
            bool isActive = wealthPanel.activeSelf;
            wealthPanel.SetActive(!isActive);
            upgradePanel1.SetActive(false);
            ballPanel.SetActive(false);
        }
    }


}
