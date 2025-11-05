using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    
    public static void GoToMenu()
    { 
        SceneManager.LoadScene("Menu");
    }

    
    public static void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    
    public static void ExitApp()
    {
        Application.Quit();
    }
}