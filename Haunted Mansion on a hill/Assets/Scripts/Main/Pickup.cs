using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;
    [SerializeField] GameObject PickupMessage;
    [SerializeField] GameObject WhiteCrosshair;

    [SerializeField] GameObject Flashlightobj;

    private float RayDistance;
    private bool CanSeePickup = false;

    // Start is called before the first frame update
    void Start()
    {
        PickupMessage.gameObject.SetActive(false);
        Flashlightobj.gameObject.SetActive(false);
        RayDistance = Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if(hit.collider.CompareTag("Flashlight"))
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(SaveScript.Flashlight == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Flashlight = true;
                        //MyPlayer.Play();
                    }

                }
            }
            else if (hit.collider.CompareTag("Door"))
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.SendMessage("DoorOpen");
                }
            }
            else
            {
                CanSeePickup = false;
            }
        }
        if(CanSeePickup == true)
        {
            PickupMessage.gameObject.SetActive(true);
            WhiteCrosshair.gameObject.SetActive(false);
            RayDistance = 1000f;
        }
        if (CanSeePickup == false)
        {
            PickupMessage.gameObject.SetActive(false);
            WhiteCrosshair.gameObject.SetActive(true);
            RayDistance = Distance;
        }
    }
}
