using UnityEngine;
using UnityEngine.UI;


namespace SecondAttempt
{
    public sealed class AimUiText : MonoBehaviour
    {
        #region Fields

        private int _countPoint;

        private Aim[] _aims;
        private Text _text;

        #endregion


        private void Awake()
        {
            _aims = FindObjectsOfType<Aim>();
            _text = GetComponent<Text>();
        }

        #region Methods

        private void OnEnable()
        {
            foreach (var aim in _aims)
            {
                aim.OnPointChange += UpdatePoint;
            }
        }

        private void OnDisable()
        {
            foreach (var aim in _aims)
            {
                aim.OnPointChange -= UpdatePoint;
            }
        }

        private void UpdatePoint()
        {
            var pointTxt = "очков";
            ++_countPoint;
            if (_countPoint >= 5) pointTxt = "очков";
            else if (_countPoint == 1) pointTxt = "очко";
            else if (_countPoint < 5) pointTxt = "очка";
            _text.text = $"Вы заработали {_countPoint} {pointTxt}";

            //todo отписаться удалить и списка
        }

        #endregion
    }
}
