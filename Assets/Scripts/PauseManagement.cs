using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManagement : MonoBehaviour
{
    public Button ballUpgradeButton;
    public Button wealthUpgradeButton;
    public Button damageUpgradeButton;
    //from pause to start button
    public Button startAgainButton;
    public bool paused;
    private void Start()
    {
        startAgainButton.onClick.AddListener(StartAgain);
        ballUpgradeButton.onClick.AddListener(Pause);
        wealthUpgradeButton.onClick.AddListener(Pause);
        damageUpgradeButton.onClick.AddListener(Pause);
    }
    private void Pause()
    {
        startAgainButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }
    void StartAgain()
    {
        startAgainButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
}
