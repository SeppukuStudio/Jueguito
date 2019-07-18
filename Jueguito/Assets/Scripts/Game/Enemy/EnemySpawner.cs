using UnityEngine;
using System.Collections;

namespace Jueguito
{
    /// <summary>
    /// Encargado de spawnear un Tipo de enemigo
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Attributes")]
        /// <summary>
        /// Tipo de enemigo
        /// </summary>
        public EnemyType EnemyType;

        /// <summary>
        /// Velocidad a la que se mueve
        /// </summary>
        public float EnemySpeed;

        /// <summary>
        /// Cada cuanto spawnea un enemigo
        /// </summary>
        public float SpawnTick;

        [Header("References")]
        public Enemy EnemyPrefab;
        public Transform SpawnPoint;

        /// <summary>
        /// Empieza la corrutina de Spawn
        /// </summary>
        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        /// <summary>
        /// Spawnea a un enemigo cada SpawnTick segundos
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                Enemy enemy = Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity);
                enemy.Init(EnemyType, EnemySpeed);

                yield return new WaitForSeconds(SpawnTick);
            }
        }
    }
}
