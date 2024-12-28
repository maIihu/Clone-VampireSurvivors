using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SetTextUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI goldCountText;
    public TextMeshProUGUI levelText;
    
    
    private int enemyCount = 0;

    private PanelUIManager panelUIManager;

    private void Awake()
    {
        panelUIManager = FindObjectOfType<PanelUIManager>();
    }

    public void UpdateKillUI()
    {
        enemyCount++;
        killCountText.text =  "" + enemyCount;
    }
    public void UpdateGoldUI(int goldValue)
    {
        goldCountText.text =  "" + goldValue;
    }
   

    public void UpdateLevelText(int level)
    {
        levelText.text = "LV " + level.ToString();
    }
    

    private void Update()
    {
        if (panelUIManager.isGameRunning)
        {
            string minutes = ((int)panelUIManager.deltaTime / 60).ToString("00");
            string seconds = (panelUIManager.deltaTime % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;
        }
    }
    
}