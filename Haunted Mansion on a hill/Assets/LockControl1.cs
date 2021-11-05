using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockControl1 : MonoBehaviour
{

    public AudioSource Unlocked;

    //[SerializeField] GameObject InstructPiece;
    [SerializeField] GameObject ChestCoverClose2;
    [SerializeField] GameObject ChestCoverOpen2;
    [SerializeField] GameObject LockPadCam2;
    [SerializeField] GameObject LockPadTrigger2;
    [SerializeField] GameObject LockPadModel2;

    [SerializeField]
    private Image crosshair;

    private int[] result, correctCombination;
    private bool isOpened;
    private void Start()
    {
        //InstructPiece.gameObject.SetActive(false);
        ChestCoverClose2.gameObject.SetActive(true);
        ChestCoverOpen2.gameObject.SetActive(false);

        result = new int[]{0,0,0,0};
        correctCombination = new int[] {2,4,5,9};
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
            //InstructPiece.gameObject.SetActive(true);
            ChestCoverClose2.gameObject.SetActive(false);
            ChestCoverOpen2.gameObject.SetActive(true);
            Destroy(LockPadTrigger2);
            Destroy(LockPadModel2);
            Destroy(LockPadCam2, 2f);
            crosshair.gameObject.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}
