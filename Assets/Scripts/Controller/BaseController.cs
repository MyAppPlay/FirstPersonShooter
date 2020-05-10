namespace SecondAttempt
{
    public abstract class BaseController
    {
        protected UiInterface UiInterface;

        #region Methods

        protected BaseController()
        {
            UiInterface = new UiInterface();
        }

        public bool IsActive { get; private set; }

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(params BaseObjectScene[] obj)
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch(params BaseObjectScene[] obj)
        {
            if (!IsActive)
            {
                On(obj);
            }
            else
            {
                Off();
            }
        }

        #endregion
    }

    public abstract class CopyOfBaseController
    {
        protected UiInterface UiInterface;

        #region Methods

        protected CopyOfBaseController()
        {
            UiInterface = new UiInterface();
        }

        public bool IsActive { get; private set; }

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(params BaseObjectScene[] obj)
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch(params BaseObjectScene[] obj)
        {
            if (!IsActive)
            {
                On(obj);
            }
            else
            {
                Off();
            }
        }

        #endregion
    }

    public abstract class Copy1OfCopyOfBaseController
    {
        protected UiInterface UiInterface;

        #region Methods

        protected Copy1OfCopyOfBaseController()
        {
            UiInterface = new UiInterface();
        }

        public bool IsActive { get; private set; }

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(params BaseObjectScene[] obj)
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch(params BaseObjectScene[] obj)
        {
            if (!IsActive)
            {
                On(obj);
            }
            else
            {
                Off();
            }
        }

        #endregion
    }

    public abstract class CopyOfCopyOfBaseController
    {
        protected UiInterface UiInterface;

        #region Methods

        protected CopyOfCopyOfBaseController()
        {
            UiInterface = new UiInterface();
        }

        public bool IsActive { get; private set; }

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(params BaseObjectScene[] obj)
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch(params BaseObjectScene[] obj)
        {
            if (!IsActive)
            {
                On(obj);
            }
            else
            {
                Off();
            }
        }

        #endregion
    }
}
