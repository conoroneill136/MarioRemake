using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //pausing the game to show end of level, stops theme song , plays level completes
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("END OF LEVEL");
            //adds the time remaingin into score points
            ScoreManager.AddPoints(TimeManager.TimeForScore());

            GetComponent<AudioSource>().Play();
            Time.timeScale = 0f;
            Destroy(other.GetComponentInChildren<Camera>().GetComponent<AudioSource>());
        }
    }

}
