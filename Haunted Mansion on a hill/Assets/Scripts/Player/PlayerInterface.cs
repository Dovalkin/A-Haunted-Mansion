using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //MouseLookkk ml = GetComponent<MouseLookkk>();
        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            MouseLookkk ml = GetComponent<MouseLookkk>();
            ml.mouseSensitivity = PlayerPrefs.GetFloat("Sensitivity");
            ml = Camera.main.GetComponent<MouseLookkk>();
        }
    }
}
