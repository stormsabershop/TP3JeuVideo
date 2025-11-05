using UnityEngine;

public class GameSettings : MonoBehaviour
{
    
    private const string VOLUME_KEY = "MusicVolume";
    private const string PARTICLES_KEY = "ShowParticles";

    public static float MusicVolume { get; private set; } 
    public static bool ShowParticles { get; private set; } 

    
    void Awake()
    {  
        MusicVolume = PlayerPrefs.GetFloat(VOLUME_KEY, 1.0f);
        ShowParticles = PlayerPrefs.GetInt(PARTICLES_KEY, 1) == 1;
    }

    
    public static void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
        PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        PlayerPrefs.Save(); 
    }

    
    public static void SetShowParticles(bool show)
    {
        ShowParticles = show;
        PlayerPrefs.SetInt(PARTICLES_KEY, show ? 1 : 0);
        PlayerPrefs.Save(); 
    }
}