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
    [SerializeField] private Image customImage;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "InteractiveObject";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
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
            customImage.enabled = true;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
            customImage.enabled = false;
        }
    }
}
