using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankScriptableObjectList tankListSO;
        public TankScriptableObjects tankScriptableObjects { get; private set; }
        private List<TankController> tanks = new List<TankController>();
        public Transform position;
        public TankView tankView { get; private set; }
        int randomNo;

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
            TankModel tankModel = new TankModel(tankScriptableObjects);
            TankController tank = new TankController(tankModel, tankView);
            tanks.Add(tank);
            return tank;
        }


        public void GetPlayerPos(Transform _position)
        {
            position = _position;

            // Debug.Log("position  " + position);
        }

        public Transform PlayerPos()
        {
            return position;
        }

        public void DestroyTank(TankController tank)
        {
            tank.DestroyController();
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] == tank)
                {
                    tanks[i] = null;
                    tanks.Remove(tank);
                }
            }
        }


    }
}

