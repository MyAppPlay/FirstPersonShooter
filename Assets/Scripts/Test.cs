using UnityEngine;


namespace SecondAttempt
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            FindObjectOfType<FlashLightModel>().Layer = 2;
        }
    }
}