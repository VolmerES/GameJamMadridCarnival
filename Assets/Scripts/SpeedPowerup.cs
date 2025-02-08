using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public float speedMultiplier = 2f; 
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ActivateSpeedBoost(speedMultiplier, duration);
                Destroy(gameObject); // Eliminar el power-up después de recogerlo
            }
        }
    }
}
