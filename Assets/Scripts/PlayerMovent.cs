using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 8f; // Velocidad al correr
    public float gravity = 90f; // Gravedad personalizada

    private Vector3 moveDirection;
    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>(); // Obtener el Animator del personaje
        rb = GetComponent<Rigidbody>();  // Obtener el Rigidbody

        // Asegurar que el Rigidbody tenga la configuración correcta
        rb.useGravity = false; // Desactivamos la gravedad por defecto para usar la personalizada
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        moveDirection = new Vector3(moveX, 0, moveZ).normalized * currentSpeed;

        // Rotar el personaje en la dirección del movimiento
        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
            anim.SetBool("isWalking", !Input.GetKey(KeyCode.LeftShift));
            anim.SetBool("isRunning", Input.GetKey(KeyCode.LeftShift));
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }

    void FixedUpdate()
    {
        // Aplicar el movimiento con Rigidbody
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y - gravity * Time.fixedDeltaTime, moveDirection.z);
    }
}
