using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChanger : MonoBehaviour
{
    public SpriteRenderer characterRenderer;
    public Color[] availableColors = new Color[3];
    public int currentColorIndex = 0;

    public static event Action<Color> OnColorChanged;

    private void Start()
    {
        ApplyColor();  // Inicializa el color al inicio
    }
    public void OnChangeColorLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentColorIndex--;
            if (currentColorIndex < 0)
                currentColorIndex = availableColors.Length - 1;

            ApplyColor();
        }
    }
    public void OnChangeColorRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentColorIndex++;
            if (currentColorIndex >= availableColors.Length)
                currentColorIndex = 0;

            ApplyColor();
        }
    }
    private void ApplyColor()
    {
        characterRenderer.color = availableColors[currentColorIndex];
        OnColorChanged?.Invoke(availableColors[currentColorIndex]);
    }
    public void ChangeColor(Color newColor)
    {
        OnColorChanged?.Invoke(newColor);
    }
}