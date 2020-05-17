namespace SecondAttempt
{
    public sealed class Gun : Weapon
    {
        public override void Fire()
        {
            if (!_isReady) return;
            var tempAmmunition = PoolManager.GetObject("Bullet", _barrel.position, _barrel.rotation);
            if (tempAmmunition != null)
            tempAmmunition.GetComponent<Ammunition>().AddForce(_barrel.forward * _force);
            Clip.CountAmmunition--;
            _isReady = false;
            _timeRemaining.AddTimeRemaining();
        }
    }
}