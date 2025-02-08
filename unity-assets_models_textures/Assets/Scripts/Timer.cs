using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText; // Assign in Inspector
    private float elapsedTime = 0f;
    private bool isRunning = false;

    private void Start()
    {
        // Ensure the time starts at 0:00.00 but does NOT start counting
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);
        TimerText.text = string.Format("{0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
    /// <summary>
    /// Function StartTimer() starts the timer
    /// </summary>
    public void StartTimer()
    {
        if (!isRunning) // Prevents restarting if already running
        {
            isRunning = true;
            Debug.Log("Timer Started!");
        }
    }

    /// <summary>
    /// Function StopTimer() stops the timer
    /// </summary>

    public void StopTimer()
    {
        isRunning = false; // Stops the timer
    }
}
