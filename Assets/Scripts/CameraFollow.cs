using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El jugador
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Desplazamiento de la cámara
    public float smoothSpeed = 5f; // Velocidad de suavizado para el movimiento de la cámara
    public float rotationSpeed = 3f; // Velocidad de rotación de la cámara
    public float verticalAngleLimit = 80f; // Límite en grados para la rotación vertical

    private float rotationX = 0f; // Rotación en el eje X (horizontal)
    private float rotationY = 0f; // Rotación en el eje Y (vertical)

    void Start()
{
    // Bloquear el cursor en el centro de la pantalla y hacerlo invisible
    Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
    Cursor.visible = false; // Hace invisible el cursor
}

    void LateUpdate()
    {
        if (target != null)
        {
            // Obtener el movimiento del mouse
            rotationX += Input.GetAxis("Mouse X") * rotationSpeed; // Movimiento horizontal
            rotationY -= Input.GetAxis("Mouse Y") * rotationSpeed; // Movimiento vertical

            // Limitar el ángulo vertical para evitar voltear la cámara completamente
            rotationY = Mathf.Clamp(rotationY, -verticalAngleLimit, verticalAngleLimit);

            // Crear la rotación de la cámara
            Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0f);

            // Calcular la posición deseada para la cámara
            Vector3 desiredPosition = target.position + rotation * offset;

            // Suavizar el movimiento de la cámara
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Mantener la cámara mirando hacia el objetivo (el jugador)
            transform.LookAt(target);
        }
    }
}
