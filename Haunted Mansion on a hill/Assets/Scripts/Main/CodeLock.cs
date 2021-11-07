using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
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

    [SerializeField] GameObject CodeLockCam;
    private bool CodeLockActive = false;

    public GameObject[] CodeLockCamm;
    private string lockPadCam1Tag = "CodeLockCam1";

    // Start is called before the first frame update
    void Start()
    {
        CodeLockCam.gameObject.SetActive(false);
        CodeLockActive = false;
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
            if (hit.collider.CompareTag("Codelock"))
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
                if (CodeLockActive == false)
                {
                    CodeLockCam.gameObject.SetActive(true);
                    CodeLockActive = true;
                    //Time.timeScale = 0f;
                    //Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    PickupMessage.gameObject.SetActive(false);
                    crosshair.gameObject.SetActive(true);
                    GameObject.Find("First Person Player").GetComponentInChildren<MouseLook>().enabled = false;
                    GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = false;
                    Canva.gameObject.SetActive(false);
                }
                else if (CodeLockActive == true)
                {
                    CodeLockCam.gameObject.SetActive(false);
                    CodeLockActive = false;
                    //Time.timeScale = 1f;
                    //Cursor.visible = false;
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
        CodeLockCamm = GameObject.FindGameObjectsWithTag(lockPadCam1Tag);
        if (CodeLockCamm.Length == 0)
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
