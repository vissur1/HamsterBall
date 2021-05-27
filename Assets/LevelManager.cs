using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour


{
    public GameObject currentCheckpoint;


    private PlayerPhysics player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.transform.position = currentCheckpoint.transform.position;
    }
}
