using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleTank
{
    public class player2 : MonoSingletonGeneric<player2>
    {
        public void CreatingBullet()
        {
            Debug.Log("creating bullets");
        }
    }
}