using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    //EnemyTankScriptableObject is use for data of enemy in unity way
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

    }

    [CreateAssetMenu(fileName = "EnemyTankSO_List", menuName = "EnemyScriptableObjectList/EnemyTankListOfSO")]
    public class EnemyTankScriptableObjectList : ScriptableObject
    {
        public EnemyTankScriptableObject[] enemyTanks;
    }//class


}