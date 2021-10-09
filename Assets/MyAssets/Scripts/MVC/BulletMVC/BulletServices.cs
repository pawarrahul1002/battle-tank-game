using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{

    //this class is use for creating bullets. working on new it
    public class BulletServices : MonoSingletonGeneric<BulletServices>
    {
        public List<BulletController> bulletControllerList;

        void Start()
        {
            bulletControllerList = new List<BulletController>();

        }
        public void CreateBullet(Vector3 position, Quaternion rotation, BulletScriptableObjects type)
        {
            BulletScriptableObjects bullet = type;
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController bulletController = new BulletController(bullet.bulletView, bulletModel, position, rotation);
        }
        public void CreateBullet2(Vector3 position, Quaternion rotation, BulletScriptableObjects type)
        {
            BulletScriptableObjects bullet = type;
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController bulletController = new BulletController(bullet.bulletView, bulletModel, position, rotation);
            bulletControllerList.Add(bulletController);
        }

    }
}