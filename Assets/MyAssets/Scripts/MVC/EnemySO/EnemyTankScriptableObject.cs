using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{

    [CreateAssetMenu(fileName = "EnemyTankScriptableObjects", menuName = "EnemyScriptableObject/NewEnemy")]
    public class EnemyTankScriptableObject : ScriptableObject
    {
        [Header("MVC Essentials")]
        public EnemyView enemyView;
        public List<Transform> enemyPos;
        public float spwanTime = 5f;

    }
}