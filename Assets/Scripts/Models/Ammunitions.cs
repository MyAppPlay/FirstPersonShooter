using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SecondAttempt
{
    public abstract  class Ammunitions : BaseObjectInScene
    {
        public AmmunitionType Type = AmmunitionType.Bullet;

        private float _timeToDestruct = 10.0f;
        private float _baseDamage = 10.0f;

        private ITimeRemaining _timeRemaining;

        protected float _curDamage;//доделать свой урон
        protected float _lossOffDamageAtTime = 0.2f;


        protected override  void Awake()
        {
            base.Awake();
            _curDamage = _baseDamage;
        }

        private void Start()
        {
            Destroy(gameObject, _timeToDestruct);
            _timeRemaining = new TimeRemaining(LossOfDamage, 1.0f, true);
            _timeRemaining.AddTimeRemaining();
        }

        public void AddForse(Vector3 dir)
        {
            if (!Rigidbody) return;
            Rigidbody.AddForce(dir);
        }

        private void LossOfDamage()
        {
            _curDamage -= _lossOffDamageAtTime;
        }

        protected void DestroyAmmunitoin()
        {
            Destroy(gameObject);
            _timeRemaining.RemoveTimeRemaining();
            //вернуть в пул
        }
    } 
}
