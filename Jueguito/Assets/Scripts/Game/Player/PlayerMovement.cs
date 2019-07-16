using UnityEngine;

namespace Jueguito
{
    /// <summary>
    /// Controla el movimiento del personaje
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        /// <summary>
        /// Enum que representa los posibles estados del personaje
        /// </summary>
        private enum PlayerState { IDLE, WALK, RUN };

        [Header("Attributes")]
        /// <summary>
        /// Velocidad de movimiento del personaje corriendo
        /// </summary>
        public float RunVelocity;

        /// <summary>
        /// Velocidad de movimiento del personaje andando
        /// </summary>
        public float WalkVelocity;

        /// <summary>
        /// Distancia que debe haber entre dedo y pj para que ande y no corra
        /// </summary>
        public float WalkDeadzone;

        /// <summary>
        /// Distancia que debe haber entre dedo y pj para que se realice el movimiento
        /// </summary>
        public float DeadZone;


        //Components
        private Rigidbody2D rb;

        //Variables
        private Vector2 inputMovement;
        private PlayerState playerState;

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
            inputMovement = Vector2.zero;
            playerState = PlayerState.IDLE;
        }

        /// <summary>
        /// Detecta input en pantalla
        /// Calcula el nuevo estado del personaje
        /// </summary>
        private void Update()
        {
            //Si hay algun dedo en pantalla
            if (Input.touchCount > 0)
            {
                //Dedo concreto
                Touch touch = Input.GetTouch(0);

                //Obtenemos la posición en el mundo. Touch.position nos devuelve la posición del dedo en pixeles
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f; //No queremos mover en z el personaje.

                //Distancia entre el dedo y el personaje
                Vector2 distance = touchPosition - transform.position;

                //Vector de input
                inputMovement = distance.normalized;

                //Se calcula el nuevo estado en función de la distancia
                if (distance.magnitude < DeadZone)
                    playerState = PlayerState.IDLE;
                else if (distance.magnitude < WalkDeadzone)
                    playerState = PlayerState.WALK;
                else
                    playerState = PlayerState.RUN;


                //Para el estado actual del touch(Began, Ended, Moved, Stationary, Canceled)
                // Debug.Log(touch.phase);
            }
            else
                inputMovement = Vector2.zero;

            //Recorrer todos los dedos y dibuja lineas a cada dedo
            //Touch[] touches = Input.touches;
            //for (int i = 0; i < Input.touchCount; i++)
            //{
            //    //Dedo concreto
            //    Touch touch = touches[i];

            //    //Obtenemos la posición en el mundo. Touch.position nos devuelve la posición del dedo en pixeles
            //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            //    touchPosition.z = 0f; //No queremos mover en z el personaje.

            //    //Dibuja linea desde origen al dedo
            //    Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
            //}
        }

        /// <summary>
        /// Aplica velocidad de movimiento al personaje en función del estado
        /// </summary>
        private void FixedUpdate()
        {
            //Rigidbody: Mass, Drag y Gravity para modificar las propiedades del jugador
            Vector2 velocity = Vector2.zero;

            //En función del estado aplica una velocidad
            switch(playerState)
            {
                case PlayerState.WALK:
                    velocity = inputMovement * WalkVelocity;
                    break;
                case PlayerState.RUN:
                    velocity = inputMovement * RunVelocity;
                    break;
            }

            //Se aplica la velocidad al rb
            rb.velocity = velocity;
        }
    }
}