using UnityEngine;
using UnityEngine.UI; // Pour UI

// Gère les boutons du menu principal
public class MenuManager : MonoBehaviour
{

    [Header("UI References")]
    public GameObject continueButton; // Bouton "Continuer"
    public GameObject settingsPanel; // Panel "Paramètres"

    private SaveSystem saveSystem; // Réf au SaveSystem (sur Master)


    void Start()
    {

        // Trouve le SaveSystem
        saveSystem = FindAnyObjectByType<SaveSystem>();


        // Gère affichage bouton "Continuer"
        if (continueButton != null && saveSystem != null)
        {

            // Affiche/cache si sauvegarde existe
            continueButton.SetActive(saveSystem.CheckHasSave());
        }


        // Cache le panel settings au start
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }


        // S'assure que le jeu n'est pas en pause
        Time.timeScale = 1f;
    }


    // Bouton: Continuer
    public void OnContinueClick()
    {

        // Met le "flag" pour charger
        SaveSystem.IsLoadingGame = true;


        // Lance la scène de jeu
        SceneNavigator.StartGame();
    }

    // Bouton: Nouvelle Partie
    public void OnNewGameClick()
    {

        // Met le "flag" pour PAS charger
        SaveSystem.IsLoadingGame = false;
        SceneNavigator.StartGame(); // Lance la scène de jeu
    }

    // Bouton: Paramètres
    public void OnSettingsClick()
    {
        OpenSettings(); // Ouvre/ferme panel
    }

    // Bouton: Quitter
    public void OnQuitClick()
    {
        SceneNavigator.ExitApp(); // Ferme le .exe
    }


    // Ouvre/ferme le panel des settings
    public void OpenSettings()
    {
        if (settingsPanel != null)
        {

            // Inverse l'état (toggle)
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
    }
}