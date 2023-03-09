using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class SaveLoadOnExitStart : MonoBehaviour
{
    public MoneyManager theMM;
    public BallSpawner ballSpawn;
    public DamageVelocityIdleUpgrade damVel;
    public ShopButtons shopButt;
    public UnlockScript unnlock;
    public PotionManager potion;
    public ComboMultiplier combozi;
    public IdleManager idle;
    public WealthButtons wB;


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(theMM, ballSpawn, damVel, shopButt,unnlock,potion,combozi,idle,wB);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        ballSpawn.level = data.level;
        theMM.currentGold = data.gold;
        damVel.damageLevel = data.upgradeLevels[0];
        damVel.velocityLevel = data.upgradeLevels[1];
        damVel.idleLevel = data.upgradeLevels[2];
        shopButt.redNumber = data.rgbData[0];
        shopButt.greenNumber = data.rgbData[1];
        shopButt.blueNumber = data.rgbData[2];
        unnlock.level = data.unlockLevel;
        potion.currentPotion = data.potions;
        combozi.comboMultiplier = data.combo;
        idle.quitTime = data.idle;

        for (int i = 0; i < 9; i++)
        {
            wB.owned[i] = data.ownie[i];
        }
        
    }

    private void OnApplicationPause()
    {

        SavePlayer();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SavePlayer();
        }
    }
    private void OnApplicationQuit()
    {

        SavePlayer();
    }

    public void Awake()
    {
        if(PlayerPrefs.HasKey("FirstJoin"))
            LoadPlayer();
        else
        {
            PlayerPrefs.SetInt("FirstJoin", 1);
            ballSpawn.level = 0;
            theMM.currentGold = 0;
            damVel.damageLevel = 0;
            damVel.velocityLevel = 0;
            damVel.idleLevel = 0;
            shopButt.redNumber = 1;
            shopButt.greenNumber = 1;
            shopButt.blueNumber = 1;
            unnlock.level = 0;
            potion.currentPotion = 10;
            combozi.comboMultiplier = 0;
        }

            

    }


}



