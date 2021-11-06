using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorController : MonoBehaviour
{

    [SerializeField] GameObject bigDoorButtonDestroy;

    private string bigLockedTag = "MainLockedDoor";

    public GameObject[] bigLocked;

    // Start is called before the first frame update
    void Start()
    {
        bigDoorButtonDestroy.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bigLocked = GameObject.FindGameObjectsWithTag(bigLockedTag);
        if(bigLocked.Length == 0)
        {
            bigDoorButtonDestroy.gameObject.SetActive(true);
        }
    }
}
