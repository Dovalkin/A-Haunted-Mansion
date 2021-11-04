using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public AudioSource clickSound;

    //[SerializeField] GameObject FlashlightInstructionUI3;

    [SerializeField] GameObject ToggleFlashlight;

    [SerializeField] GameObject flashLightLight;
    private bool FlashlightActive = false;

    private void Awake()
    {
        ToggleFlashlight.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        flashLightLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightActive == false)
            {
                flashLightLight.gameObject.SetActive(true);
                FlashlightActive = true;
                Destroy(ToggleFlashlight);
                clickSound.Play();
            }
            else
            {
                flashLightLight.gameObject.SetActive(false);
                FlashlightActive = false;
                clickSound.Play();
            }
        }
    }
}
