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
        public float enemyHealth;
        public BoxCollider groundArea;
        // public List<Transform> enemyPos;
        // public float spwanTime = 5f;

    }
    [CreateAssetMenu(fileName = "EnemyTankSO_List", menuName = "EnemyScriptableObjectList/EnemyTankListOfSO")]
    public class EnemyTankScriptableObjectList : ScriptableObject
    {
        public EnemyTankScriptableObject[] enemyTanks;
    }//class


}