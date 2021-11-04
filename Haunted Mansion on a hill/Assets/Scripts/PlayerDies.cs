using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDies : MonoBehaviour
{

    [SerializeField] GameObject DeathCam;
    [SerializeField] GameObject DeathUI;

    // Start is called before the first frame update
    void Start()
    {
        DeathCam.gameObject.SetActive(false);
        DeathUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
            DeathCam.gameObject.SetActive(true);
            StartCoroutine(EndDeath());
        }
    }
    IEnumerator EndDeath()
    {
        yield return new WaitForSeconds(2.03f);
        DeathCam.gameObject.SetActive(false);
        DeathUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
