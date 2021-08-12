using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        private List<Transform> enemyPos;
        public EnemyTankScriptableObject enemyTankScriptableObject;
        void GetEnemyList(EnemyTankScriptableObject enemySO)
        {
            enemyPos = enemySO.enemyPos;
        }

        void Start()
        {
            creatNewEnemy();
        }

        private EnemyControlller creatNewEnemy()
        {
            // int enemyNum = Random.Range(0, enemyPos.Count);
            EnemyView enemyView = enemyTankScriptableObject.enemyView;
            EnemyModel enemyModel = new EnemyModel(enemyTankScriptableObject);
            EnemyControlller enemy = new EnemyControlller(enemyModel, enemyView);//, enemyPos[enemyNum]);
            return enemy;
        }




    }
}