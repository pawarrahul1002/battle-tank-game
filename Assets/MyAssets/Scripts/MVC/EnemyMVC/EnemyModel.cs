using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyModel
    {
        private EnemyControlller enemyControlller;
        public float enemyHealth { get; set; }

        public BoxCollider groundArea;

        public EnemyModel(EnemyTankScriptableObject enemySO)
        {
            enemyHealth = enemySO.enemyHealth;
            groundArea = enemySO.groundArea;
        }

        public void SetEnemyTankController(EnemyControlller _enemyControlller)
        {
            enemyControlller = _enemyControlller;
        }
    }
}