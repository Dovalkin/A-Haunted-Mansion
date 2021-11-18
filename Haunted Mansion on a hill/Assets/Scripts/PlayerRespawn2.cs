using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn2 : MonoBehaviour
{
    [SerializeField] public Transform m_SpawnPoint;
    [SerializeField] public GameObject m_PlayerPrefab;

    [SerializeField] public Transform m_GhostSpawnPoint;
    [SerializeField] public Transform enemy;

    [SerializeField] GameObject DeathUI;
    [SerializeField] GameObject DeathCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        Instantiate(m_PlayerPrefab, m_SpawnPoint.position, Quaternion.identity);
        Time.timeScale = 1f;
        enemy.transform.position = m_GhostSpawnPoint.transform.position;
        Debug.Log("PlayerRespawned");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        DeathUI.gameObject.SetActive(false);
    }
}
