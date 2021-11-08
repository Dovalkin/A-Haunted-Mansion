using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{

    [SerializeField] GameObject WinUI;

    private GameObject firstPersonPlayer;

    // Start is called before the first frame update
    void Start()
    {
        WinUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    //private void OnTriggerEnter()
    //{

    //    //Destroy(gameObject);
    //    DeathCam.gameObject.SetActive(true);
    //    StartCoroutine(EndDeath());
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //    //Destroy(gameObject);
            StartCoroutine(EndWin());
        }
    }
    IEnumerator EndWin()
    {
        yield return new WaitForSeconds(2.03f);
        WinUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
