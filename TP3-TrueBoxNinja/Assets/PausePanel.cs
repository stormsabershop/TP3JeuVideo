using UnityEngine;

// Gère le panel de pause
public class PausePanel : MonoBehaviour
{
    private GameManager gameManager; // Réf GM

    void Start()
    {
        // Trouve GM
        gameManager = FindAnyObjectByType<GameManager>();

        // Cacher au start
        gameObject.SetActive(false);
    }

    // Ouvre panel
    public void OpenPanel()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f; // PAUSE
    }

    // Ferme panel
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f; // PLAY
    }

    // --- Boutons ---

    // Bouton: Retour Jeu
    public void OnReturnToGameClick()
    {
        ClosePanel();
    }

    // Bouton: Sauvegarder
    public void OnSaveGameClick()
    {
        if (gameManager == null) return;

        // Prépare les données de sauvegarde
        GameState state = new GameState
        {
            score = gameManager.score,
            lives = gameManager.nLives,
            difficulty = gameManager.spawnRate
        };

        // Sauvegarde
        SaveSystem.SaveGame(state);
        Debug.Log("Partie sauvegardée !");
    }

    // Bouton: Retour Menu
    public void OnReturnToMenuClick()
    {
        Time.timeScale = 1f; // IMPORTANT: reset time
        SceneNavigator.GoToMenu();
    }

    // Bouton: Quitter
    public void OnQuitGameClick()
    {
        SceneNavigator.ExitApp();
    }
}