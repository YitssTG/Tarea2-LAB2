using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class HeartControll : MonoBehaviour, Interactable
{
    public float healtamount = 1f;
    public void Interact(GameObject player)
    {
        Life life = player.GetComponent<Life>();
        if (life != null )
        {
            life.Heal(healtamount);
        }
        Destroy(this.gameObject);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Interact(collision.gameObject);
        }
    }
}
