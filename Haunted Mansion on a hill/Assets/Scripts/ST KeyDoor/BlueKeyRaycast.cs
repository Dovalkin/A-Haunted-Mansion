using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class BlueKeyRaycast : MonoBehaviour
    {
        public GameObject doorlock1;
        public GameObject doorlockk1;
        public GameObject doorunlock1;
        public GameObject doorunlockk1;

        [SerializeField] private int rayLength = 4;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        private BlueKeyController raycastedObjectt;
        [SerializeField] private KeyCode openDoorKey = KeyCode.E;

        [SerializeField] private Image crosshair = null;
        [SerializeField] private Image customImage;
        private bool isCrosshairActive;
        private bool doOncee;

        private string interactableTag = "InteractiveObject";

        void Start()
        {
            doorlock1.gameObject.SetActive(true);
            doorlockk1.gameObject.SetActive(true);
            doorunlock1.gameObject.SetActive(false);
            doorunlockk1.gameObject.SetActive(false);
        }
        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    if (!doOncee)
                    {
                        raycastedObjectt = hit.collider.gameObject.GetComponent<BlueKeyController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOncee = true;

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObjectt.ObjecttInteraction();
                        doorlock1.gameObject.SetActive(false);
                        doorlockk1.gameObject.SetActive(false);
                        doorunlock1.gameObject.SetActive(true);
                        doorunlockk1.gameObject.SetActive(true);
                    }
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
}

