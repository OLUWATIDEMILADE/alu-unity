using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    Animator animator;
    public Camera mainCamera;
    public GameObject timerCanvas;
    public GameObject Player;
    public GameObject cutsceneCamera;
    void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera.enabled = false;
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if ((stateInfo.IsName("Intro01") || stateInfo.IsName("Intro02") || stateInfo.IsName("Intro03")) && stateInfo.normalizedTime >= 1.0f)
        {
            Debug.Log("Animation has finished Playing");
            timerCanvas.SetActive(true);
            mainCamera.gameObject.SetActive(true);
            mainCamera.enabled = true;
            Player.GetComponent<PlayerController>().enabled = true;
            this.enabled = false;
            cutsceneCamera.SetActive(false);
        }

    }
}