using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyControlller
    {
        public EnemyModel enemyModel { get; private set; }
        public EnemyView enemyView { get; private set; }
        // public TankView tankView { get; private set; }


        public EnemyControlller(EnemyModel _enemyModel, EnemyView _enemyView, Vector3 pos)
        {
            this.enemyModel = _enemyModel;
            this.enemyView = GameObject.Instantiate<EnemyView>(_enemyView, pos, Quaternion.identity);
            enemyView.SetEnemyTankController(this);
            enemyModel.SetEnemyTankController(this);
        }

        // public EnemyControlller(TankView _tankView)
        // {
        //     tankView = _tankView;
        //     Debug.Log(tankView.transform.position);
        // }

        // public void PlayerPos()
        // {
        //     // Debug.Log(tankController);

        //     Debug.Log(tankView.transform);
        //     // Debug.Log(enemyView.transform.position);
        // }




    }
}