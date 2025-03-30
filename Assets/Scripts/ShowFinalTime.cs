using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFinalTime : MonoBehaviour
{
    public TextMeshProUGUI textFinalTime;

    void Start()
    {
        if (textFinalTime == null)
        {
            Debug.LogError("No se asignó el objeto TextMeshProUGUI en el Inspector.");
            return;
        }

        string tiempo = PlayerPrefs.GetString("TiempoFinal", "00:00"); // Obtiene el tiempo o "00:00" si no hay guardado
        textFinalTime.text = "Tiempo: " + tiempo;
        Debug.Log("Tiempo cargado: " + tiempo);
    }
}
