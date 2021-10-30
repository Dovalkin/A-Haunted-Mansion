using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class GreenKeyController : MonoBehaviour
    {
        public AudioSource pickUpSound;

        [SerializeField] private bool greenDoor = false;
        [SerializeField] private bool greenKey = false;
        [SerializeField] GameObject GreenKeyImage;
        [SerializeField] GameObject GreenKeyTickimg;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController greendoorObject;

        private void Start()
        {

            GreenKeyImage.gameObject.SetActive(false);
            GreenKeyTickimg.gameObject.SetActive(false);

            if (greenDoor)
            {
                greendoorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjecttInteraction()
        {
            if (greenDoor)
            {
                greendoorObject.PlayAnimation();
            }

            else if (greenKey)
            {
                pickUpSound.Play();
                _keyInventory.hasGreenKey = true;
                Destroy(gameObject);
                GreenKeyImage.gameObject.SetActive(true);
                GreenKeyTickimg.gameObject.SetActive(true);
            }
        }
    }
}

