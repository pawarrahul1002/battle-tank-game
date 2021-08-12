using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyControlller enemyControlller;


        // public Transform BulletShootPoint;

        // private float canFire = 0f;

        // private void ShootBullet()
        // {
        //     if (canFire < Time.time)
        //     {

        //     }
        // }

        public void SetTankController(EnemyControlller _enemyControlller)
        {
            enemyControlller = _enemyControlller;
        }
    }
}