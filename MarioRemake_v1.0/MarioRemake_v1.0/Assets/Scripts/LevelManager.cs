using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private PlayerController player;
    public GameObject currentCheckPoint;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        Debug.Log("player respawn");
        player.transform.position = currentCheckPoint.transform.position;
        //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
