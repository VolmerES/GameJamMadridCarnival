using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    public float smoothSpeed = 5f;
    public float rotationSpeed = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Rotar la cámara según la orientación del jugador
            Quaternion desiredRotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationSpeed * Time.deltaTime);
            transform.rotation = desiredRotation;

            // Mantener el offset con respecto al jugador
            Vector3 desiredPosition = target.position + desiredRotation * offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
