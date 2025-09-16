using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Componente Rigidbody 2D
    Rigidbody2D playerRb2D;

    // Velocidad de movimiento del jugador
    public float speed;

    // Inputs del jugador (sistema de input de Unity)
    PlayerInput playerInput;

    // Valores del input (x: izquierda/derecha, y: arriba/abajo)
    public Vector2 inputs;
    // Animator
    public Animator animator;
    public bool hasWeapon = false;
    private bool isAttacking = false;

    // Dirección del último movimiento (para mantener idle en esa dirección)
    Vector2 lastDirection;
    public AudioSource footstepSource;      // El AudioSource del paso
    public AudioClip footstepClip;

    void Start()
    {
        // Obtenemos el Rigidbody 2D y el sistema de input al iniciar
        playerRb2D = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        // Establecer valores iniciales
        animator = GetComponent<Animator>();
        animator.SetBool("IsMoving", false);
        animator.SetFloat("MoveX", 0f);
        animator.SetFloat("MoveY", -1f); // Dirección hacia abajo
                                         // Asegúrate de asignar el clip
        if (footstepSource != null && footstepClip != null)
        {
            footstepSource.clip = footstepClip;
            footstepSource.loop = true; // si tu clip es un bucle de pasos
        }
    }

    void Update()
    {
        // Leer los inputs del jugador desde el sistema de Input
        inputs = playerInput.actions["Move"].ReadValue<Vector2>();
        // Detectar si el jugador se está moviendo
        bool isMoving = inputs.magnitude > 0.1f;
        animator.SetBool("IsMoving", isMoving);

        // Si hay movimiento, actualizamos la dirección
        if (isMoving)
        {
            lastDirection = inputs.normalized;
            if (footstepSource != null && !footstepSource.isPlaying)
            {
                footstepSource.Play();
            }
        }
        else
        {
            // Detener sonido si no hay movimiento
            if (footstepSource != null && footstepSource.isPlaying)
            {
                footstepSource.Stop();
            }
        }
        animator.SetFloat("MoveX", lastDirection.x);
        animator.SetFloat("MoveY", lastDirection.y);


    }

    void FixedUpdate()
    {
        // Mover al jugador según el input
        Movement();
        Attack();
    }
    void Movement()
    {
        // Crear un vector de movimiento 2D a partir del input
        Vector2 moveVelocity = inputs.normalized * speed;

        // Mover el Rigidbody 2D
        playerRb2D.linearVelocity = moveVelocity;
    }
    void Attack()
    {
        // ATAQUE con input system
        if (hasWeapon && playerInput.actions["Attack"].WasPressedThisFrame())
        {

            isAttacking = true;
            animator.SetBool("isAttacking", true);

            // Para detectar colisión con NPC, puedes usar OnTriggerStay en el NPC o un sistema separado
            Debug.Log("¡Atacaste!");
        }
    }
    public void DesactivarAtaque()
    {
        isAttacking = false;
        animator.SetBool("isAttacking", false);
    }

}