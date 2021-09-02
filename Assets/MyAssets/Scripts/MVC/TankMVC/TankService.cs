using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank
{
    /*tankservice is attcted to gameobject in hirerarcy and handle
         generating of player and destroy of player and action after die*/
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankScriptableObjectList tankListSO;

        public TankScriptableObjects tankScriptableObjects { get; private set; }
        private TankModel currentTankmodel;
        public GameObject destroyGround;
        private List<TankController> tanks = new List<TankController>();
        public Transform position;
        public TankView tankView { get; private set; }
        private TankController tankController;
        private List<EnemyController> enemyControllers;
        private int randomNo;

        private void Start()
        {
            CreatNewTank();
        }

        private TankController CreatNewTank()
        {
            randomNo = Random.Range(0, tankListSO.tanks.Length);
            TankScriptableObjects tankScriptableObjects = tankListSO.tanks[randomNo];
            tankView = tankScriptableObjects.tankView;
            TankModel tankModel = new TankModel(tankScriptableObjects);
            currentTankmodel = tankModel;
            tankController = new TankController(tankModel, tankView);
            tanks.Add(tankController);
            return tankController;
        }

        public TankModel GetCurrentTankModel()
        {
            return currentTankmodel;
        }

        public TankController GetTankController()
        {
            return tankController;
        }

        public void GetPlayerPos(Transform _position)
        {
            position = _position;
        }

        public Transform PlayerPos()
        {
            return position;
        }

        public void DestroyTank(TankController tank)
        {
            DestroyAllEnemies();

            tank.DestroyController();
            // EnemyService.GetInstance().DestroyEnemyTank();
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] == tank)
                {
                    tanks[i] = null;
                    tanks.Remove(tank);
                }
            }

            // DestroyGround.instance.DestroyMilitary();
        }

        async void DestroyAllEnemies()
        {
            enemyControllers = EnemyService.GetInstance().enemyTanksList;

            for (int i = 0; i < enemyControllers.Count; i++)
            {
                if (EnemyService.GetInstance().enemyTanksList[i].enemyView != null)
                {
                    await new WaitForSeconds(2f);
                    enemyControllers[i].DeadEnemy();
                }
            }

        }
    }
}

