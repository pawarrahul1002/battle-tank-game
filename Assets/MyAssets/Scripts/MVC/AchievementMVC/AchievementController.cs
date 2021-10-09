using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class AchievementController
    {
        public AchievementModel achivementModel { get; private set; }
        private int currentStageOfBulletFiredAchievement;
        private int currentStageOfEnemyKilledAchievement;


        public AchievementController(AchievementModel achivementModel)
        {
            currentStageOfBulletFiredAchievement = 0;//PlayerPrefs.GetInt("BulletFireAchievement", 0);
            currentStageOfEnemyKilledAchievement = 0;
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
                    string achievement = achivementModel.bulletsFiredAchievementSO.setps[i].bulletAchievementType.ToString();
                    UnlockedAchievement(achievement);
                    currentStageOfBulletFiredAchievement = i + 1;
                    // PlayerPrefs.SetInt("BulletFireAchievement", currentStageOfBulletFiredAchievement);
                }
                break;
            }
        }


        public void CheckForEnemyKilledAchievement()
        {
            for (int i = 0; i < achivementModel.enemyKilledAchievementSO.steps.Length; i++)
            {
                if (i != currentStageOfEnemyKilledAchievement)
                {
                    continue;
                }
                if (TankService.GetInstance().GetCurrentTankModel().enemyKilled == achivementModel.enemyKilledAchievementSO.steps[i].requirement)
                {
                    string achievement = (achivementModel.enemyKilledAchievementSO.steps[i].EnemyKilledAchievementType).ToString();
                    UnlockedAchievement(achievement);
                    currentStageOfEnemyKilledAchievement = i + 1;
                    // PlayerPrefs.SetInt("BulletFireAchievement", currentStageOfBulletFiredAchievement);
                }
                break;
            }
        }


        void UnlockedAchievement(string achievement)
        {
            Debug.Log("Got :" + achievement);
            UIManager.GetInstance().PopUpAchievement(achievement);
        }

    }

}