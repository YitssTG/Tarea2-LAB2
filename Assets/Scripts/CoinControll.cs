using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinControll : MonoBehaviour, Interactable
{
    public int scoreValue = 1;

    public void Interact(GameObject player)
    {
        ScoreManager.Instance.AddScore(scoreValue);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Interact(collision.gameObject);
        }
    }
}
