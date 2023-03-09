using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Drawing;

public class ShopButtons : MonoBehaviour
{
    public GameObject ball;
    public GameObject b111;
    public GameObject b211;
    public GameObject b121;
    public GameObject b112;
    public GameObject b221;
    public GameObject b212;
    public GameObject b122;
    public GameObject b222;
    public GameObject b113;
    public GameObject b131;
    public GameObject b311;
    public GameObject b123;
    public GameObject b213;
    public GameObject b223;
    public GameObject b132;
    public GameObject b231;
    public GameObject b232;
    public GameObject b312;
    public GameObject b321;
    public GameObject b322;
    public GameObject b331;
    public GameObject b313;
    public GameObject b133;
    public GameObject b332;
    public GameObject b323;
    public GameObject b233;
    public GameObject b333;


    public GameObject redPlus;
    public GameObject greenPlus;
    public GameObject bluePlus;
    public GameObject redMinus;
    public GameObject greenMinus;
    public GameObject blueMinus;

    public GameObject damageVelocityObject;


    private Vector3 currentVelocity;
    private Color32 renk;
    public GameObject currentBall;
    public Text redText;
    public Text greenText;
    public Text blueText;
    public int redNumber = 1;
    public int greenNumber = 1;
    public int blueNumber = 1;
    int angular,level;
    public float magnitude;
    public float velocityMagnitude;

    public float damage;
    public GameObject unlock;
    public TextMeshProUGUI ballSpecs;
    public string toWriteSpecs;




    // Start is called before the first frame update
    void Start()
    {
        
        renk = new Color32(0, 0, 0, 255);
        float velocityMultiplier = (damageVelocityObject.GetComponent<DamageVelocityIdleUpgrade>().velocityLevel)  + 1;
        float damageMultiplier = damageVelocityObject.GetComponent<DamageVelocityIdleUpgrade>().damageLevel + 1;
        currentBall = ball;
        magnitude =  10 * velocityMultiplier * 0.14f;
        level = unlock.GetComponent<UnlockScript>().level;
        ObjectChanger();
        blueText.text = "" + blueNumber;
        redText.text = "" + redNumber;
        greenText.text = "" + greenNumber;
        GeneralCheck();
        redPlus.GetComponent<Button>().onClick.AddListener(RedIncrease);
        greenPlus.GetComponent<Button>().onClick.AddListener(GreenIncrease);
        bluePlus.GetComponent<Button>().onClick.AddListener(BlueIncrease);

        redMinus.GetComponent<Button>().onClick.AddListener(RedDecrease);
        greenMinus.GetComponent<Button>().onClick.AddListener(GreenDecrease);
        blueMinus.GetComponent<Button>().onClick.AddListener(BlueDecrease);

    }
   

    public void RedIncrease()
    {
        // Get the current level from the UnlockScript component attached to the "unlock" object
        var unlockScript = unlock.GetComponent<UnlockScript>();
        var level = unlockScript.level;

        // Increment the redNumber variable by 1
        redNumber += 1;

        // Update the text of the "redText" object to reflect the new value of redNumber
        redText.text = "" + redNumber;

        // Call the ObjectChanger function
        ObjectChanger();

        // Get a reference to the "redPlus" and "redMinus" buttons
        var redPlusButton = redPlus.GetComponent<Button>();
        var redMinusButton = redMinus.GetComponent<Button>();

        // Enable or disable the "redPlus" and "redMinus" buttons based on certain conditions
        redPlusButton.interactable = redNumber < 3 && (level >= 4 || (level >= 1 && redNumber != 2 && level < 4));
        redMinusButton.interactable = redNumber > 1;
    }

    public void GreenIncrease()
    {
        // Get the current level from the UnlockScript component attached to the "unlock" object
        var unlockScript = unlock.GetComponent<UnlockScript>();
        var level = unlockScript.level;

        // Increment the greenNumber variable by 1
        greenNumber += 1;

        // Update the text of the "greenText" object to reflect the new value of greenNumber
        greenText.text = "" + greenNumber;

        // Call the ObjectChanger function
        ObjectChanger();

        // Get a reference to the "greenPlus" and "greenMinus" buttons
        var greenPlusButton = greenPlus.GetComponent<Button>();
        var greenMinusButton = greenMinus.GetComponent<Button>();

        // Enable or disable the "greenPlus" and "greenMinus" buttons based on certain conditions
        greenPlusButton.interactable = greenNumber < 3 && (level >= 5 || (level >= 2 && greenNumber != 2 && level < 5));
        greenMinusButton.interactable = greenNumber > 1;
    }

    public void BlueIncrease()
    {
        // Get the current level from the UnlockScript component attached to the "unlock" object
        var unlockScript = unlock.GetComponent<UnlockScript>();
        var level = unlockScript.level;

        // Increment the blueNumber variable by 1
        blueNumber += 1;

        // Update the text of the "blueText" object to reflect the new value of blueNumber
        blueText.text = "" + blueNumber;

        // Call the ObjectChanger function
        ObjectChanger();

        // Get a reference to the "bluePlus" and "blueMinus" buttons
        var bluePlusButton = bluePlus.GetComponent<Button>();
        var blueMinusButton = blueMinus.GetComponent<Button>();

        // Enable or disable the "bluePlus" and "blueMinus" buttons based on certain conditions
        bluePlusButton.interactable = blueNumber < 3 && (level >= 6 || (level >= 3 && blueNumber != 2 && level < 6));
        blueMinusButton.interactable = blueNumber > 1;
    }


    public void RedDecrease()
    {
        // Get the current level from the UnlockScript component attached to the "unlock" object
        var unlockScript = unlock.GetComponent<UnlockScript>();
        var level = unlockScript.level;

        // Decrement the redNumber variable by 1
        redNumber -= 1;

        // Update the text of the "redText" object to reflect the new value of redNumber
        redText.text = "" + redNumber;

        // Call the ObjectChanger function
        ObjectChanger();

        // Get a reference to the "redPlus" and "redMinus" buttons
        var redPlusButton = redPlus.GetComponent<Button>();
        var redMinusButton = redMinus.GetComponent<Button>();

        // Enable or disable the "redPlus" and "redMinus" buttons based on certain conditions
        redPlusButton.interactable = (redNumber < 3 && (level >= 4 || (level >= 1 && redNumber != 2 && level < 4))) || (redNumber == 2 && level >= 1);
        redMinusButton.interactable = redNumber > 1;
    }

    public void GreenDecrease()
    {
        // Get the current level from the UnlockScript component attached to the "unlock" object
        var unlockScript = unlock.GetComponent<UnlockScript>();
        var level = unlockScript.level;

        // Decrement the greenNumber variable by 1
        greenNumber -= 1;

        // Update the text of the "greenText" object to reflect the new value of greenNumber
        greenText.text = "" + greenNumber;

        // Call the ObjectChanger function
        ObjectChanger();

        // Get a reference to the "greenPlus" and "greenMinus" buttons
        var greenPlusButton = greenPlus.GetComponent<Button>();
        var greenMinusButton = greenMinus.GetComponent<Button>();

        // Enable or disable the "greenPlus" and "greenMinus" buttons based on certain conditions
        greenPlusButton.interactable = (greenNumber < 3 && (level >= 5 || (level >= 2 && greenNumber != 2 && level < 5))) || (greenNumber == 2 && level >= 2);
        greenMinusButton.interactable = greenNumber > 1;
    }

    public void BlueDecrease()
    {
        // Get the current level from the UnlockScript component attached to the "unlock" object
        var unlockScript = unlock.GetComponent<UnlockScript>();
        var level = unlockScript.level;

        // Decrement the blueNumber variable by 1
        blueNumber -= 1;

        // Update the text of the "blueText" object to reflect the new value of blueNumber
        blueText.text = "" + blueNumber;

        // Call the ObjectChanger function
        ObjectChanger();

        // Get a reference to the "bluePlus" and "blueMinus" buttons
        var bluePlusButton = bluePlus.GetComponent<Button>();
        var blueMinusButton = blueMinus.GetComponent<Button>();

        // Enable or disable the "bluePlus" and "blueMinus" buttons based on certain conditions
        bluePlusButton.interactable = (blueNumber < 3 && (level >= 6 || (level >= 3 && blueNumber != 2 && level < 6))) || (blueNumber == 2 && level >= 3);
        blueMinusButton.interactable = blueNumber > 1;
    }


    public void ObjectChanger()
    {


        float velocityMultiplier = damageVelocityObject.GetComponent<DamageVelocityIdleUpgrade>().velocityLevel+1;
        float damageMultiplier = damageVelocityObject.GetComponent<DamageVelocityIdleUpgrade>().damageLevel;

        float horizontal = currentBall.GetComponent<Transform>().position.x;
        float vertical = currentBall.GetComponent<Transform>().position.y;
        currentVelocity = currentBall.GetComponent<Rigidbody2D>().velocity;
        currentBall.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        currentBall.transform.position = new Vector3(47.42706f, -1.300876f, -1);
            

        if (redNumber == 1 & blueNumber == 1 & greenNumber == 1)
        {
            //111
            //standart ball

            currentBall = b111;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Standart Ball";


        }
        if (redNumber == 2 & blueNumber == 1 & greenNumber == 1)
        {
            //211
            //good damage but slow


            currentBall = b211;
            angular = 60;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Hits nice";

        }
        if (redNumber == 1 & blueNumber == 1 & greenNumber == 2)
        {

            //121
            //equilibrium between damage and velocity

            currentBall = b121;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Equalibrium";

        }
        if (redNumber == 1 & blueNumber == 2 & greenNumber == 1)
        {
            //112
            //fast deals 1 damage


            currentBall = b112;
            angular = 12;
            magnitude = (float)(25 * velocityMultiplier * 0.045 );
            damage = 1;
            toWriteSpecs = "It's Pretty Cold Here";

        }
        if (redNumber == 2 & blueNumber == 1 & greenNumber == 2)
        {
            //221
            //good speed better damage
            currentBall = b221;
            angular = 60;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Looks like sun";

        }

        if (redNumber == 2 & blueNumber == 2 & greenNumber == 1)
        {
            //212
            //good damage,speed
            currentBall = b212;
            angular = 60;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Cutie Mushroom uwu";
        }

        if (redNumber == 1 & blueNumber == 2 & greenNumber == 2)
        {
            //122
            //good damage better speed
            currentBall = b122;
            angular = 60;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Sticky";
        }

        if (redNumber == 2 & blueNumber == 2 & greenNumber == 2)
        {
            //222
            //better speed better damage
            currentBall = b222;
            angular = 60;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Looks Like Peace huh?";
        }

        if (redNumber == 1 & blueNumber == 3 & greenNumber == 1)
        {
            //113
            //great speed
            currentBall = b113;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Gotta Go Fast!";


        }
        if (redNumber == 1 & blueNumber == 1 & greenNumber == 3 )
        {
            //131
            //better speed better damage
            currentBall = b131;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Looks Charming";
        }
        if (redNumber == 3 & blueNumber == 1 & greenNumber == 1)
        {
            //311
            //great damage
            currentBall = b311;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Fire";
        }

        if (redNumber == 1 & blueNumber == 3 & greenNumber == 2)
        {
            //123
            //better than great speed good damage

            currentBall = b123;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Water";
        }

        if (redNumber == 2 & blueNumber == 3 & greenNumber == 1)
        {
            //213
            //great speed good damage

            currentBall = b213;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Pinkiee!";
        }

        if (redNumber == 2 & blueNumber == 3 & greenNumber == 2)
        {
            //223
            //better than great speed better than good damage

            currentBall = b223;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "blob";
        }

        if (redNumber == 1 & blueNumber == 2 & greenNumber == 3)
        {
            //132

            currentBall = b132;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Shuriken";
        }

        if (redNumber == 2 & blueNumber == 1 & greenNumber == 3)
        {
            //231

            currentBall = b231;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Slime Yeah!";
        }

        if (redNumber == 2 & blueNumber == 2 & greenNumber == 3)
        {
            //232

            currentBall = b232;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "You're a Star!";
        }

        if (redNumber == 3 & blueNumber == 2 & greenNumber == 1)
        {
            //312

            currentBall = b312;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Pentagon";
        }

        if (redNumber == 3 & blueNumber == 1 & greenNumber == 2)
        {
            //321

            currentBall = b321;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Bitir Isi";

        }

        if (redNumber == 3 & blueNumber == 2 & greenNumber == 2)
        {
            //322

            currentBall = b322;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Best Square";
        }

        if (redNumber == 3 & blueNumber == 1 & greenNumber == 3)
        {
            //331

            currentBall = b331;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Lightning";
        }

        if (redNumber == 3 & blueNumber == 3 & greenNumber == 1)
        {
            //313

            currentBall = b313;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Dark Energy";
        }

        if (redNumber == 1 & blueNumber == 3 & greenNumber == 3)
        {
            //133

            currentBall = b133;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Freezing Cold";
        }

        if (redNumber == 3 & blueNumber == 2 & greenNumber == 3)
        {
            //332

            currentBall = b332;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Moon";
        }

        if (redNumber == 3 & blueNumber == 3 & greenNumber == 2)
        {
            //323

            currentBall = b323;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "Another One";
        }

        if (redNumber == 2 & blueNumber == 3 & greenNumber == 3)
        {
            //233

            currentBall = b233;
            angular = 12;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "ICE!";

        }

        if (redNumber == 3 & blueNumber == 3 & greenNumber == 3)
        {
            //333

            currentBall = b333;
            angular = 120;
            magnitude = (float)(7 + ((greenNumber-1) * 2 + (blueNumber - 1) * 4) * velocityMultiplier * 0.045);
            damage = (int)(1+(((redNumber - 1) * 4 + (greenNumber -1)*2)) * damageMultiplier);
            toWriteSpecs = "CRAZY!!";
        }

        ballSpecs.text = "Ball "+redNumber.ToString() + greenNumber.ToString() + blueNumber.ToString()+"\nDamage : "+damage+"\nVelocity : "+magnitude+"\n"+toWriteSpecs;
        ballSpecs.GetComponent<Animation>().Play("ballfadeinout");

        currentBall.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        currentBall.transform.position = new Vector3(horizontal, vertical, -1);

        if (velocityMagnitude <= 0.4f)
        {
            currentBall.GetComponent<Rigidbody2D>().velocity = new Vector3(3, 4, 0);

        }
        currentBall.GetComponent<Rigidbody2D>().velocity = 5 * currentVelocity.normalized;
    }


    public void Update()
    {
        float velocityMultiplier = (damageVelocityObject.GetComponent<DamageVelocityIdleUpgrade>().velocityLevel) + 1;
        currentBall.GetComponent<Rigidbody2D>().velocity = magnitude * (currentBall.GetComponent<Rigidbody2D>().velocity.normalized);
        currentBall.GetComponent<Rigidbody2D>().angularVelocity = angular;

        if (currentBall.GetComponent<Rigidbody2D>().velocity.magnitude < 0.4)
        {

            currentBall.GetComponent<Rigidbody2D>().velocity = magnitude * (new Vector3(-26, -28) - transform.position).normalized;
        }


            
    }

    public void GeneralCheck()
    {
        if (redNumber == 3)
        {
            redPlus.GetComponent<Button>().interactable = false;
        }

        else if (level >= 4)
        {
            redPlus.GetComponent<Button>().interactable = true;
        }
        else if (level >= 1 & redNumber != 2 & level < 4)
        {
            redPlus.GetComponent<Button>().interactable = true;
        }
        else
        {
            redPlus.GetComponent<Button>().interactable = false;
        }

        if (redNumber > 1)
        {
            redMinus.GetComponent<Button>().interactable = true;
        }
        else
        {
            redMinus.GetComponent<Button>().interactable = false;
        }

        if (greenNumber == 3)
        {
            greenPlus.GetComponent<Button>().interactable = false;
        }

        else if (level >= 5)
        {
            greenPlus.GetComponent<Button>().interactable = true;

        }
        else if (level >= 2 & greenNumber != 2 & level < 5)
        {
            greenPlus.GetComponent<Button>().interactable = true;
        }
        else
        {
            greenPlus.GetComponent<Button>().interactable = false;
        }

        if (greenNumber > 1)
        {
            greenMinus.GetComponent<Button>().interactable = true;
        }
        else
        {
            greenMinus.GetComponent<Button>().interactable = false;
        }

        if (blueNumber == 3)
        {
            bluePlus.GetComponent<Button>().interactable = false;
        }

        else if (level >= 6)
        {
            bluePlus.GetComponent<Button>().interactable = true;
        }
        else if (level >= 3 & blueNumber != 2 & level < 6)
        {
            bluePlus.GetComponent<Button>().interactable = true;
        }
        else
        {
            bluePlus.GetComponent<Button>().interactable = false;
        }

        if (blueNumber > 1)
        {
            blueMinus.GetComponent<Button>().interactable = true;
        }
        else
        {
            blueMinus.GetComponent<Button>().interactable = false;
        }

        if (redNumber > 1)
        {
            redMinus.GetComponent<Button>().interactable = true;
        }
        else
        {
            redMinus.GetComponent<Button>().interactable = false;
        }

        if (redNumber < 3 & level >= 4)
        {
            redPlus.GetComponent<Button>().interactable = true;
        }

        else if (redNumber < 2 & level >= 1)
        {
            redPlus.GetComponent<Button>().interactable = true;
        }
        else
        {
            redPlus.GetComponent<Button>().interactable = false;
        }

        if (greenNumber > 1)
        {
            greenMinus.GetComponent<Button>().interactable = true;
        }
        else
        {
            greenMinus.GetComponent<Button>().interactable = false;
        }

        if (greenNumber < 3 & level >= 5)
        {
            greenPlus.GetComponent<Button>().interactable = true;
        }

        else if (greenNumber < 2 & level >= 2)
        {
            greenPlus.GetComponent<Button>().interactable = true;
        }
        else
        {
            greenPlus.GetComponent<Button>().interactable = false;
        }

        if (blueNumber > 1)
        {
            blueMinus.GetComponent<Button>().interactable = true;
        }
        else
        {
            blueMinus.GetComponent<Button>().interactable = false;
        }
        if (blueNumber < 3 & level == 6)
        {
            bluePlus.GetComponent<Button>().interactable = true;
        }
        else if (blueNumber < 2 & level >= 3)
        {
            bluePlus.GetComponent<Button>().interactable = true;
        }
        else
        {
            bluePlus.GetComponent<Button>().interactable = false;
        }
    }
}
