using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1 : MonoBehaviour
{

    //RaycastHit hit;
    //[SerializeField] float Distance = 4.0f;
    //private float RayDistance;

    [SerializeField] private int rayLength = 4;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excluseLayerName = null;

    [SerializeField] private Image crosshair = null;
    [SerializeField] GameObject PickupMessage;

    private bool isCrosshairActive;
    private bool doOnce;

    [SerializeField] GameObject Puzzle1Menu;
    private bool Puzzle1Active = false;

    // Start is called before the first frame update
    void Start()
    {
        Puzzle1Menu.gameObject.SetActive(false);
        Puzzle1Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag("Puzzle1"))
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
                if (Puzzle1Active == false)
                {
                    Puzzle1Menu.gameObject.SetActive(true);
                    Puzzle1Active = true;
                    Time.timeScale = 0f;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else if (Puzzle1Active == true)
                {
                    Puzzle1Menu.gameObject.SetActive(false);
                    Puzzle1Active = false;
                    Time.timeScale = 1f;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
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
