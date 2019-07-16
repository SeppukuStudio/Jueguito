using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Own references
    private NavMeshAgent navMeshAgent;

    /// <summary>
    /// Obtiene referencias
    /// </summary>
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Persigue al jugador
    /// </summary>
    private void Update()
    {
        navMeshAgent.SetDestination(transform.position - new Vector3(0,1,0));

        //Comprueba si ha llegado al destino
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //Do something...
        }
    }
}
