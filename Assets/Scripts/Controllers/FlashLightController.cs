using UnityEngine;


namespace SecondAttempt
{
    public class FlashLightController : BaseController, IExecute, IInitialization
    {
        private FlashLightModel _flashLightModel;
        private FlashLightUI _flashLightUI;
        private bool _light;

        public void Initialization()
        {
            _flashLightModel = Object.FindObjectOfType<FlashLightModel>();
            _flashLightUI = Object.FindObjectOfType<FlashLightUI>();
        }

        public void Execute()
        {
            _flashLightModel.Rotation();
            _flashLightModel.EditBatteryCharge(_light);

            _flashLightUI.Text = _flashLightModel.BattaryChargeCurrent;
            _flashLightUI.Fill = _flashLightModel.BattaryChargeCurrent / 100;
        }

        public override void On()
        {
            _light = true;
            if (IsActive) return;
            if (_flashLightModel.BattaryChargeCurrent <= 0) return;
            base.On();
            _flashLightModel.Switch(FlahLightActiveType.On);
            _flashLightUI.SetActive(true);
        }

        public override void Off()
        {
            _light = false;
            if (!IsActive) return;
            base.Off();
            _flashLightModel.Switch(FlahLightActiveType.Off);
        }
    }
}