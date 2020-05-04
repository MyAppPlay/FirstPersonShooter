using UnityEngine;
using UnityEngine.UI;


namespace SecondAttempt
{
    public class FlashLightUIText : MonoBehaviour
    {
        private Text _infoBattery;
        private Image _infoBattaryFill;

        public float Text { set => _infoBattery.text = $"{value:0.0}"; }
        public float Fill { set => _infoBattaryFill.fillAmount = value;  }

        private void Awake()
        {
            _infoBattery = GetComponent<Text>();
            _infoBattaryFill = GetComponentInParent<Image>();
        }

        public void SetActive(bool value)
        {
            _infoBattery.gameObject.SetActive(value);
        }
    }
}