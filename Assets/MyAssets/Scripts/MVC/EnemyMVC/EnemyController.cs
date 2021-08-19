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

        public void DeadEnemy()
        {
            EnemyService.GetInstance().DestroyEnemyTank(this);
        }

        public void ApplyDamage(float damage)
        {
            enemyModel.enemyHealth -= damage;
            // UIService.instance.UpdateHealthText(tankModel.health);
            Debug.Log("Enemy Health : " + enemyModel.enemyHealth);

            if (enemyModel.enemyHealth <= 0)
            {
                Debug.Log("Dead called");
                DeadEnemy();
            }
        }


        public void DestroyEnemyController()
        {
            // GameService.instance.CheckForHighScore();
            // SFXService.instance.PlaySoundAtTrack1(tankView.TankDestroySFX, 1f, 10, true);
            // VFXService.instance.InstantiateEffects(tankView.TankDestroyVFX, tankView.transform.position);
            // UIService.instance.ResetScore();
            enemyModel.DestroyModel();
            enemyView.DestroyView();
            enemyModel = null;
            enemyView = null;
            // rb = null;
            // UnSubscribeEvents();
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