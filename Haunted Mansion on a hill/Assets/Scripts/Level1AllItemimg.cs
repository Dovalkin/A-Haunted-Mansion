using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1AllItemimg : MonoBehaviour
{
    public GameObject RedKeyImage;
    public GameObject RedKeyTick;
    public GameObject BlueKeyImage;
    public GameObject BlueKeyTick;
    public GameObject GreenKeyImage;
    public GameObject GreenKeyTick;


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
