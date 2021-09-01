using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    public class EnemyChasingState : EnemyState
    {

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyView.activeState = EnemyStatesEnum.Chasing;
            enemyView.enemyController.ChaseToPlayer();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

    }
}