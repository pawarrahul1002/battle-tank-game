using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank
{
    public class AchievementModel
    {
        public BulletsFiredAchievementSO bulletsFiredAchievementSO { get; private set; }
        public AchievementModel(BulletsFiredAchievementSO bulletsFiredSO)
        {
            this.bulletsFiredAchievementSO = bulletsFiredSO;
        }
    }
}