﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyModel
    {
        private EnemyController enemyController;
        public float enemyHealth { get; set; }
        public float fireRate { get; private set; }
        public BulletScriptableObjects bulletType { get; private set; }
        public BoxCollider groundArea;

        public EnemyModel(EnemyTankScriptableObject enemySO)
        {
            Debug.Log("Enemy model created");
            enemyHealth = enemySO.enemyHealth;
            groundArea = enemySO.groundArea;
            fireRate = enemySO.fireRate;
            bulletType = enemySO.bulletType;
        }

        public void SetEnemyTankController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }

        public void DestroyModel()
        {

            Debug.Log("Destroy Enemy model called");
            // material = null;
            bulletType = null;
            enemyController = null;
        }
    }
}