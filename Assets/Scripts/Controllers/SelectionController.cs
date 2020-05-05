using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SecondAttempt
{
    public sealed class SelectionController : BaseController, IExecute
    {
        private readonly Camera _mainCamera;
        private readonly Vector2 _center;
        private readonly float _dedicateDistance = 20.0f;
        private GameObject _dedicateObject;
        private ISelectObject _selectedObject;
        private bool _nullString;
        private bool _isSelectedObject;

        public SelectionController()
        {
            _mainCamera = Camera.main;
            _center = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
        }

        public void Execute()
        {
            if (!IsActive) return;
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(_center),
                out var hit, _dedicateDistance))
            {

                _nullString = false;
            }
            else if (!_nullString)
            {
                UIInterface.SelectionObjectMessageUI.Text = string.Empty;
                _nullString = true;
                _dedicateObject = null;
                _isSelectedObject = false;
            }
            if (_isSelectedObject)
            {
                ///
                switch (_selectedObject)
                {
                    //case 
                }
            }

        }

        private void SelectObject(GameObject obj)
        {
            if (obj == _dedicateObject) return;
            _selectedObject = obj.GetComponent<ISelectObject>();
            if (_selectedObject != null)
            {
                UIInterface.SelectionObjectMessageUI.Text = _selectedObject.GetMessage();
                _isSelectedObject = true;
            }
            else
            {
                UIInterface.SelectionObjectMessageUI.Text = string.Empty;
                _isSelectedObject = false;
            }
            _dedicateObject = obj;
        }
    }

}