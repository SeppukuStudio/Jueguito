using UnityEngine;

namespace Jueguito
{
    /// <summary>
    /// Cámara que sigue al personaje de forma suave
    /// </summary>
    public class SmoothCameraFollow : MonoBehaviour
    {
        [Header("Attributes")]
        /// <summary>
        /// Velocidad a la que sigue la cámara al Target
        /// Valor entre [0,1]
        /// </summary>
        public float SmoothSpeed = 0.125f;

        /// <summary>
        /// Diferencia entre la posición de la cámara y el personaje
        /// </summary>
        public Vector3 Offset;

        [Header("References")]
        /// <summary>
        /// Target que sigue
        /// </summary>
        public Transform Target;

        private Vector3 velocity = Vector3.zero;

        /// <summary>
        /// Utilizamos LateUpdate. Se le llama despues de todos los Update(). Despues del movimiento del personaje
        /// </summary>
        private void FixedUpdate()
        {
            //Obtenemos la posición deseada con el offset
            Vector3 desiredPosition = Target.TransformPoint(Offset);

            //Obtenemos la posición smoothed
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, SmoothSpeed);

            //Mueve la cámara 
            transform.position = smoothedPosition;
        }
    }
}