using UnityEngine;

public class PanelUIManager : MonoBehaviour
{
    private UpgradeManager upgradeManager;
    private PauseMenu pauseMenu;
    private PlayerController playerController;
    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;
    
    public bool isGameRunning = false;

    private float startTime;
    public float deltaTime;
    
    private void Awake()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
        isGameRunning = true;
        startTime = Time.time;
    }

    private void Update()
    {
        if (isGameRunning)
        {
            deltaTime = Time.time - startTime;
        }
        
        
        if (upgradeManager.isUpgrades)
        {
            Time.timeScale = 0f;
            isGameRunning = false;
        }
        else if (pauseMenu.gameIsPaused)
        {
            Time.timeScale = 0f;
            isGameRunning = false;
        }
        else if (playerController.isDead)
        {
            Time.timeScale = 0f;
            isGameRunning = false;
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }
        else if ((int)deltaTime / 60 == 5)
        {
            Time.timeScale = 0f;
            isGameRunning = false;
            if(victoryPanel != null) victoryPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            isGameRunning = true;
        }
    }
}
