using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public Text FinalTime;
    private float elapsedTime = 0f;
    private bool isPlaying = false;
    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            elapsedTime += Time.deltaTime;
            SetUI(elapsedTime);
        }
    }

    public void StartTimer()
    {
        isPlaying = true;
    }

    public void StopTimer()
    {
        isPlaying = false;
        TimerText.color = Color.green;
        TimerText.fontSize = 60;
        Win();
    }

    void SetUI(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 100F) % 100F);

        TimerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    public void Win()
    {
        FinalTime.text = TimerText.text;
    }
}