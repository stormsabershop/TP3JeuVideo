using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        
        gameManager = FindAnyObjectByType<GameManager>();

        
        gameObject.SetActive(false);
    }

    
    public void OpenPanel()
    {
       
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f; 
    }

    
   

    
    public void OnReturnToGameClick()
    {
        ClosePanel();
    }

    
    public void OnSaveGameClick()
    {
        if (gameManager == null) return;

       
        GameState state = new GameState
        {
            score = gameManager.score,
            lives = gameManager.nLives, 
            difficulty = gameManager.spawnRate 
        };

        
        SaveSystem.SaveGame(state);
        Debug.Log("Partie sauvegardée !");
    }

    
    public void OnReturnToMenuClick()
    {
        Time.timeScale = 1f; 
        SceneNavigator.GoToMenu();
    }

    
    public void OnQuitGameClick()
    {
        SceneNavigator.ExitApp();
    }
}