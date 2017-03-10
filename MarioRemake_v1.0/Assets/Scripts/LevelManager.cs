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
        GetComponent<AudioSource>().Play();
        Application.LoadLevel(Application.loadedLevel);
        //player.transform.position = currentCheckPoint.transform.position;

        //CoinManager.reset();
        //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
