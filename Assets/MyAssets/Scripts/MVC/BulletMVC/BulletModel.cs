using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    //this class is help in assigning behavious to bullet
    public class BulletModel
    {

        public float bulletForce { get; private set; }
        public float damage { get; private set; }
        public BulletTypes type;
        private BulletController bulletController;
        public BulletModel(BulletScriptableObjects bulletSO)
        {

            bulletForce = bulletSO.bulletForce;
            damage = bulletSO.bulletDamage;
            type = bulletSO.bulletTypes;
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
    }
}