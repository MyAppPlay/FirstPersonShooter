using UnityEngine;


namespace SecondAttempt
{
    public class InputController : BaseController, IExecute
    {
        private KeyCode _activeFlashLight = KeyCode.F;

        public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                ServiceLocator.Resolve<FlashLightController>().Switch();
            }
        }
    }
}