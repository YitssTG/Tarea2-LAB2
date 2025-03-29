using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _spriteRendeder;
    private Rigidbody2D _Rigidbody2D;
    private float horizontal;
    public float velocity;
    [Header("Jump Mechanic")]
    [SerializeField] private int maxJumps = 1;
    [SerializeField] private int jumpsAvailable;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform origin;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layersInteraction;
    [SerializeField] private Color rayCollision = Color.green;
    [SerializeField] private Color rayNotCollision = Color.red;

    [Header("Color Change")]
    public GameObject buttonRed;
    public GameObject buttonGreen;
    public GameObject buttonBlue;
    void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRendeder = GetComponent<SpriteRenderer>();
        jumpsAvailable = maxJumps;
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && jumpsAvailable > 0)
        {
            _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, 0);
            _Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpsAvailable--;
        }
    }
    void FixedUpdate()
    {
        _Rigidbody2D.velocity = new Vector2(horizontal * velocity, _Rigidbody2D.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(origin.position, Vector2.down, distance, layersInteraction);

        if(hit.collider != null)
        {
            Debug.DrawRay(origin.position, Vector2.down * hit.distance, rayCollision);
            jumpsAvailable = maxJumps;
        }
        else
        {
            Debug.DrawRay(origin.position, Vector2.down * distance, rayNotCollision);
        }
    }
     void ChangeColor(Color newColor)
     {
        _spriteRendeder.color = newColor;
     }
}
