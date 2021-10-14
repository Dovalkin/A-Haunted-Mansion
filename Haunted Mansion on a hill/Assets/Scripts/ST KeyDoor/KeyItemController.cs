using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool redKey = false;
        [SerializeField] GameObject RedKeyImage;
        [SerializeField] GameObject RedKeyTickimg;


        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            RedKeyImage.gameObject.SetActive(false);
            RedKeyTickimg.gameObject.SetActive(false);

            if (redDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }

        }

        public void ObjectInteraction()
        {
            if (redDoor)
            {
                doorObject.PlayAnimation();
            }

            else if (redKey)
            {
                _keyInventory.hasRedKey = true;
                gameObject.SetActive(false);
                RedKeyImage.gameObject.SetActive(true);
                RedKeyTickimg.gameObject.SetActive(true);
            }
        }
    }
}

