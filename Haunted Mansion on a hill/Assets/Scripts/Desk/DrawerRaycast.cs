using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 4;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private DrawerController raycastedObj;

    [SerializeField] private KeyCode openDrawerKey = KeyCode.E;

    [SerializeField] private Image crosshair = null;
    [SerializeField] GameObject PickupMessage;
    private bool isCrosshairActive;
    private bool doOnce;

    private bool CanSeePickup = false;

    private const string interactableTag = "InteractiveObject";

    private void Start()
    {
        PickupMessage.gameObject.SetActive(false);
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                CanSeePickup = true;
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<DrawerController>();
                    CrosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDrawerKey))
                {
                    raycastedObj.PlayAnimation();
                }
            }
        }
        else
        {
            CanSeePickup = false;
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }
    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
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
        if (CanSeePickup == true)
        {
            PickupMessage.gameObject.SetActive(true);
            //InteractMessage.gameObject.SetActive(true);
            //WhiteCrosshair.gameObject.SetActive(false);
            //RayDistance = 1000f;
        }
        if (CanSeePickup == false)
        {
            PickupMessage.gameObject.SetActive(false);
            //InteractMessage.gameObject.SetActive(false);
            //WhiteCrosshair.gameObject.SetActive(true);
            //RayDistance = Distance;
        }
    }
}


