using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI tiempoTexto;
    private float tiempo = 0f;
    private bool contando = true;
    void Update()
    {
        if (contando)
        {
            tiempo += Time.deltaTime;
            tiempoTexto.text = FormatoTiempo(tiempo);
        }
    }
    string FormatoTiempo(float t)
    {
        int minutos = (int)(t / 60);
        int segundos = (int)(t % 60);
        return minutos.ToString("00") + ":" + segundos.ToString("00");
    }
    public void GameOver()
    {
        contando = false;
        string tiempoFinal = FormatoTiempo(tiempo);
        PlayerPrefs.SetString("TiempoFinal", tiempoFinal);
        PlayerPrefs.Save(); 
        Debug.Log("Tiempo guardado: " + tiempoFinal); 
        SceneManager.LoadScene("GameOver");
    }
}
