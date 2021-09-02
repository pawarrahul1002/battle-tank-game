using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    /*enemyview attch to every enemy prefab and this is monobehaviour class
        control patrolling of enemy, working on it */
    public class EnemyView : MonoBehaviour
    {
        public ParticleSystem TankDestroyVFX;
        public NavMeshAgent enemyNavMesh;
        public EnemyController enemyController;
        private BoxCollider ground;
        public float maxX, maxZ, minX, minZ;
        public float timer, patrolTime;
        public float howClose;
        public float canFire = 0f;
        public Transform BulletShootPoint;
        public Transform playerTransform;
        public MeshRenderer[] childs;

        public EnemyPatrollingState patrollingState;
        public EnemyChasingState chasingState;
        public EnemyAttackingState attackingState;

        public EnemyStatesEnum initialState;
        public EnemyStatesEnum activeState;
        public EnemyState currentState;

        void Awake()
        {
            enemyNavMesh = gameObject.GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            currentState = patrollingState;
            InitializeState();
            SetGroundForEnemyPatrolling();
            setPlayerTransform();
            timer = 5f;
            patrolTime = 2f;
            howClose = 15f;
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
            enemyController.EnemyPatrollingAI();
        }


        private void InitializeState()
        {
            switch (initialState)
            {

                case EnemyStatesEnum.Attacking:
                    currentState = attackingState;
                    break;

                case EnemyStatesEnum.Chasing:
                    currentState = chasingState;
                    break;

                case EnemyStatesEnum.Patrolling:
                    currentState = patrollingState;
                    break;

                default:
                    currentState = null;
                    break;
            }
            currentState.OnStateEnter();
        }

        // public Vector3 GetRandomPosition()
        // {
        //     float x = Random.Range(minX, maxX);
        //     float z = Random.Range(minZ, maxZ);
        //     Vector3 randDir = new Vector3(x, 0, z);
        //     return randDir;
        // }


        // private void EnemyPatrollingAI()
        // {
        //     if (playerTransform != null)
        //     {
        //         float distance = Vector3.Distance(playerTransform.position, transform.position);
        //         if (distance <= howClose)
        //         {
        //             ChaseToPlayer();
        //         }
        //         else
        //         {
        //             Patrol();
        //         }
        //     }
        //     else
        //     {
        //         Patrol();
        //     }
        // }

        // private void ChaseToPlayer()
        // {
        //     transform.LookAt(playerTransform);
        //     enemyNavMesh.SetDestination(playerTransform.position);
        //     ShootBullet();
        // }

        // public Vector3 GetRandomPosition()
        // {
        //     float x = Random.Range(minX, maxX);
        //     float z = Random.Range(minZ, maxZ);
        //     Vector3 randDir = new Vector3(x, 0, z);
        //     return randDir;
        // }

        // private void SetPatrolingDestination()
        // {
        //     Vector3 newDestination = GetRandomPosition();
        //     enemyNavMesh.SetDestination(newDestination);
        // }

        // public void Patrol()
        // {
        //     timer += Time.deltaTime;
        //     if (timer > patrolTime)
        //     {
        //         SetPatrolingDestination();
        //         timer = 0;
        //     }
        // }

        // private void ShootBullet()
        // {
        //     if (canFire < Time.time)
        //     {
        //         canFire = enemyController.enemyModel.fireRate + Time.time;
        //         enemyController.ShootBullet();
        //     }
        // }

        public void DestroyView()
        {
            // Debug.Log("Destroy Enemy View called");
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i] = null;
            }

            BulletShootPoint = null;
            enemyNavMesh = null;
            ground = null;
            playerTransform = null;
            TankDestroyVFX.transform.parent = null;
            TankDestroyVFX.Play();
            Destroy(TankDestroyVFX.gameObject, TankDestroyVFX.main.duration + 1f);
            Destroy(this.gameObject);
        }



    }
}