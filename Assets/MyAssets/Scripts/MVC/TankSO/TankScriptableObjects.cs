using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    /*tankscriptable objets store all data related to player tank */

    [CreateAssetMenu(fileName = "TankScriptableObjects", menuName = "ScriptableObject/NewTank")]
    public class TankScriptableObjects : ScriptableObject
    {
        [Header("Tank Type Specific")]
        public TankType tankType;

        [Header("MVC Essentials")]
        public TankView tankView;

        [Header("Tank Movement Variables")]
        public float movementSpeed;
        public float rotationSpeed;

        [Header("Tank Health Variables")]
        public float health;

        [Header("Tank Shooting Variables")]
        public float fireRate;
        public BulletScriptableObjects bulletType;

    }//class

    [CreateAssetMenu(fileName = "TankSO_List", menuName = "ScriptableObjectList/TankListOfSO")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObjects[] tanks;
    }//class

}