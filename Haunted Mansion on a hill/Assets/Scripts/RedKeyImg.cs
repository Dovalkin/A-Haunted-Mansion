using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedKeyImg : MonoBehaviour
{
    public GameObject RedKeyImage;
    public GameObject RedKeyTick;
    public GameObject GreenKeyImage;
    public GameObject GreenKeyTick;
    public GameObject BlueKeyImage;
    public GameObject BlueKeyTick;

    private void Awake()
    {
        RedKeyImage.gameObject.SetActive(false);
        RedKeyTick.gameObject.SetActive(false);
        GreenKeyImage.gameObject.SetActive(false);
        GreenKeyTick.gameObject.SetActive(false);
        BlueKeyImage.gameObject.SetActive(false);
        BlueKeyTick.gameObject.SetActive(false);
    }
}
