using System;
using UnityEngine;


namespace BattleTank
{

    [CreateAssetMenu(menuName = "BulletFireAchievenetSO", fileName = "ScriptableObject/NewfireBulletSO")]
    public class BulletsFiredAchievementSO : ScriptableObject
    {
        public BulletAchievement[] setps;

        [Serializable]
        public class BulletAchievement
        {
            public BulletAchievementType bulletAchievementType;
            public int requirement;
        }


    }
    public enum BulletAchievementType
    {
        None,
        AchievementA,
        AchievementB,
        AchievementC
    }
}
