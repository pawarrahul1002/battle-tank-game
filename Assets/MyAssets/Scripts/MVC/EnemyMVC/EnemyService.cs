using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public EnemyTankScriptableObject enemyTankScriptableObject;
        public List<Transform> enemyPos;
        private int count = 0;
        private float spwanTime = 5f;

        void Start()
        {
            count = 0;
            StartCoroutine(SpwanWaiting());
            count++;
        }


        void SpawningEnemy()
        {
            int num = Random.Range(0, enemyPos.Count);
            CreatEnemy(enemyPos[num]);
            enemyPos.RemoveAt(num);
        }

        private EnemyController CreatEnemy(Transform tranformPos)
        {
            EnemyView enemyView = enemyTankScriptableObject.enemyView;
            Vector3 pos = tranformPos.position;
            EnemyModel enemyModel = new EnemyModel(enemyTankScriptableObject);
            EnemyController enemy = new EnemyController(enemyModel, enemyView, pos);
            return enemy;
        }

        IEnumerator SpwanWaiting()
        {
            SpawningEnemy();
            yield return new WaitForSeconds(spwanTime);
            if (count >= 5)
            {
                StopCoroutine(SpwanWaiting());
            }
            else
            {
                StartCoroutine(SpwanWaiting());
            }
            count++;
        }
    }
}


















// public List<Transform> enemyPos;
// public EnemyTankScriptableObject enemyTankScriptableObject;
// // void GetEnemyList(EnemyTankScriptableObject enemySO)
// // {
// //     enemyPos = enemySO.enemyPos;
// // }

// void Start()
// {
//     creatNewEnemy();
// }

// private EnemyControlller creatNewEnemy()
// {
//     // int enemyNum = Random.Range(0, enemyPos.Count);
//     EnemyView enemyView = enemyTankScriptableObject.enemyView;
//     EnemyModel enemyModel = new EnemyModel(enemyTankScriptableObject);
//     EnemyControlller enemy = new EnemyControlller(enemyModel, enemyView);//, enemyPos[enemyNum]);
//     return enemy;
// }