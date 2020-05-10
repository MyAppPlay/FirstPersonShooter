using UnityEngine;


namespace SecondAttempt
{
    [AddComponentMenu("Pool/PoolObject")]//+
    public class PoolObject : MonoBehaviour
    {
        #region Methods

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}