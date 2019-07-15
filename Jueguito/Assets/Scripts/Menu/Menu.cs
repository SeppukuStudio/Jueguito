using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jueguito
{
    public class Menu : MonoBehaviour
    {
        /// <summary>
        /// Pasa a la escena de juego
        /// </summary>
        public void Play()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
