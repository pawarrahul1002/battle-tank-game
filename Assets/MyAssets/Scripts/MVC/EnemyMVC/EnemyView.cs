using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public class EnemyView : MonoBehaviour
    {
        private NavMeshAgent enemyNavMesh;
        private EnemyController enemyController;
        private BoxCollider ground;
        private float maxX, maxZ, minX, minZ;
        private float timer, patrolTime;
        public float howClose;
        private float canFire = 0f;
        public Transform BulletShootPoint;
        private Transform playerTransform;
        void Awake()
        {
            enemyNavMesh = gameObject.GetComponent<NavMeshAgent>();
        }

        public void SetEnemyTankController(EnemyController _enemyController)
        {
            enemyController = _enemyController;

            // Debug.Log(enemyController);
        }

        private void setPlayerTransform()
        {
            playerTransform = TankService.GetInstance().PlayerPos();
        }


        void Start()
        {
            ground = GroundBoxCollider.groundboxCollider; ;
            maxX = ground.bounds.max.x;
            maxZ = ground.bounds.max.z;
            minX = ground.bounds.min.x;
            minZ = ground.bounds.min.z;
            timer = 5f;
            patrolTime = 5f;
            howClose = 13f;
            Invoke("Patrol", 1f);
        }

        void Update()
        {
            EnemyPatrollingAI();
        }

        private void EnemyPatrollingAI()
        {
            float distance = Vector3.Distance(TankService.GetInstance().PlayerPos().position, transform.position);
            if (distance <= howClose)
            {
                transform.LookAt(TankService.GetInstance().PlayerPos());
                enemyNavMesh.SetDestination(TankService.GetInstance().PlayerPos().position);
                ShootBullet();
            }
            else
            {
                Patrol();
            }

        }


        public Vector3 GetRandomPosition()
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            Vector3 randDir = new Vector3(x, 0, z);
            return randDir;
        }

        private void SetPatrolingDestination()
        {
            Vector3 newDestination = GetRandomPosition();
            enemyNavMesh.SetDestination(newDestination);
        }

        public void Patrol()
        {
            timer += Time.deltaTime;
            if (timer > patrolTime)
            {
                SetPatrolingDestination();
                timer = 0;
            }
        }

        private void ShootBullet()
        {
            if (canFire < Time.time)
            {
                canFire = enemyController.enemyModel.fireRate + Time.time;
                enemyController.ShootBullet();
            }
        }



    }
}