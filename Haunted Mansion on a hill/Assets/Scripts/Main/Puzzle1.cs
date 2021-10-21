using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.U))
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
}
