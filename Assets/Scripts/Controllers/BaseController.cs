namespace SecondAttempt
{
    public abstract class BaseController
    {
        protected UIInterface UIInterface;

        protected BaseController()
        {
            UIInterface = new UIInterface();
        }

        public bool IsActive { get; private set; }



        public virtual void On()
        {
            On(null);
        }

        public virtual void On(params BaseObjectInScene[] obj)
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch()
        {
            if (!IsActive) On();
            else Off();
        }
    }
}
