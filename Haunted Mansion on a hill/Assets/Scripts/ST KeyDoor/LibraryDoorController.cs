using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryDoorController : MonoBehaviour
{

    [SerializeField] GameObject doorButtonDestroy;

    private string libraryLockedTag = "LibraryLockedDoor";

    public GameObject[] libraryLocked;

    // Start is called before the first frame update
    void Start()
    {
        doorButtonDestroy.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        libraryLocked = GameObject.FindGameObjectsWithTag(libraryLockedTag);
        if(libraryLocked.Length == 0)
        {
            doorButtonDestroy.gameObject.SetActive(true);
        }
    }
}
