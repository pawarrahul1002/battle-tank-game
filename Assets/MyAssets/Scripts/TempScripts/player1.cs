using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class player1 : MonoBehaviour
    {
        void Start()
        {
            player2.GetInstance().CreatingBullet();
        }
    }
}