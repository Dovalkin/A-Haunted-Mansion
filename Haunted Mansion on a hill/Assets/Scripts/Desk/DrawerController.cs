using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    private Animator drawerAnim;

    private bool drawerOpen = false;

    private void Awake()
    {
        drawerAnim = gameObject.GetComponent<Animator>();

    }

    public void PlayAnimation()
    {
        if (!drawerOpen)
        {
            drawerAnim.Play("DrawerPulling", 0, 0.0f);
            drawerOpen = true;
        }
        else
        {
            drawerAnim.Play("DrawerClosing", 0, 0.0f);
            drawerOpen = false;
        }
    }
}
