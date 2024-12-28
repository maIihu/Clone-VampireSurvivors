using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    

}