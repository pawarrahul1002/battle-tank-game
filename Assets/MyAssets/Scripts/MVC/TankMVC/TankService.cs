using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankScriptableObjectList tankListSO;
        public TankScriptableObjects tankScriptableObjects { get; private set; }
        private Transform playerPos;

        public TankView tankView { get; private set; }

        int randomNo;
        // int 
        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            CreatNewTank();
        }

        private TankController CreatNewTank()
        {
            randomNo = Random.Range(0, tankListSO.tanks.Length);
            TankScriptableObjects tankScriptableObjects = tankListSO.tanks[randomNo];
            tankView = tankScriptableObjects.tankView;
            // playerPos = tankView.transform;
            TankModel tankModel = new TankModel(tankScriptableObjects);
            TankController tank = new TankController(tankModel, tankView);


            return tank;
        }

        public void PlayerPos()
        {
            Debug.Log(tankView.transform.position);
        }


    }
}

