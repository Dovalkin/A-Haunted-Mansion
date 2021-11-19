//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class OptionsMenu : MonoBehaviour
//{
//    public bool initialized = false;
//    public Slider mouseSensitivitySlider;

//    // Start is called before the first frame update
//    void Start()
//    {
//        if (PlayerPrefs.HasKey("Sensitivity"))
//        {
//            mouseSensitivitySlider.value = PlayerPrefs.GetFloat ("Sensitivity");
//            Debug.Log("Loaded a sensivity" + mouseSensitivitySlider.value);
//        }
//    }

//    // Update is called once per frame
//    public void SetMouseSensitivity(float val)
//    {
//        if (!initialized) return;
//        //if (!Application.isPlaying) return;

//        PlayerPrefs.SetFloat("Sensitivity", val);
//        Debug.Log("Set sensitivity to" + val);
//    }
//}
