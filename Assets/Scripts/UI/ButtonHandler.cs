using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public TextMeshProUGUI textBio;
    public TextMeshProUGUI textCost;
    

    public void BackButton()
    {
        SceneManager.LoadScene("Main Game"); 
    }
    
    public void SetTextButton1()
    {
        textBio.text = "Might - Raises inflicted Damage by 5% per rank (max +25%).";
        //textCost.text = "200";
    }
    public void SetTextButton2()
    {
        textBio.text = "Armor - Reduces incoming Damage by 1 per rank (max +3)";
    }
    public void SetTextButton3()
    {
        textBio.text = "Max Health - Augments Max Health by 10% per rank (max +30%).";
    }
    public void SetTextButton4()
    {
        textBio.text = "Recovery - Recovers 0.1 HP per rank (max 0.5 HP) per second.";
    }
    public void SetTextButton5()
    {
        textBio.text = "Cooldown - Uses weapons 2.5% faster per rank (max 5%).";
    }
    public void SetTextButton6()
    {
        textBio.text = "Area - Augments area of attacks by 5% per rank (max +10%).";
    }
    public void SetTextButton7()
    {
        textBio.text = "Speed - Projectiles move 10% faster per rank (max +20%).";
    }
    public void SetTextButton8()
    {
        textBio.text = "Growth - Gains 3% more experience per rank (max +15%).";
    }
    public void SetTextButton9()
    {
        textBio.text = "Amount - Fires 1 more projectile (all weapons).";
    }
    public void SetTextButton10()
    {
        textBio.text = "MoveSpeed - Character moves 5% faster per rank (max 10%).";
    }
    public void SetTextButton11()
    {
        textBio.text = "Magnet - Items pickup range +25% per rank (max +50%).";
    }
    public void SetTextButton12()
    {
        textBio.text = "Luck - Chance to get lucky goes up by 10% per rank (max +30%).";
    }
    
}