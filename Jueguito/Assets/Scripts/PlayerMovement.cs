using UnityEngine;

/// <summary>
/// Controla el movimiento del personaje
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Vector2 inputMovement;

    private void Update()
    {
        //Touch myTouch = Input.GetTouch(0);

        //Touch[] myTouches = Input.touches;
        //for (int i = 0; i < Input.touchCount; i++)
        //{
        //    //Do something with the touches
        //}

        //TEST
        transform.Rotate(Vector3.forward, 5);
    }
}
