using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    
    [Header("UI References")]
    public GameObject continueButton; 
    public GameObject settingsPanel; 

    private SaveSystem saveSystem;

    
    void Start()
    {
        
        saveSystem = FindAnyObjectByType<SaveSystem>();

         
        if (continueButton != null && saveSystem != null)
        {
            
            continueButton.SetActive(saveSystem.CheckHasSave());
        }

        
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }

        
        Time.timeScale = 1f;
    }

   

    public void OnContinueClick()
    {
        
        SaveSystem.IsLoadingGame = true;

        
        SceneNavigator.StartGame();
    }

    public void OnNewGameClick()
    {
        
        SaveSystem.IsLoadingGame = false;
        SceneNavigator.StartGame();
    }

    public void OnSettingsClick()
    {
        OpenSettings(); 
    }

    public void OnQuitClick()
    {
        SceneNavigator.ExitApp(); 
    }

     
    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
           
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
    }
}