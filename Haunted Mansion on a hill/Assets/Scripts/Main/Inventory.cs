using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [SerializeField] GameObject InventoryMenu;
    //private bool InventoryActive = false;

    [SerializeField] GameObject FlashlightImage;
    [SerializeField] GameObject FlashlightButton;
    //[SerializeField] GameObject Flashlightobj;
    [SerializeField] GameObject Tickimg;

    [SerializeField] GameObject FirstCollide;

    [SerializeField] GameObject FlashlightInstructionUI2;
    [SerializeField] GameObject FlashlightInstructionUI3;

    // Start is called before the first frame update
    void Start()
    {
        FlashlightInstructionUI3.gameObject.SetActive(false);

        InventoryMenu.gameObject.SetActive(false);
        //InventoryActive = false;

        FlashlightImage.gameObject.SetActive(false);
        FlashlightButton.gameObject.SetActive(false);
        Tickimg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InventoryMenu.gameObject.SetActive(true);
            //InventoryActive = true;
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //if(InventoryActive == false)
            //{
            //    InventoryMenu.gameObject.SetActive(true);
            //    //InventoryActive = true;
            //    Time.timeScale = 0f;
            //    Cursor.visible = true;
            //    Cursor.lockState = CursorLockMode.None;
            //}
            //else if (InventoryActive == true)
            //{
            //    InventoryMenu.gameObject.SetActive(false);
            //    //InventoryActive = false;
            //    Time.timeScale = 1f;
            //    Cursor.visible = false;
            //    Cursor.lockState = CursorLockMode.Locked;
            //}
        }
        //CheckFlashlight();
    }

    public void Resume()
    {
        InventoryMenu.gameObject.SetActive(false);
        //InventoryActive = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //void CheckFlashlight()
    //{
    //    if(SaveScript.Flashlight == true)
    //    {
    //        FlashlightImage.gameObject.SetActive(true);
    //        FlashlightButton.gameObject.SetActive(true);
    //    }
    //}
    //public void Flashlight()
    //{
    //    Flashlightobj.gameObject.SetActive(true);
    //    Tickimg.gameObject.SetActive(true);
    //    FlashlightButton.gameObject.SetActive(false);
    //    FlashlightImage.gameObject.SetActive(false);
    //    Destroy(FirstCollide);
    //    Destroy(FlashlightInstructionUI2);
    //    FlashlightInstructionUI3.gameObject.SetActive(true);
    //}
}
