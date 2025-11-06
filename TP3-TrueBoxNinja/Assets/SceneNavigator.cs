using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger les scènes

// Fonctions statiques pour changer de scène
public class SceneNavigator : MonoBehaviour
{

    // Charge la scène Menu
    public static void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    // Charge la scène Game
    public static void StartGame()
    {
        SceneManager.LoadScene("Game");
    }


    // Ferme l'application (.exe)
    public static void ExitApp()
    {
        // (Marche seulement dans le build, pas dans l'éditeur)
        Application.Quit();
    }
}