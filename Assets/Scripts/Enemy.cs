using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Color colorEnemy; 
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorEnemy = spriteRenderer.color; 
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        ColorEventDispatcher.OnPlayerColorChanged += HandleColorChange;
    }
    private void OnDisable()
    {
        ColorEventDispatcher.OnPlayerColorChanged -= HandleColorChange;
    }
    public void HandleColorChange(Color color)
    {
        if(ColoresIguales(color, colorEnemy))
        {
            _rigidbody2D.simulated = false;
        }
        else
        {
            _rigidbody2D.simulated= true;
        }
    }
    bool ColoresIguales(Color a, Color b)
    {
        float tolerancia = 0.01f;
        return Mathf.Abs(a.r - b.r) < tolerancia &&
               Mathf.Abs(a.g - b.g) < tolerancia &&
               Mathf.Abs(a.b - b.b) < tolerancia;
    }
}
