using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightInstructionUI3;

    [SerializeField] GameObject flashLightLight;
    private bool FlashlightActive = false;

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
                Destroy(FlashlightInstructionUI3);
            }
            else
            {
                flashLightLight.gameObject.SetActive(false);
                FlashlightActive = false;
            }
        }
    }
}
