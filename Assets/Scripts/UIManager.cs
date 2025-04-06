using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image lifeBar;
    //public TextMeshProUGUI gameOverText;

    public Life playerLife;
    void OnEnable()
    {
        Life.OnLifeChanged += UpdateLifeBar;
        //Life.OnPlayerDead += ShowGameOver;
    }
    void OnDisable()
    {
        Life.OnLifeChanged -= UpdateLifeBar;
        //Life.OnPlayerDead -= ShowGameOver;
    }
    void UpdateLifeBar(float currentLife, float max)
    {
        if (lifeBar != null)
        {
            lifeBar.fillAmount = currentLife / max;
        }
    }
    //void ShowGameOver()
    //{
    //    gameOverText.text = "Game Over";
    //    gameOverText.gameObject.SetActive(true);
    //}
}
