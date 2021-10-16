using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{

    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;
    [SerializeField] GameObject LockedDoorMessage;
    [SerializeField] GameObject LockedDoorMessage1;
    [SerializeField] GameObject LockedDoorMessage2;

    //[SerializeField] private int waitTimer = 1;
    //[SerializeField] private bool pauseInteraction = false;

    private float RayDistance;


    // Start is called before the first frame update
    void Start()
    {
        LockedDoorMessage.SetActive(false);
        LockedDoorMessage1.SetActive(false);
        LockedDoorMessage2.SetActive(false);
        StartCoroutine(WaitBeforeShow());
        RayDistance = Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if (hit.collider.CompareTag("RedLockedDoor"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    LockedDoorMessage.SetActive(true);
                    StartCoroutine(WaitBeforeShow());
                }
            }
            else if (hit.collider.CompareTag("BlueLockedDoor"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    LockedDoorMessage1.SetActive(true);
                    StartCoroutine(WaitBeforeShow());
                }
            }
            else if (hit.collider.CompareTag("GreenLockedDoor"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    LockedDoorMessage2.SetActive(true);
                    StartCoroutine(WaitBeforeShow());
                }
            }
        }
    }
    private IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(2);
        LockedDoorMessage.SetActive(false);
        LockedDoorMessage1.SetActive(false);
        LockedDoorMessage2.SetActive(false);
    }
}
