using UnityEngine;

namespace Jueguito
{
    /// <summary>
    /// Controla el movimiento del personaje
    /// </summary>
    public class Player : MonoBehaviour
    {
        public delegate void FloatChanged(float newValue);
        public static event FloatChanged OnFearChanged;

        [Header("Attributes")]
        /// <summary>
        /// Velocidad de mov del personaje
        /// </summary>
        public float Speed;

        /// <summary>
        /// Velocidad a la que aumenta el miedo
        /// </summary>
        public float FearSpeed;

        /// <summary>
        /// Velocidad a la que se recupera del miedo
        /// </summary>
        public float RecoverSpeed;

        [Header("References")]
        public FixedJoystick FixedJoystick;

        //Properties

        /// <summary>
        /// Valor entre 0 y 1 que indica cuanto miedo tienes
        /// 0 nada
        /// 1 pierdes
        /// </summary>
        public float Fear
        {
            get { return fear; }
            set
            {
                fear = value;
                OnFearChanged?.Invoke(fear);
            }
        }
        private float fear;

        //Own references
        private Rigidbody2D rb;


        /// <summary>
        /// Obtiene referencias
        /// </summary>
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Inicializa variables
        /// </summary>
        private void Start()
        {
            fear = 0f;
        }

        /// <summary>
        /// Aplica velocidad al personaje en función del input del joystick
        /// </summary>
        private void FixedUpdate()
        {
            //Obtención de una de las 8 direcciones posibles
            Vector2 direction = new Vector2(Mathf.Round(FixedJoystick.Horizontal), Mathf.Round(FixedJoystick.Vertical));

            //Valor de la velocidad con la que se mueve el personaje
            float input = Mathf.Max(Mathf.Abs(FixedJoystick.Horizontal), Mathf.Abs(FixedJoystick.Vertical));

            //Aplica velocidad al rigidbody
            rb.velocity = new Vector2(Speed * input * direction.x, Speed * input * direction.y);
        }

        /// <summary>
        /// Es llamado cuando el jugador entra en el area de efecto de los enemigos
        /// </summary>
        public void Panic()
        {
            Debug.Log("Tienes el sida");
        }
    }
}