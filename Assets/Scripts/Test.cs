using UnityEngine;

namespace Geekbrains
{
    public class Test : MonoBehaviour
    {
        public Canvas Canvas;
        private void Start()
        {
            FindObjectOfType<FlashLightModel>().Layer = 2;

            gameObject.CompareTag(TagManager.PLAYER);
            
            CustumDebug.Log(1234);
        }

        private void OnValidate()
        {
            if (TryGetComponent(out Canvas canvas))
            {
                Canvas = canvas;
                Canvas.enabled = false;
            }
        }
    }
}
