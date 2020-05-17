namespace SecondAttempt
{
    public sealed class Gun : Weapon
    {
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            var temAmmunition = PoolManager.GetObject("Bullet", transform.position, transform.rotation);
            temAmmunition.GetComponent<Ammunition>().AddForce(_barrel.forward * _force);
            Clip.CountAmmunition--;
            _isReady = false;
            _timeRemaining.AddTimeRemaining();
        }
    }
}