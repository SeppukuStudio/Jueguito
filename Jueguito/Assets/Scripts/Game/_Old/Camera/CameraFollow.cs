using UnityEngine;

namespace Jueguito
{
    /// <summary>
    /// Cámara que sigue al personaje
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        [Header("References")]
        /// <summary>
        /// Target que sigue
        /// </summary>
        public Transform Target;

        /// <summary>
        /// Diferencia entre la posición de la cámara y el personaje
        /// </summary>
        private Vector3 offset;

        /// <summary>
        /// Calcula variables
        /// </summary>
        private void Start()
        {
            offset = transform.position - Target.position;
        }

        /// <summary>
        /// Utilizamos LateUpdate. Se le llama despues de todos los Update(). Despues del movimiento del personaje
        /// </summary>
        private void LateUpdate()
        {
            //Mueve la cámara a la posición del personaje
            transform.position = Target.position + offset;
        }
    }
}