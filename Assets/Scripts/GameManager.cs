using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CronometroControll cronometro;

    void OnEnable()
    {
        Life.OnPlayerDead += HandleGameOver;
        DoorFinal.OnPlayerWin += HandleGameWin;
    }
    void OnDisable()
    {
        Life.OnPlayerDead -= HandleGameOver;
        DoorFinal.OnPlayerWin += HandleGameWin;
    }
    void HandleGameOver()
    {
        Debug.Log("El jugador ha perdido");
        cronometro.StopTime("GameOver");
    }
    void HandleGameWin()
    {
        Debug.Log("El jugador ha ganado");
        cronometro.StopTime("GameWin");
    }
}
