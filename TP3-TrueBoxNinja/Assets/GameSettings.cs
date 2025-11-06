using UnityEngine;

// Gère les settings du joueur (Volume, Particules) via PlayerPrefs
public class GameSettings : MonoBehaviour
{

    // Clés pour PlayerPrefs
    private const string VOLUME_KEY = "MusicVolume";
    private const string PARTICLES_KEY = "ShowParticles";

    // Variables statiques pour accès global
    public static float MusicVolume { get; private set; }
    public static bool ShowParticles { get; private set; }


    // Au lancement, charge les settings
    void Awake()
    {
        // Charge le volume (défaut 1.0)
        MusicVolume = PlayerPrefs.GetFloat(VOLUME_KEY, 1.0f);
        // Charge les particules (défaut 1 = true)
        ShowParticles = PlayerPrefs.GetInt(PARTICLES_KEY, 1) == 1;
    }


    // Update et sauvegarde le volume
    public static void SetMusicVolume(float volume)
    {
        MusicVolume = volume; // Update statique
        PlayerPrefs.SetFloat(VOLUME_KEY, volume); // Sauvegarde PlayerPrefs
        PlayerPrefs.Save();
    }


    // Update et sauvegarde les particules
    public static void SetShowParticles(bool show)
    {
        ShowParticles = show; // Update statique
        PlayerPrefs.SetInt(PARTICLES_KEY, show ? 1 : 0); // Sauvegarde (1 ou 0)
        PlayerPrefs.Save();
    }
}