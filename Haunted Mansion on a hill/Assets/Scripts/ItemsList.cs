using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsList : MonoBehaviour
{
    [SerializeField] GameObject ItemsListMenu;
    private bool InventoryActive = false;

    // Start is called before the first frame update
    void Start()
    {
        ItemsListMenu.gameObject.SetActive(false);
        InventoryActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryActive == false)
            {
                ItemsListMenu.gameObject.SetActive(true);
                InventoryActive = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (InventoryActive == true)
            {
                ItemsListMenu.gameObject.SetActive(false);
                InventoryActive = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}