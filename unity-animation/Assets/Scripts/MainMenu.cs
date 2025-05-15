using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MainMenu class handles the main menu interactions.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level) // This function is called from the level select buttons
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Level01");
                Debug.Log("Scene One Loaded");
                break;
            case 2:
                SceneManager.LoadScene("Level02");
                break;
            case 3:
                SceneManager.LoadScene("Level03");
                break;
            default:
                Debug.Log("The Scene is non existent");
                break;
        }
    }

    public void Options()
    {
        PlayerPrefs.SetString("Previous", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }

}