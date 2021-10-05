using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator Anim;
    public bool IsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpen()
    {
        if(IsOpen == false)
        {
            Anim.SetTrigger("Open");
            IsOpen = true;
        }
        else if(IsOpen == true)
        {
            Anim.SetTrigger("Close");
            IsOpen = false;
        }
    }
}
