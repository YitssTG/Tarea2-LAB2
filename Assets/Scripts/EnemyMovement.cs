using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool isVertical;
    public float speed = 2f;
    public float minLimits;
    public float maxLimits;

    private bool movingPositive = true;
    void Update()
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
}
