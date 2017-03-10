using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
 {

    public static int coin;
    private Text text;

    // Use this for initialization
    void Start()
    {

        text = GetComponent<Text>();
        coin = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (coin < 0)
        {
            coin = 0;
        }

        text.text = "" + coin;
    }

    public static void AddCoins(int coinsToAdd)
    {
        coin += coinsToAdd;
    }

    public static void reset()
    {
        coin = 0;
    }

}
