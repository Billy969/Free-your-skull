using UnityEngine;
using UnityEngine.InputSystem;

public class TemporalGameControler : MonoBehaviour
{


    // Componente Rigidbody 2D
    Rigidbody2D playerRb2D;

    // Velocidad de movimiento del jugador
    public float speed;

    // Inputs del jugador (sistema de input de Unity)
    PlayerInput playerInput;

    // Valores del input (x: izquierda/derecha, y: arriba/abajo)
    public Vector2 inputs;

    void Start()
    {
        // Obtenemos el Rigidbody 2D y el sistema de input al iniciar
        playerRb2D = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        // Leer los inputs del jugador desde el sistema de Input
        inputs = playerInput.actions["Move"].ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Mover al jugador según el input
        Movement();
    }
    void Movement()
    {
        // Crear un vector de movimiento 2D a partir del input
        Vector2 moveVelocity = inputs.normalized * speed;

        // Mover el Rigidbody 2D
        playerRb2D.linearVelocity = moveVelocity;
    }

}
