using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyController
    {
        public EnemyModel enemyModel { get; private set; }
        public EnemyView enemyView { get; private set; }

        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView, Vector3 pos)
        {
            enemyModel = _enemyModel;
            enemyView = GameObject.Instantiate<EnemyView>(_enemyView, pos, Quaternion.identity);
            enemyView.SetEnemyTankController(this);
            enemyModel.SetEnemyTankController(this);
        }

        public void ShootBullet()
        {
            BulletServices.GetInstance().CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        public Vector3 GetFiringPosition()
        {
            return enemyView.BulletShootPoint.position;
        }
        public Quaternion GetFiringAngle()
        {
            return enemyView.transform.rotation;
        }
        public BulletScriptableObjects GetBullet()
        {
            return enemyModel.bulletType;
        }

    }
}