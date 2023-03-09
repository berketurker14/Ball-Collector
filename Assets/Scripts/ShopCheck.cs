using UnityEngine;
using UnityEngine.UI;

public class ShopCheck : MonoBehaviour
{
    public int currentLevel;
    public float potion;
    public PotionManager thePM;
    public Button upgradeButton;
    public BallShop bS;
    public GameObject damageIdleVelocityObject;
    public MoneyManager theMM;
    public UnlockScript unlock;
    public WealthButtons wealth;
    public BallSpawner bSpawn;
    public GameObject[] locks;
    public int temp;

    public GameObject damageButton;
    public GameObject velocityButton;
    public GameObject idleButton;
    private uint houseLevel,blacksmithLevel,fisherLevel,armyLevel,greatSnakeLevel,ghostPirateLevel,hallLevel,caravanLevel,shipLevel;

    void Update()
    {
        if (bS.ballPanel.activeSelf)
            houseLevel = wealth.owned[0];
            blacksmithLevel = wealth.owned[1];
            fisherLevel = wealth.owned[2];
            armyLevel = wealth.owned[3];
            greatSnakeLevel = wealth.owned[4];
            ghostPirateLevel = wealth.owned[5];
            hallLevel = wealth.owned[6];
            caravanLevel = wealth.owned[7];
            shipLevel = wealth.owned[8];


            potion = thePM.currentPotion;
            currentLevel = unlock.GetComponent<UnlockScript>().level;
            if (potion >= 10 & currentLevel == 0 || potion >= 60 & houseLevel>=2 & currentLevel == 1 || potion >= 180 & blacksmithLevel>=2 & currentLevel == 2 || potion >= 560 & fisherLevel >= 3 & armyLevel >= 1  & currentLevel == 3 || potion >= 1120 & ghostPirateLevel >= 1 & greatSnakeLevel >= 4 & currentLevel == 4 || potion >= 3600 & shipLevel>=2 & caravanLevel>=4 & currentLevel == 5)
            {
                upgradeButton.GetComponent<Button>().interactable = true;
            }
            else
            {

                upgradeButton.GetComponent<Button>().interactable = false;
            }

        if (bS.upgradePanel1.activeSelf)
        {
            double money = theMM.currentGold;
            currentLevel = damageIdleVelocityObject.GetComponent<DamageVelocityIdleUpgrade>().damageLevel;

            if (money >= 400 & currentLevel == 0 || money >= 1.6e3 & currentLevel == 1 || money >= 27e3 & currentLevel == 2 || money >= 183e3 & currentLevel == 3 || money >= 3.21e6 & currentLevel == 4 || money >= 16.95e8 & currentLevel == 5 || money >= 39.8e9 & currentLevel == 6 || money >= 45.75e10 & currentLevel == 7 || money >= 6.43e11 & currentLevel == 8 || money >= 86e11 & currentLevel == 9 || money >= 1.11e12 & currentLevel == 10 || money >= 233.15e12 & currentLevel == 11 || money >= 3.85e13 & currentLevel == 12 || money >= 35e14 & currentLevel == 13 || money >= 95e17 & currentLevel == 14)
            {
                damageButton.GetComponent<Button>().interactable = true;
            }
            else
            {

                damageButton.GetComponent<Button>().interactable = false;
            }

            int velocityLevel = damageIdleVelocityObject.GetComponent<DamageVelocityIdleUpgrade>().velocityLevel;

            if (money >= 400 & velocityLevel == 0 || money >= 1.6e3 & velocityLevel == 1 || money >= 27e3 & velocityLevel == 2 || money >= 183e3 & velocityLevel == 3 || money >= 3.21e6 & velocityLevel == 4 || money >= 16.95e8 & velocityLevel == 5 || money >= 39.8e9 & velocityLevel == 6 || money >= 45.75e10 & velocityLevel == 7 || money >= 6.43e11 & velocityLevel == 8 || money >= 86e11 & velocityLevel == 9 || money >= 1.11e12 & velocityLevel == 10 || money >= 233.15e12 & velocityLevel == 11 || money >= 3.85e13 & velocityLevel == 12 || money >= 35e14 & velocityLevel == 13 || money >= 95e17 & velocityLevel == 14)
            {
                velocityButton.GetComponent<Button>().interactable = true;
            }
            else
            {

                velocityButton.GetComponent<Button>().interactable = false;
            }

            int idleLevel = damageIdleVelocityObject.GetComponent<DamageVelocityIdleUpgrade>().idleLevel;

            if (money >= 400 & idleLevel == 0 || money >= 1.6e3 & idleLevel == 1 || money >= 27e3 & idleLevel == 2 || money >= 183e3 & idleLevel == 3 || money >= 3.21e6 & idleLevel == 4 || money >= 16.95e8 & idleLevel == 5 || money >= 39.8e9 & idleLevel == 6 || money >= 45.75e10 & idleLevel == 7 || money >= 6.43e11 & idleLevel == 8 || money >= 86e11 & idleLevel == 9 || money >= 1.11e12 & idleLevel == 10 || money >= 233.15e12 & idleLevel == 11 || money >= 3.85e13 & idleLevel == 12 || money >= 35e14 & idleLevel == 13 || money >= 95e17 & idleLevel == 14)
            {
                idleButton.GetComponent<Button>().interactable = true;
            }
            else
            {

                idleButton.GetComponent<Button>().interactable = false;
            }
        }

        if (bS.wealthPanel.activeSelf)
        {
            for (int z = 0; z < 9; z++)
            {

                if (bSpawn.level >= 2 + 13 * z)
                {
                    locks[z].SetActive(false);
                }
                else
                {
                    temp = z;
                    break;
                }
            }
            double money = theMM.currentGold;
            for (int i = 0; i < 9; i++)
            {
                Button wealthButton = wealth.buttons[i];
                double nextprize = wealth.nextPrice[i];
                if (money >= nextprize)
                {
                    wealthButton.interactable = true;
                }
                else
                {
                    wealth.buttons[i].interactable = false;
                }
            }
        }
    }
}
