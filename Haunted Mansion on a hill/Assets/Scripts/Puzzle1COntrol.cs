using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1COntrol : MonoBehaviour
{

    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    public GameObject gate;

    public static bool puzzle1solved;

    // Start is called before the first frame update
    void Start()
    {
        gate.gameObject.SetActive(true);
        puzzle1solved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pictures[0].rotation.z == 0 &&
            pictures[1].rotation.z == 0 &&
            pictures[2].rotation.z == 0 &&
            pictures[3].rotation.z == 0 &&
            pictures[4].rotation.z == 0 &&
            pictures[5].rotation.z == 0)
        {
            puzzle1solved = true;
            gate.gameObject.SetActive(false);
            Debug.Log("Puzzle1 solved");
        }
    }
}
