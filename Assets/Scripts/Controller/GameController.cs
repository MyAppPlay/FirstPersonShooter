using UnityEngine;


namespace SecondAttempt
{
    public sealed class GameController : MonoBehaviour
    {
        private Controllers _controllers;

        #region UNITY_Methods

        private void Start()
        {
            _controllers = new Controllers();
            _controllers.Initialization();
        }

        private void Update()
        {
            for (var i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].Execute();
            }
        }

        #endregion
    }
}
