using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {

    public AudioSource boxSoundEffect;
    public GameObject Mushroom;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && (other.transform.position.y < gameObject.transform.position.y))
            Mushroom.SetActive(true);
            Destroy(gameObject);

    }
} 
