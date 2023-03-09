using UnityEngine;
using UnityEngine.UI;
using System;



public class GoldAnim : MonoBehaviour
{
    private int damage = 1;
    public GameObject[] brick;

    public TextMesh leftOver;
    public GameObject goldEffecter;
    int brickLeft;
    float rand;

    public int[,] referenceBrickCoordinates;
    public int destroyedBrickCounterForLXZVariations = 0;
    public ComboMultiplier comboMultiplier;

    public int goldValue;
    public MoneyManager theMM;
    public PotionManager thePM;
    public DamageVelocityIdleUpgrade dmg;
    public BallSpawner bS;
    public WealthButtons wB;
    public ShopButtons sB;
    public Slider slidy;



    // Start is called before the first frame update
    void Start()
    {
        comboMultiplier = FindObjectOfType<ComboMultiplier>();
        destroyedBrickCounterForLXZVariations = comboMultiplier.destroyedBrickCounterForLXZVariations;
        referenceBrickCoordinates = comboMultiplier.referenceBrickCoordinates;
        brickLeft = int.Parse(leftOver.GetComponent<TextMesh>().text);
        theMM = FindObjectOfType<MoneyManager>();
        thePM = FindObjectOfType<PotionManager>();
        dmg = FindObjectOfType<DamageVelocityIdleUpgrade>();
        bS = FindObjectOfType<BallSpawner>();
        wB = FindObjectOfType<WealthButtons>();
        sB = FindObjectOfType<ShopButtons>();
        slidy = FindObjectOfType<Slider>();
        
    }



    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {

        goldEffecter.GetComponent<Animator>().Play("gold");
        GetComponent<Animator>().Play("brick");




        if (col.collider.CompareTag("Ball"))
        {


            if (transform.GetComponent<SpriteRenderer>().sprite.name == "death")
            {
                slidy.value -= 100;
            }



            damage = (dmg.damageLevel + 1) * (dmg.damageLevel + 1);
            brickLeft = int.Parse(transform.GetChild(0).GetComponent<TextMesh>().text);
            brickLeft -= (int)sB.damage;

            theMM.AddGold(goldValue);


        }




        if (brickLeft <= 0)
        {
            Debug.Log(comboMultiplier.destroyedBrickCounterForLXZVariations);
            //Debug.Log(referenceBrickCoordinates[gameObject.transform.parent.gameObject.name[1], gameObject.transform.parent.gameObject.name[3]]);
            //Debug.Log(gameObject.transform.parent.gameObject.name[1]);
            comboMultiplier.referenceBrickCoordinates[(int)Char.GetNumericValue(gameObject.transform.parent.name[1])-1, (int)Char.GetNumericValue(gameObject.transform.parent.name[3])-1] = 1;
            gameObject.SetActive(false);
            comboMultiplier.destroyedBrickCounterForLXZVariations++;
            Debug.Log("Broken");
            //Burada kırılıyor
            LXZControl();
            rand = UnityEngine.Random.Range(0f, 1f);

            if (rand < 0.005)
            {
                thePM.AddPotion(3);
            }
        }
        leftOver.text = "" + brickLeft;
    }

    void LXZControl()
    {
        if(comboMultiplier.destroyedBrickCounterForLXZVariations == 4)
        {
            Debug.Log("controlling L");
            CheckForL();
        }
        if (comboMultiplier.destroyedBrickCounterForLXZVariations == 5)
        {
            CheckForX();
        }
        if (comboMultiplier.destroyedBrickCounterForLXZVariations == 7)
        {
            CheckForZ();
        }
    }
    void CheckForL()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                // Check for horizontal L possibilities
                if (j < 6 && i < 2)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i, j + 1] == 1 && comboMultiplier.referenceBrickCoordinates[i, j + 2] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j + 2] == 1)
                    {
                        //L animation and deal damage to all
                        Debug.Log("L variation");
                    }
                }
                if (j > 0 && i < 2)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i, j - 1] == 1 && comboMultiplier.referenceBrickCoordinates[i, j - 2] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j - 2] == 1)
                    {
                        //L animation and deal damage to all
                        Debug.Log("L variation");

                    }
                }

                // Check for vertical L possibilities
                if (i < 2 && j < 3)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 2, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 2, j + 1] == 1)
                    {
                        //L animation and deal damage to all
                        Debug.Log("L variation");

                    }
                }
                if (i < 2 && j > 3)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 2, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 2, j - 1] == 1)
                    {
                        //L animation and deal damage to all
                        Debug.Log("L variation");

                    }
                }
            }
        }
    }
    void CheckForX()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                // Check for horizontal X possibilities
                if (j < 4 && i < 2)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i, j + 3] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j + 1] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j + 2] == 1 && comboMultiplier.referenceBrickCoordinates[i + 2, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 2, j + 3] == 1)
                    {
                        // X animation and deal damage to all
                    }
                }
                // Check for vertical X possibilities
                if (i < 2 && j < 3)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 3, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j + 1] == 1 && comboMultiplier.referenceBrickCoordinates[i + 2, j + 1] == 1 && comboMultiplier.referenceBrickCoordinates[i, j + 2] == 1 && comboMultiplier.referenceBrickCoordinates[i + 3, j + 2] == 1)
                    {
                        // X animation and deal damage to all
                    }
                }
            }
        }
    }
    void CheckForZ()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                // Check for horizontal Z possibilities
                if (j < 5 && i < 2)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i, j + 1] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j + 1] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j + 2] == 1)
                    {
                        // Z animation and deal damage to all
                    }
                }
                if (j > 1 && i < 2)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i, j - 1] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j - 1] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j - 2] == 1)
                    {
                        // Z animation and deal damage to all
                    }
                }

                // Check for vertical Z possibilities
                if (i < 2 && j < 6)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j] == 1 && comboMultiplier.referenceBrickCoordinates[i + 1, j + 1] == 1 && comboMultiplier.referenceBrickCoordinates[i + 2, j + 1] == 1)
                    {
                        // Z animation and deal damage to all
                    }
                }
                if (i > 0 && j < 6)
                {
                    if (comboMultiplier.referenceBrickCoordinates[i, j] == 1 && comboMultiplier.referenceBrickCoordinates[i - 1, j] == 1 && comboMultiplier.referenceBrickCoordinates[i - 1, j + 1] == 1 && comboMultiplier.referenceBrickCoordinates[i - 2, j + 1] == 1)
                    {
                        // Z animation and deal damage to all
                    }
                }
            }
        }
    }

}
