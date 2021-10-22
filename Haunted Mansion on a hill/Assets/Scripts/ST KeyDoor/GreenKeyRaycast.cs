using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class GreenKeyRaycast : MonoBehaviour
    {

        public GameObject doorlock2;
        public GameObject doorunlock2;

        [SerializeField] private int rayLength = 4;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        private GreenKeyController raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.E;

        [SerializeField] private Image crosshair = null;
        [SerializeField] GameObject PickupMessage;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";
        //private string interactableeTag = "RedLockedDoor";

        void Start()
        {
            doorlock2.gameObject.SetActive(true);
            doorunlock2.gameObject.SetActive(false);
        }
        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

            if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<GreenKeyController>();
                        CrosshairChange(true);
                    }                   
                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjecttInteraction();
                        doorlock2.gameObject.SetActive(false);
                        doorunlock2.gameObject.SetActive(true);
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
        void CrosshairChange (bool on)
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
}

