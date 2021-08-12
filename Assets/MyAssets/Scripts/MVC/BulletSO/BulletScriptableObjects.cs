using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{

    [CreateAssetMenu(fileName = "BulletScriptableObjects", menuName = "ScriptableObject/NewBullet")]
    public class BulletScriptableObjects : ScriptableObject
    {
        [Header("MVC Essentials")]
        public BulletView bulletView;

        [Header("Behaviour Variables")]
        public BulletTypes bulletTypes;
        public float bulletForce;
        public float bulletDamage;
    }

    [CreateAssetMenu(fileName = "BulletSO_List", menuName = "ScriptableObjectList/BulletListOfSO")]
    public class BulletSO_List : ScriptableObject
    {
        public BulletScriptableObjects[] bullets;
    }

}
