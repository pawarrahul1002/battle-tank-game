using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public class EnemyView : MonoBehaviour
    {
        private NavMeshAgent enemyNavMesh;
        private EnemyControlller enemyControlller;
        private BoxCollider ground;
        private float maxX, maxZ, minX, minZ;
        private float timer, patrolTime;
        public float howClose;
        // private TankController tankController;
        // public void SetTankController(TankController _tankController)
        // {
        //     tankController = _tankController;
        // }
        // Vector3 playerPos;
        // private TankView tankView;


        public void SetEnemyTankController(EnemyControlller _enemyControlller)
        {
            enemyControlller = _enemyControlller;
        }


        void Awake()
        {
            // tankView = GetComponent<TankView>();
            enemyNavMesh = gameObject.GetComponent<NavMeshAgent>();
            // Debug.Log(enemyNavMesh);
        }

        void Start()
        {
            ground = GroundBoxCollider.groundboxCollider; ;
            maxX = ground.bounds.max.x;
            maxZ = ground.bounds.max.z;
            minX = ground.bounds.min.x;
            minZ = ground.bounds.min.z;
            timer = 0;
            patrolTime = 5f;
            howClose = 10f;
            Invoke("Patrol", 1f);
        }

        void Update()
        {
            // TankController.GetInstance().GetCurrentTankPosition();
            // float distance = Vector3.Distance(TankService.GetInstance().PlayerPos().position, transform.position);
            // if (distance <= howClose)
            // {
            //     transform.LookAt();
            //     enemy.SetDestination(player.position);
            //     Shoot();
            // }
            // else
            // {

            // tankController.PlayerPos();
            Patrol();
            // }
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



    }
}