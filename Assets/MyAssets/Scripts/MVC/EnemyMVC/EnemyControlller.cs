using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyControlller
    {
        public EnemyModel enemyModel { get; private set; }
        public EnemyView enemyView { get; private set; }

        public EnemyControlller(EnemyModel _enemyModel, EnemyView _enemyView)//, Transform _pos)
        {
            // Transform pos = _pos;
            enemyModel = _enemyModel;
            enemyView = GameObject.Instantiate<EnemyView>(enemyView);//, pos.position, Quaternion.identity);
            enemyView.SetTankController(this);
            enemyModel.SetTankController(this);
        }
    }
}