using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    //this is enemycontroller, intialized enemy also controls enemy behaviour
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

        public Vector3 GetRandomPosition()
        {
            float x = Random.Range(enemyView.minX, enemyView.maxX);
            float z = Random.Range(enemyView.minZ, enemyView.maxZ);
            Vector3 randDir = new Vector3(x, 0, z);
            return randDir;
        }

        private void SetPatrolingDestination()
        {
            Vector3 newDestination = GetRandomPosition();
            enemyView.enemyNavMesh.SetDestination(newDestination);
        }

        public void Patrol()
        {
            enemyView.timer += Time.deltaTime;
            if (enemyView.timer > enemyView.patrolTime)
            {
                SetPatrolingDestination();
                enemyView.timer = 0;
            }
        }

        public void EnemyPatrollingAI()
        {
            if (enemyView.playerTransform != null)
            {
                float distance = Vector3.Distance(enemyView.playerTransform.position, enemyView.transform.position);
                if (distance <= enemyView.howClose)
                {
                    enemyView.currentState.ChangeState(enemyView.chasingState);
                }
                else
                {
                    enemyView.currentState.ChangeState(enemyView.patrollingState);
                }
            }
            else
            {
                enemyView.currentState.ChangeState(enemyView.patrollingState);
            }
        }

        public void ChaseToPlayer()
        {
            enemyView.transform.LookAt(enemyView.playerTransform);
            enemyView.enemyNavMesh.SetDestination(enemyView.playerTransform.position);
            ShootBullet();
        }

        private void ShootBullet()
        {
            if (enemyView.canFire < Time.time)
            {
                enemyView.canFire = enemyModel.fireRate + Time.time;
                CreatingBullet();
            }
        }

        public void CreatingBullet()
        {
            BulletServices.GetInstance().CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        public void DeadEnemy()
        {
            EventService.GetInstance().InvokeEnemyKilledEvent();
            EnemyService.GetInstance().DestroyEnemyTank(this);
        }

        public void ApplyDamage(float damage)
        {
            enemyModel.enemyHealth -= damage;
            Debug.Log("Enemy Health : " + enemyModel.enemyHealth);

            if (enemyModel.enemyHealth <= 0)
            {
                Debug.Log("Dead called");
                DeadEnemy();
            }
        }

        public void DestroyEnemyController()
        {
            enemyModel.DestroyModel();
            enemyView.DestroyView();
            enemyModel = null;
            enemyView = null;
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