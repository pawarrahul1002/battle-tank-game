using System;

namespace BattleTank
{
    public class EventService : MonoSingletonGeneric<EventService>
    {
        public event Action OnPlayerFiredBullet;
        public event Action OnEnemyKilled;

        public void InvokeOnPlayerFiredBulletEvent()
        {
            OnPlayerFiredBullet?.Invoke();
        }
        public void InvokeEnemyKilledEvent()
        {
            OnEnemyKilled?.Invoke(); //Its same as below code

            // if (OnEnemyKilled == null)
            // {
            //     OnEnemyKilled.Invoke();
            // }
        }
    }
}