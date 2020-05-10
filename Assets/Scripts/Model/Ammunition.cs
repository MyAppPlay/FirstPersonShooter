using UnityEngine;


namespace SecondAttempt
{
    public abstract class Ammunition : BaseObjectScene
    {
        #region Fields

        public AmmunitionType Type = AmmunitionType.Bullet;

        [SerializeField] private float _timeToDestruct = 3.0f;
        [SerializeField] private float _baseDamage = 10.0f;

        protected float _curDamage; // todo доделать свой урон-
        private float _lossOfDamageAtTime = 0.2f;

        private ITimeRemaining _timeRemaining;

        #endregion


        #region UNITY_Methods

        protected override void Awake()
        {
            base.Awake();
            _curDamage = _baseDamage;
        }

        private void Start()
        {
            _timeRemaining = new TimeRemaining(LossOfDamage, 1.0f, true);
            _timeRemaining.AddTimeRemaining();
        }

        #endregion

        private void Update()
        {
            _timeToDestruct -= Time.deltaTime;
            if (_timeToDestruct <= 0)
            {
                GetComponent<PoolObject>().ReturnToPool();
                _timeToDestruct = 3.0f;
            }
        }

        #region Method

        public void AddForce(Vector3 dir)
        {
            if (!Rigidbody) return;
            Rigidbody.AddForce(dir);
        }

        private void LossOfDamage()
        {
            _curDamage -= _lossOfDamageAtTime;
        }

        protected void DestroyAmmunition()
        {
            _timeRemaining.RemoveTimeRemaining();
            GetComponent<PoolObject>().ReturnToPool();
        }

        #endregion
    }
}
