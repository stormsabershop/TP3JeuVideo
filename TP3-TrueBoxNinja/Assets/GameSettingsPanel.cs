using UnityEngine;
using UnityEngine.UI; // Pour UI (Slider, Toggle)

// Gère le panel des settings (options)
public class GameSettingsPanel : MonoBehaviour
{

    [Header("UI Handles")]
    public Slider volumeSlider; // Réf slider volume
    public Toggle particlesToggle; // Réf toggle particules



    void Start()
    {

        // Init le slider avec la valeur sauvegardée
        if (volumeSlider != null)
        {
            volumeSlider.value = GameSettings.MusicVolume;
        }

        // Init le toggle avec la valeur sauvegardée
        if (particlesToggle != null)
        {
            particlesToggle.isOn = GameSettings.ShowParticles;
        }


        // Ajoute les listeners pour update auto
        volumeSlider.onValueChanged.AddListener(UpdateVolume);


        particlesToggle.onValueChanged.AddListener(UpdateParticles);
    }


    // Appelé par le listener du slider
    public void UpdateVolume(float value)
    {

        // Sauvegarde le setting
        GameSettings.SetMusicVolume(value);
    }


    // Appelé par le listener du toggle
    public void UpdateParticles(bool value)
    {

        // Sauvegarde le setting
        GameSettings.SetShowParticles(value);
    }


    // Bouton 'X' pour fermer
    public void ClosePanel()
    {

        // Désactive ce panel
        gameObject.SetActive(false);
    }
}