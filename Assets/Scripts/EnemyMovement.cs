using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    // Start se llama una vez antes de la primera ejecución de Update después de crear el MonoBehaviour
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Update se llama una vez por frame
    void Update()
    {
        if (player != null) 
        {
            navMeshAgent.SetDestination(player.position);
        }
    }
}
