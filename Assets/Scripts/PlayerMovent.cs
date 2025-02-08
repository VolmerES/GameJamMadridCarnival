using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    //public float sprintSpeed = 8f;
    public float gravityMultiplier = 2f;
    public Transform cameraTransform; 
    public float speedMultiplier = 1f;
    public float powerupDuration = 5f;

    private Vector3 moveDirection;
    private Animator anim;
    private CharacterController controller;
    private float verticalVelocity;
    private bool isGrounded;
    private bool hasPowerup = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
         float currentSpeed = speed * speedMultiplier;

        // Dirección relativa a la cámara
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;

        moveDirection = (forward * moveZ + right * moveX).normalized;

        verticalVelocity -= Physics.gravity.y * gravityMultiplier * Time.deltaTime;

        Vector3 movement = moveDirection * currentSpeed;
        movement.y = verticalVelocity;

        controller.Move(movement * Time.deltaTime);

        // **Evitar rotación instantánea al moverse hacia atrás**
        if (moveDirection.magnitude > 0)
        {
            float angleDifference = Vector3.Angle(transform.forward, moveDirection);

            // Solo girar si el ángulo con la dirección nueva no es mayor a 120 grados
            if (angleDifference < 120f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * 10f);
            }
        }

        // Actualizar animaciones
        bool isMoving = moveX != 0 || moveZ != 0;
        anim.SetBool("isWalking", isMoving && !hasPowerup);
    }

    public void ActivateSpeedBoost(float multiplier, float duration)
    {
        if (!hasPowerup)
        {
            hasPowerup = true;
            speedMultiplier = multiplier;
            anim.SetBool("isRunning", true);
            Invoke(nameof(ResetSpeed), duration);
        }
    }

    // Restaurar la velocidad después del tiempo
    private void ResetSpeed()
    {
        speedMultiplier = 1f;
        hasPowerup = false;
        anim.SetBool("isRunning", false);

    }
}
