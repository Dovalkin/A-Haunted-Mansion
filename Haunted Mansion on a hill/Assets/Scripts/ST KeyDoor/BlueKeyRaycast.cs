using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class BlueKeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 4;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        private BlueKeyController raycastedObjectt;
        [SerializeField] private KeyCode openDoorKey = KeyCode.E;

        [SerializeField] private Image crosshair = null;
        private bool isCrosshairActive;
        private bool doOncee;

        private string interactableTag = "InteractiveObject";

        //void Start()
        //{

        //}
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
            }
            else
            {
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}

