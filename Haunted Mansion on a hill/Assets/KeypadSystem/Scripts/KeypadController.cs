using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    //public DoorController door;
    public string password;
    public int passwordLimit;
    public Text passwordText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    [SerializeField] GameObject canvaa;

    [SerializeField] GameObject Ghost;

    [SerializeField] GameObject KeyPad;
    [SerializeField] GameObject CodeLockCam;

    [SerializeField] GameObject CodeLockCollider;

    [SerializeField] GameObject bigTrigger;

    [SerializeField] GameObject FrontdoorLocked;
    [SerializeField] GameObject FrontdoorUnlocked;

    private void Start()
    {
        passwordText.text = "";
        FrontdoorUnlocked.gameObject.SetActive(false);
        FrontdoorLocked.gameObject.SetActive(true);
    }

    public void PasswordEntry(string number)
    {
        if (number == "Clear")
        {
            Clear();
            return;
        }
        else if(number == "Enter")
        {
            Enter();
            return;
        }

        int length = passwordText.text.ToString().Length;
        if(length<passwordLimit)
        {
            passwordText.text = passwordText.text + number;
        }
    }

    public void Clear()
    {
        passwordText.text = "";
        passwordText.color = Color.white;
    }

    private void Enter()
    {
        if (passwordText.text == password)
        {
            //door.lockedByPassword = false;

            if (audioSource != null)
                audioSource.PlayOneShot(correctSound);

            passwordText.color = Color.green;
            StartCoroutine(waitAndClear());
            Destroy(KeyPad, 1.5f);
            CodeLockCam.gameObject.SetActive(false);
            FrontdoorUnlocked.gameObject.SetActive(true);
            Destroy(FrontdoorLocked);
            Destroy(Ghost);
            CodeLockCollider.gameObject.SetActive(false);
            bigTrigger.gameObject.SetActive(false);
            canvaa.gameObject.SetActive(true);
        }
        else
        {
            if (audioSource != null)
                audioSource.PlayOneShot(wrongSound);

            passwordText.color = Color.red;
            StartCoroutine(waitAndClear());
        }
    }

    IEnumerator waitAndClear()
    {
        yield return new WaitForSeconds(0.75f);
        Clear();
    }


}
