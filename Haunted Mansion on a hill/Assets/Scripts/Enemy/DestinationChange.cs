using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationChange : MonoBehaviour
{
    public int xPos;
    public int zPos;
    public int yPos;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            xPos = Random.Range(-49, 69);
            zPos = Random.Range(-241, -165);
            yPos = Random.Range(0, 0);
            this.gameObject.transform.position = new Vector3(xPos, 0f, zPos);
        }
    }
}
