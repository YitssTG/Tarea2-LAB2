using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool isVertical;
    public float speed = 2f;
    public float minLimits;
    public float maxLimits;

    public Color enemyColor;
    private bool isPaused = false;


    private bool movingPositive = true;
    private Rigidbody2D _rigidbody2D;
    private Vector2 direction;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        direction = isVertical ? Vector2.up : Vector2.right;

        ColorChanger.OnColorChanged += HandleColorChanged;
    }

    void Update()
    {
        if (!isPaused)  
        {
            MoveEnemy();
        }
    }
    private void MoveEnemy()
    {
        Vector3 position = transform.position;

        if (isVertical)
        {
            if (movingPositive)
                position.y += speed * Time.deltaTime;
            else
                position.y -= speed * Time.deltaTime;

            if (position.y >= maxLimits) movingPositive = false;
            if (position.y <= minLimits) movingPositive = true;
        }
        else
        {
            if (movingPositive)
                position.x += speed * Time.deltaTime;
            else
                position.x -= speed * Time.deltaTime;

            if (position.x >= maxLimits) movingPositive = false;
            if (position.x <= minLimits) movingPositive = true;
        }
        transform.position = position;
    }
    private void HandleColorChanged(Color newColor)
    {
        if (AreColorsEqual(newColor, enemyColor))
        {
            Pause();  
        }
        else
        {
            Resume(); 
        }
    }
    private bool AreColorsEqual(Color color1, Color color2)
    {
        float tolerance = 0.01f; 
        return Mathf.Abs(color1.r - color2.r) < tolerance &&
               Mathf.Abs(color1.g - color2.g) < tolerance &&
               Mathf.Abs(color1.b - color2.b) < tolerance;
    }
    private void Pause()
    {
        isPaused = true;
    }

    private void Resume()
    {
        isPaused = false;
    }

    private void OnDestroy()
    {
        ColorChanger.OnColorChanged -= HandleColorChanged;
    }
    //void ()
    //{
    //    Vector3 position = transform.position;

    //    if (isVertical)
    //    {
    //        if (movingPositive)
    //            position.y += speed * Time.deltaTime;
    //        else 
    //            position.y -= speed * Time.deltaTime;

    //        if (position.y >= maxLimits) movingPositive = false;
    //        if (position.y <= minLimits) movingPositive = true;
    //    }
    //    else
    //    {
    //        if (movingPositive)
    //            position.x += speed * Time.deltaTime;
    //        else
    //            position.x -= speed * Time.deltaTime;

    //        if (position.x >= maxLimits) movingPositive = false;
    //        if (position.x <= minLimits) movingPositive = true;
    //    }
    //    transform.position = position;
    //}
}
