using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _spriteRendeder;
    private Rigidbody2D _Rigidbody2D;
    private float _horizontal;
    public float velocity;
    private Life lifeScript;
    public Color colorActual;
    [Header("Jump Mechanic")]
    [SerializeField] private int maxJumps = 1;
    [SerializeField] private int jumpsAvailable;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform origin;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layersInteraction;
    [SerializeField] private Color rayCollision = Color.green;
    [SerializeField] private Color rayNotCollision = Color.red;

    [Header("Color Mechanic")]
    [SerializeField] private Color color1 = Color.red;
    [SerializeField] private Color color2 = Color.blue;
    [SerializeField] private Color color3 = Color.green;
    private int colorIndex = 0;
    void Start()
    {
        

        _spriteRendeder = GetComponent<SpriteRenderer>();
        lifeScript = GetComponent<Life>(); 
        ChangeColor(color1);

        if (lifeScript == null)
        {
            Debug.LogError("No se encontr� el script Life en el jugador.");
        }
        ColorChanger.OnColorChanged += HandleColorChanged;

    }
    void OnDisable()
    {
        ColorChanger.OnColorChanged -= HandleColorChanged;
    }
    private void HandleColorChanged(Color newColor)
    {
        colorActual = newColor;
        _spriteRendeder.color = newColor;
    }
    public void ChangeColor(Color newColor)
    {
        colorActual = newColor;
        _spriteRendeder.color = newColor;

        //ColorChanger.OnColorChanged?.Invoke(newColor);
    }
    void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        jumpsAvailable = maxJumps;
    }
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        //if (Input.GetKeyDown(KeyCode.Space) && jumpsAvailable > 0)
        //{
        //    _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, 0);
        //    _Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //    jumpsAvailable--;
        //}
    }
 
    void FixedUpdate()
    {
        _Rigidbody2D.velocity = new Vector2(_horizontal * velocity, _Rigidbody2D.velocity.y);

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
    public void OnMovement(InputAction.CallbackContext context)
    {
        float _horizontal = context.ReadValue<float>();


    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jumpeando");

        if (context.performed && jumpsAvailable > 0)
        {
            _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, 0);
            _Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpsAvailable--;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemigo = collision.GetComponent<Enemy>();

        if (enemigo != null)
        {
            if (ColoresIguales(colorActual, enemigo.colorEnemy))
            {
                Debug.Log("No hay da�o, el color es el mismo.");
            }
            else
            {
                Debug.Log("Recibe da�o.");
                lifeScript.TakeDamage(1);
            }
        }
    }
    bool ColoresIguales(Color a, Color b)
    {
        float tolerancia = 0.01f; 
        return Mathf.Abs(a.r - b.r) < tolerancia &&
               Mathf.Abs(a.g - b.g) < tolerancia &&
               Mathf.Abs(a.b - b.b) < tolerancia;
    }
    private void SetColorByIndex()
    {
        if (colorIndex == 0) ChangeColor(color1);
        else if (colorIndex == 1) ChangeColor(color2);
        else ChangeColor(color3);
    }
    public void OnColorLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            colorIndex--;
            if (colorIndex < 0) colorIndex = 2; 
            SetColorByIndex();
        }
    }

    public void OnColorRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            colorIndex++;
            if (colorIndex > 2) colorIndex = 0; 
            SetColorByIndex();
        }
    }
}
