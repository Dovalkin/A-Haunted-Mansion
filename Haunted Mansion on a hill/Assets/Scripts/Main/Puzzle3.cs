using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle3 : MonoBehaviour
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

    [SerializeField] GameObject LockPadCam2;
    private bool LockPad2Active = false;

    public GameObject[] LockPadCam22;
    private string lockPadCam2Tag = "LockPadCam2";

    // Start is called before the first frame update
    void Start()
    {
        LockPadCam2.gameObject.SetActive(false);
        LockPad2Active = false;
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
            if (hit.collider.CompareTag("Chest2"))
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
                if (LockPad2Active == false)
                {
                    LockPadCam2.gameObject.SetActive(true);
                    LockPad2Active = true;
                    //Time.timeScale = 0f;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    PickupMessage.gameObject.SetActive(false);
                    GameObject.Find("First Person Player").GetComponentInChildren<MouseLookkk>().enabled = false;
                    GameObject.Find("First Person Player").GetComponent<PlayerMovement1>().enabled = false;
                    crosshair.gameObject.SetActive(false);
                    Canva.gameObject.SetActive(false);
                }
                else if (LockPad2Active == true)
                {
                    LockPadCam2.gameObject.SetActive(false);
                    LockPad2Active = false;
                    //Time.timeScale = 1f;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    PickupMessage.gameObject.SetActive(true);
                    GameObject.Find("First Person Player").GetComponentInChildren<MouseLookkk>().enabled = true;
                    GameObject.Find("First Person Player").GetComponent<PlayerMovement1>().enabled = true;
                    crosshair.gameObject.SetActive(true);
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
        LockPadCam22 = GameObject.FindGameObjectsWithTag(lockPadCam2Tag);
        if (LockPadCam22.Length == 0)
        {
            GameObject.Find("First Person Player").GetComponentInChildren<MouseLookkk>().enabled = true;
            GameObject.Find("First Person Player").GetComponent<PlayerMovement1>().enabled = true;
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
