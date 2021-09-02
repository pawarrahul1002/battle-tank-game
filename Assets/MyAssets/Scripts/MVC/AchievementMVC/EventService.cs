using System;

namespace BattleTank
{
    public class EventService : MonoSingletonGeneric<EventService>
    {
        public event Action OnPlayerFiredBullet;

        public void InvokeOnPlayerFiredBulletEvent()
        {
            OnPlayerFiredBullet?.Invoke();
        }
    }
}