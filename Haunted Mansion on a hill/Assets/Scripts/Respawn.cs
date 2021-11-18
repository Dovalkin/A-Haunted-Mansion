using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] public Transform respawnPoint;

    [SerializeField] public Transform enemy;

    [SerializeField] GameObject DeathUI;
    [SerializeField] GameObject DeathCam;

    // Start is called before the first frame update
    public void RespawnPlayer()
    {
        Time.timeScale = 1f;
        enemy.transform.position = respawnPoint.transform.position;
        Debug.Log("PlayerRespawned");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        DeathUI.gameObject.SetActive(false);
    }
}
