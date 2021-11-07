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

    [SerializeField] GameObject theGhost;
    [SerializeField] GameObject colliderCube;

    [SerializeField] GameObject PurpleGemtxt;
    [SerializeField] GameObject PurpleGemImg;

    [SerializeField] GameObject OrangeGemtxt;
    [SerializeField] GameObject OrangeGemImg;

    [SerializeField] GameObject ThunderSymboltxt;
    [SerializeField] GameObject ThunderSymbolImg;

    [SerializeField] GameObject BalanceSymboltxt;
    [SerializeField] GameObject BalanceSymbolImg;

    [SerializeField] GameObject VaseSymboltxt;
    [SerializeField] GameObject VaseSymbolImg;

    [SerializeField] GameObject TorchSymboltxt;
    [SerializeField] GameObject TorchSymbolImg;

    private void Start()
    {
        SheHutningtxt.gameObject.SetActive(false);
        theGhost.gameObject.SetActive(false);
        colliderCube.gameObject.SetActive(false);
        PurpleGemtxt.gameObject.SetActive(false);
        PurpleGemImg.gameObject.SetActive(false);
        OrangeGemtxt.gameObject.SetActive(false);
        OrangeGemImg.gameObject.SetActive(false);
        ThunderSymboltxt.gameObject.SetActive(false);
        ThunderSymbolImg.gameObject.SetActive(false);
        BalanceSymboltxt.gameObject.SetActive(false);
        BalanceSymbolImg.gameObject.SetActive(false);
        VaseSymboltxt.gameObject.SetActive(false);
        VaseSymbolImg.gameObject.SetActive(false);
        TorchSymboltxt.gameObject.SetActive(false);
        TorchSymbolImg.gameObject.SetActive(false);
    }

    private void OnTriggerEnter()
    {
        Scream.Play();
        JumpCam.SetActive(true);
        theGhost.gameObject.SetActive(true);
        colliderCube.gameObject.SetActive(true);
        // ThePlayer.SetActive(false);
        FlashImg.SetActive(true);
        StartCoroutine(EndJump());
        SheHutningtxt.gameObject.SetActive(true);

        PurpleGemtxt.gameObject.SetActive(true);
        PurpleGemImg.gameObject.SetActive(true);
        OrangeGemtxt.gameObject.SetActive(true);
        OrangeGemImg.gameObject.SetActive(true);
        ThunderSymboltxt.gameObject.SetActive(true);
        ThunderSymbolImg.gameObject.SetActive(true);
        BalanceSymboltxt.gameObject.SetActive(true);
        BalanceSymbolImg.gameObject.SetActive(true);
        VaseSymboltxt.gameObject.SetActive(true);
        VaseSymbolImg.gameObject.SetActive(true);
        TorchSymboltxt.gameObject.SetActive(true);
        TorchSymbolImg.gameObject.SetActive(true);
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
