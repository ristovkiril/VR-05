using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        theScore += 10;
        scoreText.GetComponent<Text>().text = "COINS: " + theScore;

        Destroy(gameObject);
    }
}
