using UnityEngine;


namespace SecondAttempt
{
    public sealed class UIInterface : MonoBehaviour
    {
        #region Fields

        private FlashLightUiText _flashLightUIText;
        private FlashLightUiBar _flashLightUIBar;
        private WeaponUIText _weaponUIText;
        private SelectionObjectMessageUI _selectionObjectMessageUI;

        #endregion


        #region Properties

        public FlashLightUiText LightUIText
        {
            get
            {
                if (!_flashLightUIText)
                    _flashLightUIText = FindObjectOfType<FlashLightUiText>();
                return _flashLightUIText;
            }
        }


        public FlashLightUiBar FlashLightUIBar
        {
            get
            {
                if (!_flashLightUIBar)
                    _flashLightUIBar = GetComponent<FlashLightUiBar>();
                return _flashLightUIBar;
            }
        }


        public WeaponUIText WeaponUIText
        {
            get
            {
                if (!_weaponUIText)
                    _weaponUIText = GetComponent<WeaponUIText>();
                return _weaponUIText;
            }
        }


        public SelectionObjectMessageUI SelectionObjectMessageUI
        {
            get
            {
                if (!_selectionObjectMessageUI)
                    _selectionObjectMessageUI = GetComponent<SelectionObjectMessageUI>();
                return _selectionObjectMessageUI;
            }
        }

        #endregion
    } 
}
