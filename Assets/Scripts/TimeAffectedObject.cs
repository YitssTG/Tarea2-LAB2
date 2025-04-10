using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAffectedObject : MonoBehaviour
{
    public Renderer objectRenderer;
    public MonoBehaviour movementScript;

    private Color objectColor;

    private void Awake()
    {
        if (objectRenderer == null)
            objectRenderer = GetComponent<Renderer>();

        objectColor = objectRenderer.material.color;
    }
    private void OnEnable()
    {
        ColorChanger.OnColorChanged += HandleColorChange;
    }
    private void OnDisable()
    {
        ColorChanger.OnColorChanged -= HandleColorChange;
    }
    private void HandleColorChange(Color playerColor)
    {
        bool sameColor = objectColor == playerColor;
        if (movementScript != null)
        {
            
            movementScript.enabled = !sameColor;
        }
    }
}