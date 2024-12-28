using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject upgradePanel;
    public GameObject upgradeSlot1;
    public GameObject upgradeSlot2;
    public GameObject upgradeSlot3;
    
    public List<GameObject> upgradeArmorPrefabs;
    public List<GameObject> upgradeCloverPrefabs;
    public List<GameObject> upgradeCrossPrefabs;
    public List<GameObject> upgradeCrownPrefabs;
    public List<GameObject> upgradeFireballPrefabs;
    public List<GameObject> upgradeHeartPrefabs;
    public List<GameObject> upgradeHollowHeartPrefabs;
    public List<GameObject> upgradeHolyWaterPrefabs;
    public List<GameObject> upgradeKnifePrefabs;
    public List<GameObject> upgradeMagicBookPrefabs;
    public List<GameObject> upgradeWingsPrefabs;
    
    private List<KeyValuePair<string, int>> upgradeList = new List<KeyValuePair<string, int>>()
    {
        new KeyValuePair<string,int> ("Armor", 2),
        new KeyValuePair<string,int> ("Clover",2),
        new KeyValuePair<string, int>("Cross", 4),
        new KeyValuePair<string,int> ("Crown", 2),
        new KeyValuePair<string, int>("Fireball", 4),
        new KeyValuePair<string,int> ("Heart", 2),
        new KeyValuePair<string,int> ("HollowHeart", 2),
        new KeyValuePair<string, int>("HolyWater", 4),
        new KeyValuePair<string,int> ("Knife", 4),
        new KeyValuePair<string,int> ("MagicBook", 4),
        new KeyValuePair<string,int> ("Wings", 2)
    };
    
    public bool isUpgrades = false;
    
    public bool isUpdateFireball = false;
    public bool isUpdateHolyWater = false;
    public bool isUpdateCross = false;
    public bool isUpdateSword = false;
    public bool isUpdateMagicBook = false;
    public bool isUpdateKnife = false;
    public bool isUpdateDamage = false;

    private AudioManager audioManager;
    private int slot1, slot2, slot3;
    
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        upgradePanel.SetActive(false);
    }

    private void Update()
    {
        if (playerController.LevelUp) 
        {
            audioManager.PlaySfx(audioManager.levelUp);
            LevelUp();
        }
        
    }

    private void LevelUp()
    {
        isUpgrades = !isUpgrades;
        
        upgradePanel.SetActive(isUpgrades);

        if (isUpgrades)
        {
            ShowRandomUpgrades();
        }
    }

    private void ShowRandomUpgrades()
    {
        // Xóa các nâng cấp cũ
        foreach (Transform child in upgradeSlot1.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in upgradeSlot2.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in upgradeSlot3.transform)
        {
            Destroy(child.gameObject);
        }


        slot1 = Random.Range(0, upgradeList.Count);

        
        
        do
        {
            slot2 = Random.Range(0, upgradeList.Count);
        } while (slot1 == slot2);


        do
        {
            slot3 = Random.Range(0, upgradeList.Count);
        } while (slot3 == slot1 || slot3 == slot2);

        // slot 1
        if (upgradeList[slot1].Key == "Armor")
        {
            foreach (var y in upgradeArmorPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "Clover")
        {
            foreach (var y in upgradeCloverPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "Cross")
        {
            foreach (var y in upgradeCrossPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "Crown")
        {
            foreach (var y in upgradeCrownPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "Fireball")
        {
            foreach (var y in upgradeFireballPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "Heart")
        {
            foreach (var y in upgradeHeartPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "HollowHeart")
        {
            foreach (var y in upgradeHollowHeartPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "HolyWater")
        {
            foreach (var y in upgradeHolyWaterPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "Knife")
        {
            foreach (var y in upgradeKnifePrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "MagicBook")
        {
            foreach (var y in upgradeMagicBookPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }
        else if (upgradeList[slot1].Key == "Wings")
        {
            foreach (var y in upgradeWingsPrefabs)
            {
                Instantiate(y, upgradeSlot1.transform);
                break;
            }
        }


        // slot 2
        if (upgradeList[slot2].Key == "Armor")
        {
            foreach (var y in upgradeArmorPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "Clover")
        {
            foreach (var y in upgradeCloverPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "Cross")
        {
            foreach (var y in upgradeCrossPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "Crown")
        {
            foreach (var y in upgradeCrownPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "Fireball")
        {
            foreach (var y in upgradeFireballPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "Heart")
        {
            foreach (var y in upgradeHeartPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "HollowHeart")
        {
            foreach (var y in upgradeHollowHeartPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "HolyWater")
        {
            foreach (var y in upgradeHolyWaterPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "Knife")
        {
            foreach (var y in upgradeKnifePrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "MagicBook")
        {
            foreach (var y in upgradeMagicBookPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }
        else if (upgradeList[slot2].Key == "Wings")
        {
            foreach (var y in upgradeWingsPrefabs)
            {
                Instantiate(y, upgradeSlot2.transform);
                break;
            }
        }


        // slot 3
        if (upgradeList[slot3].Key == "Armor")
        {
            foreach (var y in upgradeArmorPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "Clover")
        {
            foreach (var y in upgradeCloverPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "Cross")
        {
            foreach (var y in upgradeCrossPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "Crown")
        {
            foreach (var y in upgradeCrownPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "Fireball")
        {
            foreach (var y in upgradeFireballPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "Heart")
        {
            foreach (var y in upgradeHeartPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "HollowHeart")
        {
            foreach (var y in upgradeHollowHeartPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "HolyWater")
        {
            foreach (var y in upgradeHolyWaterPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "Knife")
        {
            foreach (var y in upgradeKnifePrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "MagicBook")
        {
            foreach (var y in upgradeMagicBookPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
        else if (upgradeList[slot3].Key == "Wings")
        {
            foreach (var y in upgradeWingsPrefabs)
            {
                Instantiate(y, upgradeSlot3.transform);
                break;
            }
        }
    }

    public void ChooseUpgrade1()
    {
        GameObject upgradePrefab = upgradeSlot1.transform.GetChild(0).gameObject;
        PowerUp(upgradePrefab.tag);
        if(upgradeList[slot1].Key == "Armor")
        {
            upgradeArmorPrefabs.RemoveAt(0);
            if (upgradeArmorPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Armor");
            }
        }
        else if(upgradeList[slot1].Key == "Clover")
        {
            upgradeCloverPrefabs.RemoveAt(0);
            if (upgradeCloverPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Clover");
            }
        }
        else if(upgradeList[slot1].Key == "Cross")
        {
            upgradeCrossPrefabs.RemoveAt(0);
            if (upgradeCrossPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Cross");
            }
        }
        else if(upgradeList[slot1].Key == "Crown")
        {
            upgradeCrownPrefabs.RemoveAt(0);
            if (upgradeCrownPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Crown");
            }
        }
        else if(upgradeList[slot1].Key == "Fireball")
        {
            upgradeFireballPrefabs.RemoveAt(0);
            if (upgradeFireballPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Fireball");
            }
        }
        else if(upgradeList[slot1].Key == "Heart")
        {
            upgradeHeartPrefabs.RemoveAt(0);
            if (upgradeHeartPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Heart");
            }
        }
        else if(upgradeList[slot1].Key == "HollowHeart")
        {
            upgradeHollowHeartPrefabs.RemoveAt(0);
            if (upgradeHollowHeartPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "HollowHeart");
            }
        }
        else if(upgradeList[slot1].Key == "HolyWater")
        {
            upgradeHolyWaterPrefabs.RemoveAt(0);
            if (upgradeHolyWaterPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "HolyWater");
            }
        }
        else if(upgradeList[slot1].Key == "Knife")
        {
            upgradeKnifePrefabs.RemoveAt(0);
            if (upgradeKnifePrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Knife");
            }
        }
        else if(upgradeList[slot1].Key == "MagicBook")
        {
            upgradeMagicBookPrefabs.RemoveAt(0);
            if (upgradeMagicBookPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "MagicBook");
            }
        }
        else if(upgradeList[slot1].Key == "Wings")
        {
            upgradeWingsPrefabs.RemoveAt(0);
            if (upgradeWingsPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Wings");
            }
        }
        CloseUpgradePanel();
    }

    public void ChooseUpgrade2()
    {
        GameObject upgradePrefab = upgradeSlot2.transform.GetChild(0).gameObject;
        PowerUp(upgradePrefab.tag);
        if(upgradeList[slot2].Key == "Armor")
        {
            upgradeArmorPrefabs.RemoveAt(0);
            if (upgradeArmorPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Armor");
            }
        }
        else if(upgradeList[slot2].Key == "Clover")
        {
            upgradeCloverPrefabs.RemoveAt(0);
            if (upgradeCloverPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Clover");
            }
        }
        else if(upgradeList[slot2].Key == "Cross")
        {
            upgradeCrossPrefabs.RemoveAt(0);
            if (upgradeCrossPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Cross");
            }
        }
        else if(upgradeList[slot2].Key == "Crown")
        {
            upgradeCrownPrefabs.RemoveAt(0);
            if (upgradeCrownPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Crown");
            }
        }
        else if(upgradeList[slot2].Key == "Fireball")
        {
            upgradeFireballPrefabs.RemoveAt(0);
            if (upgradeFireballPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Fireball");
            }
        }
        else if(upgradeList[slot2].Key == "Heart")
        {
            upgradeHeartPrefabs.RemoveAt(0);
            if (upgradeHeartPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Heart");
            }
        }
        else if(upgradeList[slot2].Key == "HollowHeart")
        {
            upgradeHollowHeartPrefabs.RemoveAt(0);
            if (upgradeHollowHeartPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "HollowHeart");
            }
        }
        else if(upgradeList[slot2].Key == "HolyWater")
        {
            upgradeHolyWaterPrefabs.RemoveAt(0);
            if (upgradeHolyWaterPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "HolyWater");
            }
        }
        else if(upgradeList[slot2].Key == "Knife")
        {
            upgradeKnifePrefabs.RemoveAt(0);
            if (upgradeKnifePrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Knife");
            }
        }
        else if(upgradeList[slot2].Key == "MagicBook")
        {
            upgradeMagicBookPrefabs.RemoveAt(0);
            if (upgradeMagicBookPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "MagicBook");
            }
        }
        else if(upgradeList[slot2].Key == "Wings")
        {
            upgradeWingsPrefabs.RemoveAt(0);
            if (upgradeWingsPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Wings");
            }
        }
        CloseUpgradePanel();
    }

    public void ChooseUpgrade3()
    {
        GameObject upgradePrefab = upgradeSlot3.transform.GetChild(0).gameObject;
        PowerUp(upgradePrefab.tag);
        if(upgradeList[slot3].Key == "Armor")
        {
            upgradeArmorPrefabs.RemoveAt(0);
            if (upgradeArmorPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Armor");
            }
        }
        else if(upgradeList[slot3].Key == "Clover")
        {
            upgradeCloverPrefabs.RemoveAt(0);
            if (upgradeCloverPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Clover");
            }
        }
        else if(upgradeList[slot3].Key == "Cross")
        {
            upgradeCrossPrefabs.RemoveAt(0);
            if (upgradeCrossPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Cross");
            }
        }
        else if(upgradeList[slot3].Key == "Crown")
        {
            upgradeCrownPrefabs.RemoveAt(0);
            if (upgradeCrownPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Crown");
            }
        }
        else if(upgradeList[slot3].Key == "Fireball")
        {
            upgradeFireballPrefabs.RemoveAt(0);
            if (upgradeFireballPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Fireball");
            }
        }
        else if(upgradeList[slot3].Key == "Heart")
        {
            upgradeHeartPrefabs.RemoveAt(0);
            if (upgradeHeartPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Heart");
            }
        }
        else if(upgradeList[slot3].Key == "HollowHeart")
        {
            upgradeHollowHeartPrefabs.RemoveAt(0);
            if (upgradeHollowHeartPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "HollowHeart");
            }
        }
        else if(upgradeList[slot3].Key == "HolyWater")
        {
            upgradeHolyWaterPrefabs.RemoveAt(0);
            if (upgradeHolyWaterPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "HolyWater");
            }
        }
        else if(upgradeList[slot3].Key == "Knife")
        {
            upgradeKnifePrefabs.RemoveAt(0);
            if (upgradeKnifePrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Knife");
            }
        }
        else if(upgradeList[slot3].Key == "MagicBook")
        {
            upgradeMagicBookPrefabs.RemoveAt(0);
            if (upgradeMagicBookPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "MagicBook");
            }
        }
        else if(upgradeList[slot3].Key == "Wings")
        {
            upgradeWingsPrefabs.RemoveAt(0);
            if (upgradeWingsPrefabs.Count == 0)
            {
                upgradeList.RemoveAll(pair => pair.Key == "Wings");
            }
        }
        CloseUpgradePanel();
    }

    private void CloseUpgradePanel()
    {
        isUpgrades = false;
        upgradePanel.SetActive(false);
        Time.timeScale = 1; // Tiếp tục gameplay
    }

    private void PowerUp(string tagObject)
    {
        switch (tagObject)
        {
            case "Heart":
                playerController.MaxHealth += 10;
                break;
            case "Wing":
                playerController.MoveSpeed *= (float)1.01;
                break;
            case "Armor":
                playerController.Armor++;
                break;
            case "Grown":
                playerController.Growth++;
                break;
            case "Spinach":
                isUpdateDamage = true;
                break;
            case "Recovery":
                playerController.Recovery++;
                break;
            case "Clover":
                playerController.Luck *= (float)1.01;
                break;
            case "FireBall":
                isUpdateFireball = true;
                break; 
            case "HolyWater":
                isUpdateHolyWater = true;
                break;
            case "Cross":
                isUpdateCross = true;
                break;
            case "Sword":
                isUpdateSword = true;
                break;
            case "MagicBook":
                isUpdateMagicBook = true;
                break;
            case "Knife":
                isUpdateKnife = true;
                break;
                
        }
    }

}
