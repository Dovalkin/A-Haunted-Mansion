using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnoughPieces : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;
    //[SerializeField] private LayerMask layerMaskInteract;
    //[SerializeField] private string excluseLayerName = null;

    [SerializeField] private Image crosshair = null;
    [SerializeField] GameObject PickupMessage;

    private float RayDistance;

    private bool isCrosshairActive;
    private bool doOnce;

    [SerializeField] GameObject NotEnoughPiecesMessage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitBeforeShow());
        NotEnoughPiecesMessage.SetActive(false);
        RayDistance = Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if (hit.collider.CompareTag("NotEnoughPuzzle"))
            {
                NotEnoughPiecesMessage.SetActive(true);
                StartCoroutine(WaitBeforeShow());
            }
        }
    }
    private IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(2);
        NotEnoughPiecesMessage.SetActive(false);
    }
}
