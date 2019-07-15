﻿using UnityEngine;

namespace Jueguito
{
    /// <summary>
    /// Controla el movimiento del personaje
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Attributes")]
        public float Velocity;

        //Components
        private Rigidbody2D rb;

        //Variables
        private Vector2 inputMovement;

        /// <summary>
        /// Obtiene referencias
        /// </summary>
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Detecta input en pantalla
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

                //Movemos el personaje
                inputMovement = new Vector2(touchPosition.x - transform.position.x, touchPosition.y - transform.position.y);
                inputMovement.Normalize();

                //Para el estado actual del touch(Began, Ended, Moved, Stationary, Canceled)
                // Debug.Log(touch.phase);
            }
            else
                inputMovement = Vector2.zero;

            //Recorrer todos los dedos y dibuja lineas a cada dedo
            Touch[] touches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                //Dedo concreto
                Touch touch = touches[i];

                //Obtenemos la posición en el mundo. Touch.position nos devuelve la posición del dedo en pixeles
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f; //No queremos mover en z el personaje.

                Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
            }
        }

        private void FixedUpdate()
        {
            //Rigidbody: Mass, Drag y Gravity para modificar las propiedades del jugador

            Vector3 movement = inputMovement * Velocity;
            rb.velocity = movement;
        }
    }
}