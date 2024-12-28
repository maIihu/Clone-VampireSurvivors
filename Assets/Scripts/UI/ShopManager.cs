using System;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PowerParameter
{
    public string Name;
    public int Level;
    public int Cost;
    public int MaxLevel;
    
    public PowerParameter(string name, int level, int cost, int maxLevel)
    {
        Name = name;
        Level = level;
        Cost = cost;
        MaxLevel = maxLevel;
    }
}

public class ShopManager : MonoBehaviour
{
    public PlayerStats playerStats;
    
    public List<Button> buttons;
    public Button buyButton;
    
    private string selectedItem;
    public TextMeshProUGUI textCost;
    public TextMeshProUGUI textLevel;

    public Text goldCountText;
    
    private PowerParameter[] arrayParameters = new PowerParameter[]
    {
        new PowerParameter("Button1", 0, 200, 5),
        new PowerParameter("Button2", 0, 600, 3),
        new PowerParameter("Button3", 0, 200, 3),
        new PowerParameter("Button4", 0, 200, 5),
        new PowerParameter("Button5", 0, 900, 2),
        new PowerParameter("Button6", 0, 300, 2),
        new PowerParameter("Button7", 0, 300, 2),
        new PowerParameter("Button8", 0, 900, 5),
        new PowerParameter("Button9", 0, 5000, 1),
        new PowerParameter("Button10", 0, 300, 2),
        new PowerParameter("Button11", 0, 300, 2),
        new PowerParameter("Button12", 0, 600, 3),
        
    };

    private void Awake()
    {
        playerStats = FindObjectOfType<GameManager>().playerStats;
        
    }

    void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => SelectItem(button.tag));
        }
        buyButton.onClick.AddListener(BuySelectedItem);
    }

    private void Update()
    {
        goldCountText.text = playerStats.gold.ToString();
        
        foreach (var x in arrayParameters)
        {
            if (x.Name == selectedItem)
            {
                textCost.text = (x.Cost +  x.Cost * x.Level * 1.4).ToString();
                textLevel.text = "Level " + x.Level;
            }
        }
    }

    void SelectItem(string item)
    {
        selectedItem = item;
        //Debug.Log("Selected item: " + selectedItem);
    }

    void BuySelectedItem()
    {
        if (string.IsNullOrEmpty(selectedItem))
        {
            //Debug.Log("No item selected!");
            return;
        }

        //Debug.Log("Bought item: " + selectedItem);
        
        for (int i = 0; i < arrayParameters.Length; i++)
        {
            PowerParameter temp = arrayParameters[i];
            
            if (temp.Name == selectedItem)
            {
                if (temp.Cost > playerStats.gold) return; // nếu không đủ tiền mua
                if (temp.Level >= temp.MaxLevel) return; // quá lv không thể nâng cấp
                arrayParameters[i] = new PowerParameter(temp.Name, temp.Level + 1, temp.Cost, temp.MaxLevel);
                UpgradePower(temp.Name);
                playerStats.gold -= temp.Cost;
            }
            
        }

    }

    void UpgradePower(string namePower)
    {
        switch (namePower)
        {
            case "Button1":
                playerStats.damageBonus++;
                break;
            case "Button2" :
                playerStats.armor++; 
                break;
            case "Button3" :
                playerStats.maxHealth += 10;
               // Debug.Log(playerStats.health);
                break;
            case "Button4" :
                playerStats.recovery++;
                break;
            case "Button5" :
                playerStats.cooldownBonus += (float)0.25;
                break;
            case "Button6" :
                // area power up
                break;
            case "Button7" :
                playerStats.speedBonus += (float)0.1;
                break;
            case "Button8" :
                playerStats.growth++;
                break;
            case "Button9" :
                playerStats.amountBonus++;
                break;
            case "Button10" :
                playerStats.moveSpeed *= (float)1.05;
                break;
            case "Button11" :
                // magnet up
                break;
            case "Button12" :
                playerStats.luck *= (float)1.1;
                break;
        }
    }
}