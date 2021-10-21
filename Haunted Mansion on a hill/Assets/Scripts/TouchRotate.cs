using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchRotate : MonoBehaviour
{
    [SerializeField]
    public GameObject rotateImg;

    public void ClickRotate()
    {
        if (!Puzzle1COntrol.puzzle1solved)
            rotateImg.gameObject.transform.Rotate(0f, 0f, 90f);
    }
}
