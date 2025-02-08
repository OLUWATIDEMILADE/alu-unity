using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    /// <summary>
    /// Access TimerText <see cref="GameObject"/>
    /// </summary>
    public Text TimerText; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Timer timer = other.GetComponent<Timer>();
            if (timer != null)
            {
                timer.StopTimer(); 

                // Update the text style
                TimerText.fontSize = 60; // Increase font size
                TimerText.color = Color.green; // Change color to green

                Debug.Log("Player reached WinFlag! Timer stopped.");
            }
        }
    }
}
