﻿using System.Collections.Generic;
using UnityEngine;


namespace SecondAttempt
{
    public abstract class Weapon : BaseObjectScene
    {
        #region Fields

        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _force = 999;
        [SerializeField] protected float _rechergeTime = 0.2f;

        public Ammunition Ammunition;
        public Clip Clip;
        public AmmunitionType[] AmmunitionTypes = { AmmunitionType.Bullet };

        private int _maxCountAmmunition = 40;
        private int _minCountAmmunition = 20;
        private int _countClip = 5;

        private Queue<Clip> _clips = new Queue<Clip>();

        protected bool _isReady = true;
        protected ITimeRemaining _timeRemaining;

        #endregion

        public int CountClip => _clips.Count;

        private void Start()
        {
            _timeRemaining = new TimeRemaining(ReadyShoot, _rechergeTime);
            for (var i = 0; i <= _countClip; i++)
            {
                AddClip(new Clip { CountAmmunition = Random.Range(_minCountAmmunition, _maxCountAmmunition) });
            }
            
            ReloadClip();
        }

        #region Methods

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

        #endregion
    }
}