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
    public SpriteRenderer characterColor;

    void Start()
    {
        redButton.onClick.AddListener(() => OnButtonClick(Color.red));
        greenButton.onClick.AddListener(() => OnButtonClick(Color.green));
        blueButton.onClick.AddListener(() => OnButtonClick(Color.blue));
    }

    void OnButtonClick(Color newcolor)
    {
        characterColor.material.color = newcolor;
        Debug.Log("Color cambiado a: " + newcolor);
    }
}
