using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    //enemyservie deals with services, spwaning of enemy using controller and destroy service
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public EnemyTankScriptableObject enemyTankScriptableObject;
        public List<Transform> enemyPos;
        public List<EnemyController> enemyTanksList = new List<EnemyController>();
        private EnemyController enemyController;
        private int count = 0;
        private float spwanTime = 1f;//10f;

        async void Start()
        {
            count = enemyPos.Count;
            await new WaitForSeconds(5f);
            SpwanWaiting();
            SubEvent();
        }

        private void SubEvent()
        {
            EventService.GetInstance().OnEnemyKilled += UpdateEnemiesKilledCount;
        }

        private void UpdateEnemiesKilledCount()
        {
            TankService.GetInstance().GetCurrentTankModel().enemyKilled += 1;
            // PlayerPrefs.SetInt("EnemiesKilled", TankService.instance.GetCurrentTankModel().EnemiesKilled);
            // Debug.Log(TankService.instance.GetCurrentTankModel().EnemiesKilled);
            // UIService.instance.UpdateScoreText();
            AchievementServices.GetInstance().GetAchievementController().CheckForEnemyKilledAchievement();
        }





        public EnemyController GetEnemyTankController()
        {
            return enemyController;
        }


        void SpawningEnemy()
        {
            int num = Random.Range(0, enemyPos.Count);
            CreatEnemy(enemyPos[num]);
            enemyPos.RemoveAt(num);
        }

        private EnemyController CreatEnemy(Transform tranformPos)
        {
            EnemyView enemyView = enemyTankScriptableObject.enemyView;
            Vector3 pos = tranformPos.position;
            EnemyModel enemyModel = new EnemyModel(enemyTankScriptableObject);
            enemyController = new EnemyController(enemyModel, enemyView, pos);
            enemyTanksList.Add(enemyController);
            return enemyController;

        }

        async void SpwanWaiting()
        {
            // Debug.Log(enemyPos.Count);
            for (int i = 0; i < count; i++)
            {
                await new WaitForSeconds(spwanTime);
                SpawningEnemy();
                Debug.Log("Wait for 5 sec");

            }
        }

        public void UnsubscribeEvents()
        {
            Debug.Log("Unscub");
            EventService.GetInstance().OnEnemyKilled -= UpdateEnemiesKilledCount;
        }


        public void DestroyEnemyTank(EnemyController enemyController)
        {
            // UnsubscribeEvents();

            enemyController.DestroyEnemyController();
        }
    }
}


