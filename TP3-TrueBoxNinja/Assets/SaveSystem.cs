using UnityEngine;
using System.IO; // Pour gestion fichiers (read/write)
using Newtonsoft.Json; // Pour sérialisation JSON
// Classe qui contient les données de sauvegarde [cite: 68]
[System.Serializable]
public class GameState
{
    public int score;
    public int lives;
    public float difficulty;
}

// Gère la sauvegarde/chargement en JSON
public class SaveSystem : MonoBehaviour
{

    // Flag global pour dire au GameManager s'il doit charger
    public static bool IsLoadingGame = false;


    // Chemin du fichier de sauvegarde
    private static string savePath => Path.Combine(Application.persistentDataPath, "gamesave.json");


    // Sauvegarde l'état (GameState) dans un fichier JSON [cite: 69]
    public static void SaveGame(GameState state)
    {
        // Convertit l'objet en string JSON
        string json = JsonConvert.SerializeObject(state, Formatting.Indented);
        // Écrit le string dans le fichier
        File.WriteAllText(savePath, json);
        Debug.Log("Partie sauvegardée dans: " + savePath);
    }


    // Vérifie si un fichier de sauvegarde existe [cite: 70]
    public bool CheckHasSave()
    {
        return File.Exists(savePath);
    }


    // Charge le GameState depuis le fichier JSON [cite: 71]
    public static GameState LoadStateFromSave()
    {

        // Vérifie si le fichier existe
        if (File.Exists(savePath))
        {

            // Lit le fichier
            string json = File.ReadAllText(savePath);


            // Convertit le JSON en objet GameState et le retourne
            return JsonConvert.DeserializeObject<GameState>(json);
        }
        else
        {
            // Pas de sauvegarde trouvée
            Debug.LogWarning("Fichier de sauvegarde non trouvé à: " + savePath);
            return null;
        }
    }
}