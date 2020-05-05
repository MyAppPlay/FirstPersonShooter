using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SecondAttempt
{
    public sealed class FlashLightModel : BaseObjectInScene
    {
        #region FIELDS

        [SerializeField] private float _speed = 11.0f;
        [SerializeField] private float _battaryChargeMax = 100.0f;
        [SerializeField] private float _intensity = 1.5f;

        private Light _light;
        private Transform _goFollow;
        private Vector3 _vecOffset;
        private float _share;
        private float _takeAwayTheIntensity;

        #endregion


        #region PROPERTY

        public float Charge => BattaryChargeCurrent / _battaryChargeMax;

        public float BattaryChargeCurrent { get; private set; }

        #endregion


        #region UNITY_METODS

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            transform.position = _goFollow.position;
            _vecOffset = Transform.position - _goFollow.position;
            BattaryChargeCurrent = _battaryChargeMax;
            _light.intensity = _intensity;
            _share = _battaryChargeMax / 4.0f;
            _takeAwayTheIntensity = _intensity / (_battaryChargeMax * 100.0f);
        }

        #endregion


        #region METODS

        public void Switch(FlahLightActiveType value)
        {
            switch (value)
            {
                case FlahLightActiveType.On:
                    _light.enabled = true;
                    Transform.position = _goFollow.position + _vecOffset;
                    Transform.rotation = _goFollow.rotation;
                    break;
                case FlahLightActiveType.None:
                    break;
                case FlahLightActiveType.Off:
                    _light.enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }


        public void Rotation()
        {
            Transform.position = _goFollow.position + _vecOffset;
            Transform.rotation = Quaternion.Lerp(Transform.rotation, _goFollow.rotation, _speed * Time.deltaTime);
        }

        public bool EditBatteryCharge()
        {
            if (BattaryChargeCurrent > 0)
            {
                BattaryChargeCurrent -= Time.deltaTime;
                if (BattaryChargeCurrent < _share)
                    _light.enabled = Random.Range(0, 100) >= Random.Range(0, 10);
                else
                    _light.intensity -= _takeAwayTheIntensity;
                return true;
            }
            return false;
        }

        public bool LowBattary() => BattaryChargeCurrent <= _battaryChargeMax / 2.0f;

        public bool BattaryRecharge()
        {
            if (BattaryChargeCurrent < _battaryChargeMax)
            {
                BattaryChargeCurrent += Time.deltaTime;
                return true;
            }
            return false;
        }


        #endregion
    }
}