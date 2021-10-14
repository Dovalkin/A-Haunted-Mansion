using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class BlueKeyController : MonoBehaviour
    {
        [SerializeField] private bool blueDoor = false;
        [SerializeField] private bool blueKey = false;
        [SerializeField] GameObject BlueKeyImage;
        [SerializeField] GameObject BlueKeyTickimg;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController bluedoorObject;

        private void Start()
        {

            BlueKeyImage.gameObject.SetActive(false);
            BlueKeyTickimg.gameObject.SetActive(false);

            if (blueDoor)
            {
                bluedoorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjecttInteraction()
        {
            if (blueDoor)
            {
                bluedoorObject.PlayAnimation();
            }

            else if (blueKey)
            {
                _keyInventory.hasBlueKey = true;
                gameObject.SetActive(false);
                BlueKeyImage.gameObject.SetActive(true);
                BlueKeyTickimg.gameObject.SetActive(true);
            }
        }
    }
}

