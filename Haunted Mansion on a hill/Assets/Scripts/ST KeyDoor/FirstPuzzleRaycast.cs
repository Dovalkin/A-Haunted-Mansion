using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleSystem
{
    public class FirstPuzzleRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 4;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        //private PuzzleController raycastedObject;
        [SerializeField] private KeyCode pickUpKey = KeyCode.E;

        [SerializeField] private Image crosshair = null;
        [SerializeField] GameObject PickupMessage;
        private bool isCrosshairActive;
        private bool doOncee;

        private string interactableeTag = "PuzzlePiece";

        //void Start()
        //{

        //}

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
                    //raycastedObject.ObjectInteraction();
                    Destroy(hit.transform.gameObject);
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
}

