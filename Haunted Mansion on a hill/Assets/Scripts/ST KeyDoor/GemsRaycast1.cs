using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsRaycast1 : MonoBehaviour
{
    public AudioSource Aura;

    [SerializeField] private GameObject GemLocked2;
    [SerializeField] private GameObject Gem2AtDoor;

    [SerializeField] private int rayLength = 4;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excluseLayerName = null;

    //private PuzzleController raycastedObject;
    [SerializeField] private KeyCode pickUpKey = KeyCode.E;

    [SerializeField] GameObject PurpleGemTick;
    [SerializeField] GameObject PurpleGemImg;

    [SerializeField] private Image crosshair = null;
    [SerializeField] GameObject PickupMessage;
    private bool isCrosshairActive;
    private bool doOncee;

    private string interactableeTag = "Gem2";

    void Start()
    {
        PurpleGemTick.gameObject.SetActive(false);
        PurpleGemImg.gameObject.SetActive(true);
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
                //PuzzleNumber.puzzlePicked += 1;
                //raycastedObject.ObjectInteraction();
                Gem2AtDoor.gameObject.SetActive(true);
                Destroy(hit.transform.gameObject);
                Destroy(GemLocked2);
                PurpleGemTick.gameObject.SetActive(true);
                PurpleGemImg.gameObject.SetActive(false);
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