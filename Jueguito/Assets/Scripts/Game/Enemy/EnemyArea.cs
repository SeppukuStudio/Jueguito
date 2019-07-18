using UnityEngine;

namespace Jueguito
{
    /// <summary>
    /// Detecta que el jugador entra en el area y le asusta
    /// </summary>
    public class EnemyArea : MonoBehaviour
    {
        /// <summary>
        /// Detecta si el jugador está en su area de efecto y le asusta
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerStay2D(Collider2D collision)
        {
            Player player = collision.GetComponent<Player>();
            if (player)
            {
                player.Panic();
            }
        }

    }
}