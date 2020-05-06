using UnityEngine;


namespace SecondAttempt
{
    public static class CustumDebug
    {
        public static bool IsDebug;

        public static void Log(object value)
        {
            if (IsDebug)
            {
                Debug.Log(value);
            }
        }
    }
}
