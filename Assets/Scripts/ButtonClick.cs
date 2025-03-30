using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonClick : MonoBehaviour
{
    public Button redButton;
    public Button greenButton;
    public Button blueButton;
    public PlayerController player;

    void Start()
    {
        redButton.onClick.AddListener(() => OnButtonClick(Color.red));
        greenButton.onClick.AddListener(() => OnButtonClick(Color.green));
        blueButton.onClick.AddListener(() => OnButtonClick(Color.blue));
    }

    void OnButtonClick(Color newcolor)
    {
        if (player != null)
        {
            player.ChangeColor(newcolor);
            Debug.Log("Color cambiado a: " + newcolor);
        }
        else
        {
            Debug.Log("No se asigno el playercontroller ne buttonclick");
        }
        
    }
}
