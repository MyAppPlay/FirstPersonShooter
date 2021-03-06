﻿using System;
using UnityEngine;


namespace SecondAttempt
{
    public sealed class Aim : MonoBehaviour, ICollision, ISelectObj
    {
        #region Fields

        public float Hp = 100;
        public event Action OnPointChange = delegate { };

        private bool _isDead;
        private float _timeToDestroy = 10.0f;

        #endregion


        #region Methods

        //todo дописать поглащение урона
        public void CollisionEnter(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                if (!TryGetComponent<Rigidbody>(out _))
                {
                    gameObject.AddComponent<Rigidbody>();
                }
                Destroy(gameObject, _timeToDestroy);

                OnPointChange.Invoke();
                _isDead = true;
            }
        }

        public string GetMessage()
        {
            return $"{gameObject.name} - {Hp}";
        }

        #endregion    
    }
}
