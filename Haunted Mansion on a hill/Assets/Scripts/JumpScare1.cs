using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare1 : MonoBehaviour
{
    public AudioSource Thunder;
    //public GameObject ThePlayer;
    //public GameObject mainCam;
    public GameObject JumpCam;
    public GameObject FlashImg;
    [SerializeField] GameObject firstJumpTrigger;

    private void OnTriggerEnter()
    {
        Thunder.Play();
        JumpCam.SetActive(true);
       // ThePlayer.SetActive(false);
        FlashImg.SetActive(true);
        //mainCam.SetActive(false);
        //Time.timeScale = 0f;
        StartCoroutine(EnddJump());
    }

    IEnumerator EnddJump()
    {
        yield return new WaitForSeconds(2.03f);
        // ThePlayer.SetActive(true);
        Destroy(JumpCam);
        FlashImg.SetActive(false);
        //mainCam.SetActive(true);
        //Time.timeScale = 1f;
        Destroy(firstJumpTrigger);
    }
}
