using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class BulletServices : MonoSingletonGeneric<BulletServices>
    {
        public void CreateBullet(Vector3 position, Quaternion rotation, BulletScriptableObjects type)
        {
            BulletScriptableObjects bullet = type;
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController bulletController = new BulletController(bullet.bulletView, bulletModel, position, rotation);
        }

        // public void DestroyingBullet()
        // {
        //     void OnTriggerEnter(Collider other)
        //     {

        //         BullectDestroyVFX.transform.parent = null;
        //         BullectDestroyVFX.Play();

        //         Destroy(BullectDestroyVFX.gameObject, BullectDestroyVFX.main.duration);
        //         Destroy(gameObject);
        //     }
        // }
    }


}