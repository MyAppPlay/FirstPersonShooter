using System;


namespace SecondAttempt
{
    public sealed class TimeRemaining : ITimeRemaining
    {
        #region ITimeRemaining
        
        public bool IsRepeating { get; }
        public float Time { get; }
        public float CurrentTime { get; set; }
        public Action Method { get; }
        
        #endregion

        
        #region ClassLifeCycles

        public TimeRemaining(Action method, float time, bool isRepeating = false)
        {
            Method = method;
            Time = time;
            CurrentTime = time;
            IsRepeating = isRepeating;
        }
        
        #endregion
    }
}
