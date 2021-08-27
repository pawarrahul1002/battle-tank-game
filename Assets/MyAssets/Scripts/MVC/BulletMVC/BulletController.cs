using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    //BulletController : this class controls bullet operations of instantiating and movement
    public class BulletController
    {
        public BulletView bulletView { get; private set; }
        public BulletModel bulletModel { get; private set; }
        private Rigidbody rigidbody;
        public BulletController(BulletView _bulletView, BulletModel _bulletModel, Vector3 position, Quaternion rotation)
        {
            bulletModel = _bulletModel;
            bulletView = GameObject.Instantiate<BulletView>(_bulletView, position, rotation);
            bulletView.SetBulletController(this);
            bulletModel.SetBulletController(this);
            rigidbody = bulletView.GetComponent<Rigidbody>();
        }

        public void Movement()
        {
            Vector3 move = bulletView.transform.position;
            move += bulletView.transform.forward * bulletModel.bulletForce * Time.fixedDeltaTime;
            rigidbody.MovePosition(move);
        }


    }
}