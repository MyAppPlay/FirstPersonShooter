using UnityEngine;
using UnityEngine.UI;


namespace SecondAttempt
{
    public sealed class FlashLightUiBar : MonoBehaviour
    {

        private Image _bar;


        public float Fill
        {
            set => _bar.fillAmount = value;
        }


        private void Awake()
        {
            _bar = GetComponent<Image>();
        }

        #region Methots

        public void SetActive(bool value)
        {
            _bar.gameObject.SetActive(value);
        }

        public void SetColor(Color col)
        {
            _bar.color = col;
        }

        #endregion
    }
}