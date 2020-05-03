using System;
using UnityEngine;


namespace SecondAttempt
{
    public sealed class FlashLightModel : BaseObjectScene
    {
        #region FIELDS

        [SerializeField] private float _speed = 11.0f;
        [SerializeField] private float _battaryChargeMax = 100.0f;

        private Light _light;
        private Transform _goFollow;
        private Vector3 _vecOffset;

        #endregion


        #region PROPERTY

        public float BattaryChargeCurrent { get; private set; }

        #endregion


        #region UNITY_METODS

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vecOffset = Transform.position - _goFollow.position;
            BattaryChargeCurrent = _battaryChargeMax;
            Switch(FlahLightActiveType.Off);
            Rotation();
        }

        #endregion


        #region METODS

        public void Switch(FlahLightActiveType value)
        {
            switch(value)
            {
                case FlahLightActiveType.On:
                    _light.enabled = true;
                    Transform.position = _goFollow.position + _vecOffset;
                    Transform.rotation = _goFollow.rotation;
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

        public void EditBatteryCharge(bool value)
        {
            if (BattaryChargeCurrent >= 0 && value)
            {
                BattaryChargeCurrent -= Time.deltaTime;
            }
            else if (BattaryChargeCurrent < _battaryChargeMax)
                BattaryChargeCurrent += Time.deltaTime;
            else BattaryChargeCurrent = _battaryChargeMax;
        }

        #endregion
    }
}