using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        
        public GameObject doorlock;
        public GameObject doorunlock;
        //public GameObject doorunlockk;
        //public GameObject doorlockk;

        [SerializeField] private int rayLength = 4;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        private KeyItemController raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.E;

        [SerializeField] private Image crosshair = null;
        [SerializeField] GameObject PickupMessage;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";
        //private string interactableeTag = "RedLockedDoor";

        void Start()
        {
            doorlock.gameObject.SetActive(true);
            //doorlockk.gameObject.SetActive(true);
            doorunlock.gameObject.SetActive(false);
            //doorunlockk.gameObject.SetActive(false);
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
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                        CrosshairChange(true);
                    }                   
                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteraction();
                        doorlock.gameObject.SetActive(false);
                        //doorlockk.gameObject.SetActive(false);
                        doorunlock.gameObject.SetActive(true);
                        //doorunlockk.gameObject.SetActive(true);
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
                PickupMessage.gameObject.SetActive(true);
                crosshair.color = Color.red;
            }
            else
            {
                PickupMessage.gameObject.SetActive(false);
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}

