using System.Collections.Generic;
using UnityEngine;


namespace SecondAttempt
{
    public abstract class Weapon : BaseObjectInScene
    {

        public Ammunitions Ammunitions;
        public Clip Clip;
        public AmmunitionType[] AmmunitionTypes = { AmmunitionType.Bullet };

        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _force = 999.0f;
        [SerializeField] protected float _rechargeTime = 0.2f;

        protected bool _isReady = true;
        protected ITimeRemaining _timeRemaining;


        private Queue<Clip> _clips = new Queue<Clip>();

        private int _maxCounAmmunition = 40;
        private int _minCountAmmunition = 20;
        private int _countClip = 5;


        public int CountClip => _clips.Count;

        private void Start()
        {
            _timeRemaining = new TimeRemaining(ReadyShoot,_rechargeTime);
            for(var i = 0; i <= _countClip; i++)
            {
               // AddClip(new Clip { });
            }

            ReloadClip();
        }

        public abstract void Fire();

        protected void ReadyShoot()
        {
            _isReady = true;
        }

        protected void AddClip(Clip clip)
        {
            _clips.Enqueue(clip);
        }

        public void ReloadClip()
        {
            if (CountClip <= 0) return;
            Clip = _clips.Dequeue();
        }

    }

}