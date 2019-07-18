using UnityEngine;

namespace Jueguito
{
    /// <summary>
    /// Enum con los diferentes tipos de enemigos
    /// </summary>
    public enum EnemyType { UP, DOWN, RIGHT, LEFT };

    /// <summary>
    /// Controla el comportamiento del enemigo
    /// </summary>
    public class Enemy : MonoBehaviour
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

        //Own References
        private Rigidbody2D rb;

        //Attributes
        private Vector2 direction;

        /// <summary>
        /// Obtiene referencias
        /// </summary>
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Inicializa valores de variables
        /// </summary>
        private void Start()
        {
            Init(EnemyType, EnemySpeed);
        }

        /// <summary>
        /// Inicializa los valores del enemigo
        /// </summary>
        /// <param name="enemyType"></param>
        /// <param name="enemySpeed"></param>
        public void Init(EnemyType enemyType, float enemySpeed)
        {
            EnemyType = enemyType;
            EnemySpeed = enemySpeed;

            direction = Vector2.zero;

            switch (EnemyType)
            {
                case EnemyType.UP:
                    direction = Vector2.up;
                    break;
                case EnemyType.DOWN:
                    direction = Vector2.down;
                    break;
                case EnemyType.LEFT:
                    direction = Vector2.left;
                    break;
                case EnemyType.RIGHT:
                    direction = Vector2.right;
                    break;

            }
        }

        /// <summary>
        /// Aplica velocidad al enemigo en función de su dirección
        /// </summary>
        private void FixedUpdate()
        {        
            //Aplica velocidad al rigidbody
            rb.velocity = direction * EnemySpeed;
        }

    }
}
