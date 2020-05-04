using UnityEngine;


namespace SecondAttempt
{
    public sealed class UIInterface : MonoBehaviour
    {
        #region Fields

        private FlashLightUIText _flashLightUIText;
        private FlashLightUIBar _flashLightUIBar;
        private WeaponUIText _weaponUIText;
        private SelectionObjectMessageUI _selectionObjectMessageUI;

        #endregion


        #region Properties

        public FlashLightUIText LightUIText
        {
            get
            {
                if (!_flashLightUIText)
                    _flashLightUIText = FindObjectOfType<FlashLightUIText>();
                return _flashLightUIText;
            }
        }


        public FlashLightUIBar FlashLightUIBar
        {
            get
            {
                if (!_flashLightUIBar)
                    _flashLightUIBar = GetComponent<FlashLightUIBar>();
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
