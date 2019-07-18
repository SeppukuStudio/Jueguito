using UnityEngine;

namespace Jueguito
{
    /// <summary>
    /// Zona en la que los enemigos desaparecen cuando entran en ella
    /// </summary>
    public class EnemyDeadZone : MonoBehaviour
    {
        /// <summary>
        /// Detecta la colisión con un enemigo y lo destruye
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy)
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}