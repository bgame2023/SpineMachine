using UnityEngine;

// Singleton pattern for Data
public class Data : MonoBehaviour
{
    private static Data instance;

    private const string key_coinbalance = "coinbl";
    public static Data Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Data>();
                if (instance == null)
                {
                    GameObject go = new GameObject("Data");
                    instance = go.AddComponent<Data>();
                }
            }
            return instance;
        }
    }

    // Your data properties or methods go here


    // Example method to save player data
    public void SaverCoinBalance(int score)
    {
        PlayerPrefs.SetInt(key_coinbalance, score);
        PlayerPrefs.Save();
    }

    // Example method to load player data
    public int GetCoinBalance()
    {
        return PlayerPrefs.GetInt(key_coinbalance, 1000000);

    }
}