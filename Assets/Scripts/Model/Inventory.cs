﻿using UnityEngine;


namespace SecondAttempt
{
	public sealed class Inventory : IInitialization
	{
		private Weapon[] _weapons = new Weapon[5];

        #region Property

        public Weapon[] Weapons => _weapons;

        public FlashLightModel FlashLight { get; private set; }

        #endregion


        #region Methods

        public void Initialization()
        {
            _weapons = ServiceLocatorMonoBehaviour.GetService<CharacterController>().
                GetComponentsInChildren<Weapon>();

            foreach (var weapon in Weapons)
            {
                weapon.IsVisible = false;
            }

            FlashLight = Object.FindObjectOfType<FlashLightModel>();
            FlashLight.Switch(FlashLightActiveType.Off);
        }

        //todo Добавить функционал

        public void RemoveWeapon(Weapon weapon)
        {

        }

        #endregion
    }
}