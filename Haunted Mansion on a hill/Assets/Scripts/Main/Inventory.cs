using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] GameObject InventoryMenu;
    private bool InventoryActive = false;

    [SerializeField] GameObject FlashlightImage;
    [SerializeField] GameObject FlashlightButton;
    [SerializeField] GameObject Flashlightobj;
    [SerializeField] GameObject Tickimg;

    [SerializeField] GameObject FirstCollide;

    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
        InventoryActive = false;

        FlashlightImage.gameObject.SetActive(false);
        FlashlightButton.gameObject.SetActive(false);
        Tickimg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(InventoryActive == false)
            {
                InventoryMenu.gameObject.SetActive(true);
                InventoryActive = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (InventoryActive == true)
            {
                InventoryMenu.gameObject.SetActive(false);
                InventoryActive = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        CheckFlashlight();
    }

    void CheckFlashlight()
    {
        if(SaveScript.Flashlight == true)
        {
            FlashlightImage.gameObject.SetActive(true);
            FlashlightButton.gameObject.SetActive(true);
        }
    }
    public void Flashlight()
    {
        Flashlightobj.gameObject.SetActive(true);
        Tickimg.gameObject.SetActive(true);
        FlashlightButton.gameObject.SetActive(false);
        FlashlightImage.gameObject.SetActive(false);
        Destroy(FirstCollide);
    }
}
