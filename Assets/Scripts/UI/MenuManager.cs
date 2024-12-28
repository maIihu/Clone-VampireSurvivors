using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GamePlayScene()
    {
        SceneManager.LoadScene("Game Play"); 
    }

    public void OptionScene()
    {
        SceneManager.LoadScene("Options"); 
    }

    public void PowerUpScene()
    {
        SceneManager.LoadScene("PowerUp");
    }

}