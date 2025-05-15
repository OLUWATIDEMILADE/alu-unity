using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Timer timer = other.GetComponent<Timer>();
            if (timer != null)
            {
                timer.StartTimer();
            }
        }
    }
}
