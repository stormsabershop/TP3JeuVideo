using UnityEngine;
using System.IO; 
using Newtonsoft.Json; 

[System.Serializable]
public class GameState
{
    public int score;
    public int lives; 
    public float difficulty; 
}

public class SaveSystem : MonoBehaviour
{
    
    public static bool IsLoadingGame = false;

   
    private static string savePath => Path.Combine(Application.persistentDataPath, "gamesave.json");

   
    public static void SaveGame(GameState state)
    {
        string json = JsonConvert.SerializeObject(state, Formatting.Indented);
        File.WriteAllText(savePath, json);
        Debug.Log("Partie sauvegardée dans: " + savePath);
    }

    
    public bool CheckHasSave()
    {
        return File.Exists(savePath);
    }

    
    public static GameState LoadStateFromSave()
    {
        
        if (File.Exists(savePath))
        {
            
            string json = File.ReadAllText(savePath);

            
            return JsonConvert.DeserializeObject<GameState>(json);
        }
        else
        {
            Debug.LogWarning("Fichier de sauvegarde non trouvé à: " + savePath);
            return null;
        }
    }
}