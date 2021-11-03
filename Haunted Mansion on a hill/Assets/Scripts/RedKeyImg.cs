using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedKeyImg : MonoBehaviour
{
    public GameObject RedKeyImage;
    public GameObject RedKeyTick;

    private void Awake()
    {
        RedKeyImage.gameObject.SetActive(false);
        RedKeyTick.gameObject.SetActive(false);
    }
}
