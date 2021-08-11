using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }

        public GameObject BullectDestroyVFX;
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }


        private void FixedUpdate()
        {
            bulletController.Movement();
        }





    }
}