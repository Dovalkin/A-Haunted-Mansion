using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    public AudioSource source;
    public AudioSource closesource;
    public AudioClip clip;
    public AudioClip closeclip;

    private Animator doorAnim;

    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        closesource = GetComponent<AudioSource>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            source.PlayOneShot(clip);
            doorAnim.Play("WardrobeDoor", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            closesource.PlayOneShot(closeclip);
            doorAnim.Play("WardrobeDoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }
}