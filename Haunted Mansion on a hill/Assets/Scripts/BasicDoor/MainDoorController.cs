using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainDoorController : MonoBehaviour
{
    public AudioSource source;
    public AudioSource closesource;
    public AudioClip clip;
    public AudioClip closeclip;

    private Animator maindoorAnim;

    private bool doorOpen = false;

    private void Awake()
    {
        maindoorAnim = gameObject.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        closesource = GetComponent<AudioSource>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            source.PlayOneShot(clip);
            maindoorAnim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            closesource.PlayOneShot(closeclip);
            maindoorAnim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (doorOpen == false)
            {
                maindoorAnim.Play("DoorOpen", 0, 0.0f);
                doorOpen = true;
            }    
        }
    }
}
