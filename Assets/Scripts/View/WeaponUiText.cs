using UnityEngine;
using UnityEngine.UI;


namespace SecondAttempt
{
	public sealed class WeaponUiText : MonoBehaviour
	{
		private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

        #region Methods

        public void ShowData(int countAmmunition, int countClip)
        {
            _text.text = $"{countAmmunition}/{countClip}";
        }

        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }

        #endregion
    }
}