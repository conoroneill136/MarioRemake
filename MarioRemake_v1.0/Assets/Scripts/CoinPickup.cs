using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    public int pointsToAdd;
    public int coinsToAdd;
    public AudioSource coinSoundEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)
        
            return;
        
        coinSoundEffect.Play();
        ScoreManager.AddPoints(pointsToAdd);
        CoinManager.AddCoins(coinsToAdd);
        Destroy(gameObject);
    }
}
