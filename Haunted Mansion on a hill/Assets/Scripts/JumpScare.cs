using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public AudioSource Scream;
    public AudioSource HeartBeat;
    public AudioSource Breath;
    //public GameObject ThePlayer;
    public GameObject JumpCam;
    public GameObject FlashImg;
    [SerializeField] GameObject nextLevelTrigger;
    [SerializeField] GameObject SheHutningtxt;

    private void Start()
    {
        SheHutningtxt.gameObject.SetActive(false);
    }

    private void OnTriggerEnter()
    {
        Scream.Play();
        JumpCam.SetActive(true);
       // ThePlayer.SetActive(false);
        FlashImg.SetActive(true);
        StartCoroutine(EndJump());
        SheHutningtxt.gameObject.SetActive(true);
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.03f);
       // ThePlayer.SetActive(true);
        JumpCam.SetActive(false);
        FlashImg.SetActive(false);
        Destroy(nextLevelTrigger);
        HeartBeat.Play();
        Breath.Play();
        SheHutningtxt.gameObject.SetActive(false);
    }
}