using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Forces
{


    public class buyScript : MonoBehaviour
    {
        public Button buyButton;
        public Text money;
        public Text price;
        public Text Level;
        //int newprice = 35;
        double gold;

        public static int firstLevel = 1;
        int holder = 0;
        // Start is called before the first frame update
        void Start()
        {
            Button btn = buyButton.GetComponent<Button>();
            btn.onClick.AddListener(buy);
            
        }
        void Update()
        {
            
            if (gold >= 35 + holder * holder)
            {
                buyButton.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            }
            else
            {
                buyButton.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
        }

        // Update is called once per frame
        public void buy()
        {
            
            
        }
    }
}