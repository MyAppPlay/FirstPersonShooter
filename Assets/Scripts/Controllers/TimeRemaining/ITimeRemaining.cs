using System;


namespace SecondAttempt
{
    public interface ITimeRemaining
    {
        Action Method { get; }

        bool IsReapiting { get; }

        float Time { get; }

        float CurrentTime { get; set; }
    } 
}
