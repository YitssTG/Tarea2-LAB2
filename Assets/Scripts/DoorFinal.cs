using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFinal : MonoBehaviour
{
    public static event Action OnPlayerWin;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null && ScoreManager.Instance.score >= ScoreManager.Instance.targetScore)
            {
                OnPlayerWin?.Invoke();
                Debug.Log("¡Ganaste con suficiente puntaje!");
            }
            else
            {
                Debug.Log("Necesitas al menos " + ScoreManager.Instance.targetScore + " monedas para ganar.");
            }
        }
    }
}
