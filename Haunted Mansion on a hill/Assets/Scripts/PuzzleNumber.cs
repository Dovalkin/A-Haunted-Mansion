using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleNumber : MonoBehaviour
{

    public static int puzzlePicked = 0;
    Text puzzlenum;

    // Start is called before the first frame update
    void Start()
    {
        puzzlenum = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        puzzlenum.text = "" + puzzlePicked;
    }
}
