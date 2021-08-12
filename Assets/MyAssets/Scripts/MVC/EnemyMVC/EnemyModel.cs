using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyModel
    {
        private EnemyControlller enemyControlller;
        public BulletScriptableObjects bulletType { get; private set; }
        public float spwanTime { get; private set; }

        public EnemyModel(EnemyTankScriptableObject enmeySO)
        {
            spwanTime = enmeySO.spwanTime;
        }

        public void SetTankController(EnemyControlller _enemyControlller)
        {
            enemyControlller = _enemyControlller;
        }
    }
}