using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class PlayerData
{
    public double gold;
    public float potions,combo;
    public int level;
    public int[] upgradeLevels;
    public int[] rgbData;
    public int unlockLevel;
    public long idle;
    public uint[] ownie;

    public PlayerData(MoneyManager money,BallSpawner levelYeah,DamageVelocityIdleUpgrade upgradeLevelsYeah,ShopButtons ballZ ,UnlockScript unlockedLevel,PotionManager potion
        ,ComboMultiplier combozi,IdleManager idleTime,WealthButtons wB)
    {
        gold = money.currentGold;
        level = levelYeah.level;
        rgbData = new int[3];
        rgbData[0] = ballZ.redNumber;
        rgbData[1] = ballZ.greenNumber;
        rgbData[2] = ballZ.blueNumber;

        upgradeLevels = new int[3];
        upgradeLevels[0] = upgradeLevelsYeah.damageLevel; //0. indis damagelevel
        upgradeLevels[1] = upgradeLevelsYeah.velocityLevel; //1. indis velocityLevel
        upgradeLevels[2] = upgradeLevelsYeah.idleLevel; //1. indis velocityLevel

        unlockLevel = unlockedLevel.level;
        potions = potion.currentPotion;
        combo = combozi.comboMultiplier;
        idle = DateTimeOffset.Now.ToUnixTimeSeconds();

        ownie = new uint[9];
        for (int i = 0; i < 9; i++)
        {
            ownie[i] = wB.owned[i];
        }
        
    }

}
