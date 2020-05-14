using UnityEngine;


namespace SecondAttempt
{
    [AddComponentMenu("Pool/PoolSetup")]
    public class PoolSetup : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PoolPart[] pools;

        #endregion

        private void Awake()
        {
            Initialize();
        }

        #region Methods

        private void OnValidate()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].NamePrefab = pools[i].PrefabPoolObj.name;
            }
        }

        private void Initialize()
        {
            PoolManager.Initialize(pools);
        }

        #endregion
    }

}