using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 3;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    //[SerializeField] public GameObject flashLightobj;
    //[SerializeField] public GameObject flashLight;
    //private bool FlashlightPickedUp = false;

    private MyDoorController raycastedObj;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    [SerializeField] private Image crosshair = null;
    [SerializeField] GameObject PickupMessage;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "InteractiveObject";
    //private const string interactableeTag = "RedLockedDoor";

    //void Start()
    //{
    //    flashLightobj.gameObject.SetActive(true);
    //    flashLight.gameObject.SetActive(false);
    //}

    private void Update()
    {
        RaycastHit hit; 
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                    CrosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    raycastedObj.PlayAnimation();
                    //if(FlashlightPickedUp == false)
                    //{
                    //    flashLightobj.gameObject.SetActive(false);
                    //    flashLight.gameObject.SetActive(true);
                    //    FlashlightPickedUp = true;
                    //}
                }
            }

            //if (hit.collider.CompareTag(interactableeTag))
            //{
            //    if (!doOnce)
            //    {
            //        CrosshairChange(true);
            //    }
            //    isCrosshairActive = true;
            //    doOnce = true;
            //}
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }
    void CrosshairChange(bool on)
    {
        if(on && !doOnce)
        {
            crosshair.color = Color.red;
            PickupMessage.gameObject.SetActive(true);
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
            PickupMessage.gameObject.SetActive(false);
        }
    }
}
