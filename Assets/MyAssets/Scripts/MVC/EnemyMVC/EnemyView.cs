using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public class EnemyView : MonoBehaviour
    {
        private NavMeshAgent enemyNavMesh;
        public EnemyController enemyController;
        private BoxCollider ground;
        private float maxX, maxZ, minX, minZ;
        private float timer, patrolTime;
        public float howClose;
        private float canFire = 0f;
        public Transform BulletShootPoint;
        private Transform playerTransform;
        public MeshRenderer[] childs;
        void Awake()
        {
            enemyNavMesh = gameObject.GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            SetGroundForEnemyPatrolling();
            setPlayerTransform();
            timer = 5f;
            patrolTime = 5f;
            howClose = 13f;
            Invoke("Patrol", 1f);
        }

        public void SetEnemyTankController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }

        private void setPlayerTransform()
        {
            playerTransform = TankService.GetInstance().PlayerPos();
        }

        private void SetGroundForEnemyPatrolling()
        {
            ground = GroundBoxCollider.groundboxCollider; ;
            maxX = ground.bounds.max.x;
            maxZ = ground.bounds.max.z;
            minX = ground.bounds.min.x;
            minZ = ground.bounds.min.z;
        }

        void Update()
        {
            EnemyPatrollingAI();
        }

        private void EnemyPatrollingAI()
        {
            if (playerTransform != null)
            {
                float distance = Vector3.Distance(playerTransform.position, transform.position);
                if (distance <= howClose)
                {
                    EnemyCloseToPlayer();
                }
                else
                {
                    Patrol();
                }
            }
            else
            {
                Patrol();
            }
        }

        private void EnemyCloseToPlayer()
        {
            transform.LookAt(playerTransform);
            enemyNavMesh.SetDestination(playerTransform.position);
            ShootBullet();
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

        public void DestroyView()
        {
            Debug.Log("Destroy Enemy View called");
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i] = null;
            }
            // tankController = null;
            BulletShootPoint = null;
            enemyNavMesh = null;
            ground = null;
            playerTransform = null;
            // TankDestroyVFX = null;
            Destroy(this.gameObject);
        }

    }
}