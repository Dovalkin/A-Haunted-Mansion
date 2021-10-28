using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{

    [SerializeField] GameObject notEnoughPieces;
    [SerializeField] GameObject enoughPieces;

    private string interactableeTag = "PuzzlePiece";

    public GameObject[] puzzlepieces;

    void Start()
    {
        notEnoughPieces.gameObject.SetActive(true);
        enoughPieces.gameObject.SetActive(false);        
    }

    void Update()
    {
        puzzlepieces = GameObject.FindGameObjectsWithTag(interactableeTag);
        if (puzzlepieces.Length == 0)
        {
            notEnoughPieces.gameObject.SetActive(false);
            enoughPieces.gameObject.SetActive(true);           
        }
    }
}