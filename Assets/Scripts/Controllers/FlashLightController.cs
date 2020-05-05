using UnityEngine;


namespace SecondAttempt
{
    public sealed class FlashLightController : BaseController, IExecute, IInitialization
    {
        private FlashLightModel _flashLightModel;

        public void Initialization()
        {
            UIInterface.LightUIText.SetActive(false);
            UIInterface.FlashLightUIBar.SetActive(false);
        }

        public override void On(params BaseObjectInScene[] flashLight)
        {
            if (IsActive) return;
            if (flashLight.Length > 0) _flashLightModel = flashLight[0] as FlashLightModel;
            if (_flashLightModel == null) return;
            if (_flashLightModel.BattaryChargeCurrent <= 0) return;
            base.On(_flashLightModel);
            _flashLightModel.Switch(FlahLightActiveType.On);
            UIInterface.LightUIText.SetActive(true);
            UIInterface.FlashLightUIBar.SetActive(true);
            UIInterface.FlashLightUIBar.SetColor(Color.green);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLightModel.Switch(FlahLightActiveType.Off); ;
            UIInterface.FlashLightUIBar.SetActive(false);
            UIInterface.LightUIText.SetActive(false);
        }

        public void Execute()
        {
            if (!IsActive)
            {
                return;
            }
            if (_flashLightModel.EditBatteryCharge())
            {
                UIInterface.LightUIText.Text = _flashLightModel.BattaryChargeCurrent;
                UIInterface.FlashLightUIBar.Fill = _flashLightModel.Charge;
                _flashLightModel.Rotation();

                if (_flashLightModel.LowBattary())
                {
                    UIInterface.FlashLightUIBar.SetColor(Color.red);
                }
            }
            else
            {
                Off();
            }
        }
    }
}