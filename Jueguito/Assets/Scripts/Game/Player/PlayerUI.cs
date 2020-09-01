using UnityEngine;
using UnityEngine.UI;


namespace Jueguito
{
    /// <summary>
    /// Controlador del UI del jugador
    /// </summary>
    public class PlayerUI : MonoBehaviour
    {
        public Image FearImage;

        Player player;

        private void Awake()
        {
            player = GetComponent<Player>();
            player.OnFearChanged += FearChangedCallback;
        }

        private void FearChangedCallback(float newValue)
        {

        }

        private void Start()
        {
            
        }
    }
}