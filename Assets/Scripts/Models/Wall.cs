namespace SecondAttempt
{
    public sealed class Wall : BaseObjectInScene, ISelectObject
    {
        public string GetMessage()
        {
            return name; //закешировать
        }
    } 
}
