using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockControl : MonoBehaviour
{

    public AudioSource Unlocked;

    [SerializeField] GameObject GreenKey;
    [SerializeField] GameObject ChestCoverClose;
    [SerializeField] GameObject ChestCoverOpen;
    [SerializeField] GameObject LockPadCam;
    [SerializeField] GameObject LockPadTrigger;
    [SerializeField] GameObject LockPadModel;

    [SerializeField]
    private Image crosshair;

    [SerializeField] GameObject firstPersonPlayer;

    [SerializeField] GameObject backButton;

    [SerializeField] GameObject Canva;


    private int[] result, correctCombination;
    private bool isOpened;

    private void Awake()
    {
        GreenKey.gameObject.SetActive(false);
    }
    private void Start()
    {
        //GameObject.Find("LastPiece").GetComponent<BoxCollider>().enabled = false;
        ChestCoverClose.gameObject.SetActive(true);
        ChestCoverOpen.gameObject.SetActive(false);

        result = new int[]{0,0,0,0};
        correctCombination = new int[] {5,1,7,4};
        isOpened = false;
        Rotate.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "WheelOne":
                result[0] = number;
                break;

            case "WheelTwo":
                result[1] = number;
                break;

            case "WheelThree":
                result[2] = number;
                break;

            case "WheelFour":
                result[3] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
            && result[2] == correctCombination[2] && result[3] == correctCombination[3] && !isOpened)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
            isOpened = true;

            Unlocked.Play();
            GreenKey.gameObject.SetActive(true);
            ChestCoverClose.gameObject.SetActive(false);
            ChestCoverOpen.gameObject.SetActive(true);
            Destroy(LockPadTrigger);
            Destroy(LockPadModel);
            LockPadCam.gameObject.SetActive(false);
            crosshair.gameObject.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            firstPersonPlayer.gameObject.SetActive(true);
            backButton.gameObject.SetActive(false);
            Canva.gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}
