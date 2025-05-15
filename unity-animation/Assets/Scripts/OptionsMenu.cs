using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertY;
    private string previousScene;
    private bool invert;

    private void Start()
    {
        previousScene = PlayerPrefs.GetString("Previous", "MainMenu");
        invertY.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;
    }

    public void Back()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void Apply()
    {
        invert = invertY.isOn;
        PlayerPrefs.SetInt("InvertY", invert ? 1 : 0);
        SceneManager.LoadScene(previousScene);
    }




}