﻿namespace SecondAttempt
{
    public sealed class PlayerController : BaseController, IExecute
    {
        private readonly IMotor _motor;

        #region Methods

        public PlayerController(IMotor motor)
        {
            _motor = motor;
        }

        public void Execute()
        {
            if (!IsActive) return;
            _motor.Move();
        }

        #endregion
    }
}
