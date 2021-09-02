using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class AchievementController
    {
        public AchievementModel achivementModel { get; private set; }
        private int currentStageOfBulletFiredAchievement;


        public AchievementController(AchievementModel achivementModel)
        {
            currentStageOfBulletFiredAchievement = 0;//PlayerPrefs.GetInt("BulletFireAchievement", 0);
            this.achivementModel = achivementModel;
        }


        public void CheckForBulletFiredAchievement()
        {
            for (int i = 0; i < achivementModel.bulletsFiredAchievementSO.setps.Length; i++)
            {
                if (i != currentStageOfBulletFiredAchievement)
                {
                    continue;
                }
                if (TankService.GetInstance().GetCurrentTankModel().bulletFired == achivementModel.bulletsFiredAchievementSO.setps[i].requirement)
                {
                    UnlockedAchievement(achivementModel.bulletsFiredAchievementSO.setps[i].bulletAchievementType);
                    currentStageOfBulletFiredAchievement = i + 1;
                    // PlayerPrefs.SetInt("BulletFireAchievement", currentStageOfBulletFiredAchievement);
                }
                break;
            }
        }

        void UnlockedAchievement(BulletAchievementType achievementType)
        {
            Debug.Log("Got :" + achievementType);
            UIManager.GetInstance().PopUpAchievement(achievementType);
        }
    }
}