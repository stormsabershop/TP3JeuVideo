using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger les scènes

// Gère le 'singleton' du Master object
public class DontDestroyOnLoad : MonoBehaviour
{

    // Flag statique pour check si un 'Master' existe déjà
    private static bool created = false;

    void Awake()
    {

        // Si aucun 'Master' n'existe...
        if (!created)
        {
            // ...on dit à Unity de ne pas le détruire
            DontDestroyOnLoad(gameObject);
            created = true;
            // Charge le menu (scène de démarrage)
            SceneManager.LoadScene("Menu");
        }
        else
        {
            // Si un 'Master' existe déjà, on détruit ce doublon
            Destroy(gameObject);
        }
    }
}