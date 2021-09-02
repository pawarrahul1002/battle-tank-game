using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank
{
    public class AchievementServices : MonoSingletonGeneric<AchievementServices>
    {
        public BulletsFiredAchievementSO bulletsFiredSO;
        private AchievementController achievementController;


        void Start()
        {
            CreatAchievement();
        }

        private void CreatAchievement()
        {
            AchievementModel achievementModel = new AchievementModel(bulletsFiredSO);
            achievementController = new AchievementController(achievementModel);
        }

        public AchievementController GetAchievementController()
        {
            return achievementController;
        }
    }
}