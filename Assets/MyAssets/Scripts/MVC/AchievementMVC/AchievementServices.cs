using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank
{
    public class AchievementServices : MonoSingletonGeneric<AchievementServices>
    {
        public BulletsFiredAchievementSO bulletsFiredSO;
        public EnemyKilledAchievementSO enemyKilledSO;
        private AchievementController achievementController;


        void Start()
        {
            CreatAchievement();
        }

        private void CreatAchievement()
        {
            AchievementModel achievementModel = new AchievementModel(bulletsFiredSO, enemyKilledSO);
            achievementController = new AchievementController(achievementModel);
        }

        public AchievementController GetAchievementController()
        {
            return achievementController;
        }
    }
}