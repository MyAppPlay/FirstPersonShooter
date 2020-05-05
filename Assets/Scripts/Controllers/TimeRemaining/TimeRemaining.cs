using System;


namespace SecondAttempt
{
    public sealed class TimeRemaining : ITimeRemaining
    {
        public Action Method { get; }
        public bool IsReapiting { get; }

        public float Time { get; }

        public float CurrentTime { get; set; }

        public TimeRemaining(Action method,float time,bool isReapiting = false)
        {
            Method = method;
            Time = time;
            CurrentTime = time;
            IsReapiting = isReapiting;
        }
    } 
}
