using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
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
            // await new WaitForSeconds(5f);
            // SpwanWaiting();
            // await Task.Delay(TimeSpan.FromSecond(1f));
            // await  SpawningEnemy();
            // SpawningEnemy();
            // StartCoroutine(SpwanWaiting());

            await new WaitForSeconds(5f);
            SpwanWaiting();
            // Debug.Log("5 sec");
            // count++;
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

        // void SpwanWaiting()
        // {
        //     SpawningEnemy();
        //     // yield return new WaitForSeconds(spwanTime);
        //     // if (count >= 3)
        //     // {
        //     //     // StopCoroutine(SpwanWaiting());
        //     // }
        //     // else
        //     // {
        //     //     // StartCoroutine(SpwanWaiting());
        //     // }
        //     // count++;
        // }

        // IEnumerator SpwanWaiting()
        // {
        //     SpawningEnemy();
        //     yield return new WaitForSeconds(spwanTime);
        //     if (count >= 3)
        //     {
        //         StopCoroutine(SpwanWaiting());
        //     }
        //     else
        //     {
        //         StartCoroutine(SpwanWaiting());
        //     }
        //     count++;
        // }

        // public void DestroyEnemyTank(EnemyController enemyController)
        // {
        //     enemyController.DestroyEnemyController();
        //     for (int i = 0; i < enemyTanksList.Count; i++)
        //     {
        //         if (enemyTanksList[i] != enemyController)
        //         {
        //             Debug.Log("1 ch vela bhau     " + enemyController);
        //             // enemyTanksList[i] = null;
        //             // enemyTanksList.Remove(enemyController);

        //             enemyTanksList[i].enemyView.gameObject.SetActive(false);
        //         }
        //     }
        // }
        public void DestroyEnemyTank(EnemyController enemyController)
        {

            enemyController.DestroyEnemyController();
            // for (int i = 0; i < enemyTanksList.Count; i++)
            // {

            //     if (enemyTanksList[i] == enemyController)
            //     {

            //         // enemyTanksList[i].enemyView.gameObject.SetActive(false);
            //         // enemyController.enemyModel = null;
            //         // Debug.Log(tank);
            //         enemyTanksList[i] = null;
            //         enemyTanksList.Remove(enemyController);
            //     }
            // }
        }
    }
}


















// public List<Transform> enemyPos;
// public EnemyTankScriptableObject enemyTankScriptableObject;
// // void GetEnemyList(EnemyTankScriptableObject enemySO)
// // {
// //     enemyPos = enemySO.enemyPos;
// // }

// void Start()
// {
//     creatNewEnemy();
// }

// private EnemyControlller creatNewEnemy()
// {
//     // int enemyNum = Random.Range(0, enemyPos.Count);
//     EnemyView enemyView = enemyTankScriptableObject.enemyView;
//     EnemyModel enemyModel = new EnemyModel(enemyTankScriptableObject);
//     EnemyControlller enemy = new EnemyControlller(enemyModel, enemyView);//, enemyPos[enemyNum]);
//     return enemy;
// }