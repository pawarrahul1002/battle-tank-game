using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyPatrollingState : EnemyState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyView.activeState = EnemyStatesEnum.Patrolling;
        }
        private void Update()
        {
            enemyView.enemyController.Patrol();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }

}