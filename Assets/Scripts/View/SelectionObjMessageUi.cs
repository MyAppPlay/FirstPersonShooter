using UnityEngine;
using UnityEngine.UI;


namespace SecondAttempt
{
	public sealed  class SelectionObjMessageUi : MonoBehaviour
	{
		private Text _text;

		public string Text
		{
			set => _text.text = $"{value}";
		}

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		public void SetActive(bool value)
		{
			_text.gameObject.SetActive(value);
		}
	}
}