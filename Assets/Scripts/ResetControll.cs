using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetControll : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Juego"); 
    }
    public void MenuGame()
    {
        SceneManager.LoadScene("Title");
    }
}
