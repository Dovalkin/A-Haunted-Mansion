using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;

    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;
    [SerializeField] GameObject PickupMessage;
    [SerializeField] GameObject InteractMessage;
    //[SerializeField] GameObject WhiteCrosshair;
    [SerializeField] GameObject FlashlightInstuctionUI1;
    [SerializeField] GameObject FlashlightInstuctionUI2;

    [SerializeField] GameObject FlashlightImage;
    //[SerializeField] GameObject FlashlightButton;
    [SerializeField] GameObject Flashlightobj;
    [SerializeField] GameObject Tickimg;

    [SerializeField] GameObject FirstCollide;

    [SerializeField] GameObject FlashlightInstructionUI2;
    //[SerializeField] GameObject FlashlightInstructionUI3;

    //[SerializeField] GameObject Flashlightobj;

    //[SerializeField] GameObject RedKeyobj;
    //[SerializeField] GameObject BlueKeyobj;

    private float RayDistance;
    private bool CanSeePickup = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        FlashlightInstuctionUI1.gameObject.SetActive(true);
        FlashlightInstuctionUI2.gameObject.SetActive(false);
        PickupMessage.gameObject.SetActive(false);
        InteractMessage.gameObject.SetActive(false);
        Flashlightobj.gameObject.SetActive(false);
        //RedKeyobj.gameObject.SetActive(false);
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
                        Destroy(FlashlightInstuctionUI1);
                        FlashlightInstuctionUI2.gameObject.SetActive(true);
                        //MyPlayer.Play();
                        Flashlightobj.gameObject.SetActive(true);
                        Tickimg.gameObject.SetActive(true);
                        //FlashlightButton.gameObject.SetActive(false);
                        FlashlightImage.gameObject.SetActive(false);
                        Destroy(FirstCollide);
                        Destroy(FlashlightInstructionUI2);
                        //FlashlightInstructionUI3.gameObject.SetActive(true);
                        source.PlayOneShot(clip);
                    }

                }
            }

            else
            {
                CanSeePickup = false;
            }
            //else if (hit.collider.CompareTag("RedKey"))
            //{
            //    CanSeePickup = true;
            //    if (Input.GetKeyDown(KeyCode.E))
            //        if(SaveScript.RedKey == false)
            //        {
            //            Destroy(hit.transform.gameObject);
            //            SaveScript.RedKey = true;
            //            //Player1.Play();
            //        }
            //}
        }
        if(CanSeePickup == true)
        {
            PickupMessage.gameObject.SetActive(true);
            InteractMessage.gameObject.SetActive(true);
            //WhiteCrosshair.gameObject.SetActive(false);
            RayDistance = 1000f;
        }
        if (CanSeePickup == false)
        {
            PickupMessage.gameObject.SetActive(false);
            InteractMessage.gameObject.SetActive(false);
            //WhiteCrosshair.gameObject.SetActive(true);
            RayDistance = Distance;
        }
    }
}
