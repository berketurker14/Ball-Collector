using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThatPanelClose : MonoBehaviour
{

    public GameObject[] thatPanel;
    public Button[] thatButtons;

    // Update is called once per frame

    public void Start()
    {
        thatButtons[0].onClick.AddListener(ClosePanelOne);
        thatButtons[1].onClick.AddListener(ClosePanelTwo);
    }

    public void ClosePanelOne()
    {
        thatPanel[0].SetActive(false);
    }
    public void ClosePanelTwo()
    {
        thatPanel[1].SetActive(false);
    }
}
