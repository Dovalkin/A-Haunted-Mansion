using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{

    public float interactDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("InteractiveObject"))
                {
                    hit.collider.transform.parent.GetComponent<Door>().ChangeDoorState();
                }
            }
        }
    }
}
