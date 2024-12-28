using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    
    public int gold = 999999;

    // tăng sức mạnh đạn
    public int damageBonus = 0;
    public float cooldownBonus = 0;
    public float speedBonus = 0;
    public int amountBonus = 0;
    public float areaBonus; // thêm vào sau
    
    // tăng sm trực tiệp nv
    public int armor = 0;
    public int maxHealth = 100;
    public float moveSpeed = 3f;
    
    public int recovery = 0;
    public int growth = 1;
    public float luck = 0.677f;
}