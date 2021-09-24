using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorController : MonoBehaviour
{
    private Animator maindoorAnim;

    private bool doorOpen = false;

    private void Awake()
    {
        maindoorAnim = gameObject.GetComponent<Animator>();

    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            maindoorAnim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            maindoorAnim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }
}
