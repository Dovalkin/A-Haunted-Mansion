using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private Animator drawerAnim;

    [SerializeField] GameObject topCollider;
    [SerializeField] private GameObject objectInside;

    private bool drawerOpen = false;

    private void Awake()
    {
        drawerAnim = gameObject.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        topCollider.gameObject.SetActive(true);
        objectInside.gameObject.SetActive(false);
    }

    public void PlayAnimation()
    {
        if (!drawerOpen)
        {
            source.PlayOneShot(clip);
            drawerAnim.Play("DrawerPulling", 0, 0.0f);
            drawerOpen = true;
            topCollider.gameObject.SetActive(false);
            objectInside.gameObject.SetActive(true);
        }
        else
        {
            source.PlayOneShot(clip);
            drawerAnim.Play("DrawerClosing", 0, 0.0f);
            drawerOpen = false;
            topCollider.gameObject.SetActive(true);
            objectInside.gameObject.SetActive(false);
        }
    }
}
