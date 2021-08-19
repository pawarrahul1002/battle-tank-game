using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{

    [CreateAssetMenu(fileName = "EnemyTankScriptableObjects", menuName = "EnemyScriptableObject/NewEnemy")]
    public class EnemyTankScriptableObject : ScriptableObject
    {
        [Header("MVC")]
        public EnemyView enemyView;
        public BoxCollider groundArea;

        [Header("Enemy Shooting")]
        public float fireRate;
        public BulletScriptableObjects bulletType;

        [Header("Enemy Health")]
        public float enemyHealth;
        // public List<Transform> enemyPos;
        // public float spwanTime = 5f;

    }

    [CreateAssetMenu(fileName = "EnemyTankSO_List", menuName = "EnemyScriptableObjectList/EnemyTankListOfSO")]
    public class EnemyTankScriptableObjectList : ScriptableObject
    {
        public EnemyTankScriptableObject[] enemyTanks;
    }//class


}