using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Pour TextMeshPro
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

// Gère le déroulement de la partie
public class GameManager : MonoBehaviour
{
    public float spawnRate = 1f;
    public List<GameObject> targets; // Liste des préfabriqués (boîtes, bombes) à spawner

    public TextMeshProUGUI scoreText;
    public int score = 0;
    public int nLives = 3;
    public static GameManager instance;
    public List<GameObject> lifeImages;
    public bool gameIsActive = true;
    public GameObject gameOverScreen;
    public AudioSource gameMusic;
    public PausePanel pausePanel;

    // Initialisation de la scène
    void Start()
    {

        instance = this;
        gameOverScreen.SetActive(false);

        // Applique les settings (volume)
        if (gameMusic != null)
        {
            gameMusic.volume = GameSettings.MusicVolume;
        }

        // Charge la sauvegarde si nécessaire
        if (SaveSystem.IsLoadingGame)
        {

            GameState loadedState = SaveSystem.LoadStateFromSave();
            if (loadedState != null)
            {
                score = loadedState.score;
                nLives = loadedState.lives;
                spawnRate = loadedState.difficulty;
            }
        }

        // Lance le jeu
        StartCoroutine(SpawnTargets());
        UpdateScore(); // Init UI
        UpdateLives();

    }

    // Relance une nouvelle partie
    public void RestartGame()
    {
        //SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        SaveSystem.IsLoadingGame = false;
        SceneNavigator.StartGame();

    }

    // Active l'écran Game Over
    public void GameOver()
    {
        gameIsActive = false; // Arrête le spawn
        gameOverScreen.SetActive(true);
    }

    // Gère les inputs (ex: pause)
    private void Update()
    {
        // Input "Escape"
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (gameIsActive && pausePanel != null)
            {

                // Toggle le panel de pause
                if (pausePanel.gameObject.activeSelf)
                {
                    pausePanel.ClosePanel();

                }
                else
                {
                    pausePanel.OpenPanel();

                }
            }
        }

    }

    // (Fonction pause legacy)
    public void SetPause(bool val = true)
    {
        Time.timeScale = val ? 1f : 0f;
    }

    // Logique de score
    public void UpdateScore(int scoreToAdd = 0)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    // Logique des vies
    public void UpdateLives(int livesToAdd = 0)
    {
        nLives += livesToAdd;

        // Gère l'UI des coeurs
        for (int i = 0; i < lifeImages.Count; i++)
        {
            lifeImages[i].SetActive(i < nLives);
        }

        // Check défaite
        if (nLives <= 0) GameOver();
    }

    // Coroutine du spawner
    private IEnumerator SpawnTargets()
    {
        while (gameIsActive)
        {
            yield return new WaitForSeconds(1f / spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}