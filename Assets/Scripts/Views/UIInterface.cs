using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SecondAttempt
{
    public class UIInterface : MonoBehaviour
    {
        static public Text SelectionObjectMessageUI;

        static public string Text()
        {
            return SelectionObjectMessageUI.text;
        }

        static public string GetMessage()
        {
            return SelectionObjectMessageUI.name;
        }
    } 
}
