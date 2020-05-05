using UnityEngine;
using System.Collections.Generic;


namespace SecondAttempt
{
    public sealed class TimeRemainingController : IExecute
    {
        private readonly List<ITimeRemaining> _timeRemainings;

        public TimeRemainingController()
        {
            _timeRemainings = TimeRermainingExtension.TimeRemainings;
        }

        public void Execute()
        {
            var time = Time.deltaTime;
            for(var i = 0; i < _timeRemainings.Count; i++)
            {
                var obj = _timeRemainings[i];
                obj.CurrentTime -= time;
                if (obj.CurrentTime <= 0.0f)
                {
                    obj?.Method?.Invoke();
                    if (obj.IsReapiting)
                    {
                        obj.RemoveTimeRemaining();
                    }
                    else
                        obj.CurrentTime = obj.Time;
                }
            }
        }
    }
}
