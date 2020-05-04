namespace SecondAttempt
{
    public sealed class Wall : BaseObjectScene, ISelectObject
    {
        public string GetMessage()
        {
            return name; //закешировать
        }
    } 
}
