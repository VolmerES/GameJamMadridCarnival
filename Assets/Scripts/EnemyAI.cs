using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Asigna el jugador en el Inspector
    private NavMeshAgent agent;

    public float chaseRange = 10f; // Distancia a la que el enemigo empieza a seguir
    public float attackRange = 2f; // Distancia de ataque
    public float speed = 3.5f; // Velocidad del enemigo

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed; // Asigna la velocidad al NavMeshAgent
    }

    void Update()
    {
        if (player == null) return; // Asegura que haya un jugador asignado

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            agent.SetDestination(player.position); // Persigue al jugador
        }

        if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        agent.isStopped = true; // Detiene el movimiento
        // Aquí puedes agregar animaciones o ataques
        Debug.Log("Atacando al jugador");
        agent.isStopped = false; // Reactiva el movimiento después del ataque
    }
}

