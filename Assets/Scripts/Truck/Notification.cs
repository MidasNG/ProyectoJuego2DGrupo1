using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    private Animator animator;
    private bool ongoing = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerNotif()
    {
        if (ongoing)
        {
            animator.SetTrigger("Stop");
            ongoing = false;
        }
        new WaitForEndOfFrame();
        animator.SetTrigger("Notification");
        ongoing = true;
    }

    private void NotifEnd()
    {
        ongoing = false;
    }
}
