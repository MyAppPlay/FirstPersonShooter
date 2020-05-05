namespace SecondAttempt
{
    public class Gun : Weapon
    {
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            var temAmmunition = Instantiate(Ammunitions, _barrel.position, _barrel.rotation);//todo Pool object
            temAmmunition.AddForse(_barrel.forward * _force);
            Clip.CountAmmunition--;
            _isReady = false;
            _timeRemaining.AddTimeRemaining();
        }
    }
}
