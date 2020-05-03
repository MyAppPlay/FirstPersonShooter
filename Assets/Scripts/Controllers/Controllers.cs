﻿using UnityEngine;


namespace SecondAttempt
{
    public class Controllers : BaseController, IInitialization
    {
        private readonly IExecute[] _executeControllers;

        public int Length => _executeControllers.Length;

        public IExecute this[int index] =>_executeControllers[index]; 

        public Controllers()
        {
            IMotor motor = default;

            if(Application.platform == RuntimePlatform.PS4) { }
            else
            {
                motor = new UnitMotor(ServiceLocatorMonoBehavior.GetService<CharacterController>());
            }
            ServiceLocator.SetServise(new PlayerController(motor));
            ServiceLocator.SetServise(new FlashLightController());
            ServiceLocator.SetServise(new InputController());
            _executeControllers = new IExecute[3];

            _executeControllers[0] = ServiceLocator.Resolve<PlayerController>();
            _executeControllers[1] = ServiceLocator.Resolve<FlashLightController>();
            _executeControllers[2] = ServiceLocator.Resolve<InputController>();
        }


        public void Initialization()
        {
            foreach(var controller in _executeControllers)
            {
                if(controller is IInitialization initialization)
                {
                    initialization.Initialization();
                }
            }
            ServiceLocator.Resolve<PlayerController>().On();
            ServiceLocator.Resolve<InputController>().On(); 
        }
    }
}
