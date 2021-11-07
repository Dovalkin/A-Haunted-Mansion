using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolRaycast2 : MonoBehaviour
{
    public AudioSource Aura;

    [SerializeField] private GameObject SymbolLocked3;
    [SerializeField] private GameObject Symbol3AtDoor;

    [SerializeField] private int rayLength = 4;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excluseLayerName = null;

    //private PuzzleController raycastedObject;
    [SerializeField] private KeyCode pickUpKey = KeyCode.E;

    [SerializeField] GameObject TorchSymbolTick;
    [SerializeField] GameObject TorchSymbolImg;

    [SerializeField] private Image crosshair = null;
    [SerializeField] GameObject PickupMessage;
    private bool isCrosshairActive;
    private bool doOncee;

    private string interactableeTag = "Symbol3";

    void Start()
    {
        TorchSymbolTick.gameObject.SetActive(false);
        TorchSymbolImg.gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableeTag))
            {
                if (!doOncee)
                {
                    //raycastedObject = hit.collider.gameObject.GetComponent<PuzzleController>();
                    CrosshairChange(true);
                }
            }
            isCrosshairActive = true;
            doOncee = true;

            if (Input.GetKeyDown(pickUpKey))
            {
                Symbol3AtDoor.gameObject.SetActive(true);
                //PuzzleNumber.puzzlePicked += 1;
                //raycastedObject.ObjectInteraction();
                Destroy(hit.transform.gameObject);
                Destroy(SymbolLocked3);
                TorchSymbolTick.gameObject.SetActive(true);
                TorchSymbolImg.gameObject.SetActive(false);
                Aura.Play();
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOncee = false;
            }
        }
    }
    void CrosshairChange(bool on)
    {
        if (on && !doOncee)
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