using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{

    //RaycastHit hit;
    //[SerializeField] float Distance = 4.0f;
    //private float RayDistance;

    [SerializeField] private int rayLength = 4;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excluseLayerName = null;

    [SerializeField] private Image crosshair = null;
    [SerializeField] GameObject PickupMessage;

    [SerializeField] GameObject Canva;


    private bool isCrosshairActive;
    private bool doOnce;

    [SerializeField] GameObject LockPadCam1;
    private bool LockPad1Active = false;


    public GameObject[] LockPadCam11;
    private string lockPadCam1Tag = "LockPadCam1";

    // Start is called before the first frame update
    void Start()
    {
        LockPadCam1.gameObject.SetActive(false);
        LockPad1Active = false;
        Canva.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag("Chest"))
            {
                if (!doOnce)
                {
                    CrosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (LockPad1Active == false)
                {
                    LockPadCam1.gameObject.SetActive(true);
                    LockPad1Active = true;
                    //Time.timeScale = 0f;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    PickupMessage.gameObject.SetActive(false);
                    crosshair.gameObject.SetActive(false);
                    GameObject.Find("First Person Player").GetComponentInChildren<MouseLook>().enabled = false;
                    GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = false;
                    Canva.gameObject.SetActive(false);
                }
                else if (LockPad1Active == true)
                {
                    LockPadCam1.gameObject.SetActive(false);
                    LockPad1Active = false;
                    //Time.timeScale = 1f;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    crosshair.gameObject.SetActive(true);
                    PickupMessage.gameObject.SetActive(true);
                    GameObject.Find("First Person Player").GetComponentInChildren<MouseLook>().enabled = true;
                    GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = true;
                    Canva.gameObject.SetActive(true);
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
        LockPadCam11 = GameObject.FindGameObjectsWithTag(lockPadCam1Tag);
        if (LockPadCam11.Length == 0)
        {
            GameObject.Find("First Person Player").GetComponentInChildren<MouseLook>().enabled = true;
            GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = true;
            Canva.gameObject.SetActive(true);
        }
    }
    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
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
