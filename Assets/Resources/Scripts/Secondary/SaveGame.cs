using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public bool isGame = true;
    public int saveLevel = -1;
    private void Awake()
    {
        if (!isGame)
        {
            if (PlayerPrefs.HasKey("SavedLevel"))
            {
                int lvl = PlayerPrefs.GetInt("SavedLevel");
                SceneManager.LoadScene("Level_" + lvl.ToString());
            }
            else
            {
                SceneManager.LoadScene("Level_1");
            }
        }
        else {
            if (saveLevel != -1) {
                SaveLevel(saveLevel);
            }
        }
        
    }

    public static void SaveLevel(int lvl) {
        PlayerPrefs.SetInt("SavedLevel", lvl);
    }
}
