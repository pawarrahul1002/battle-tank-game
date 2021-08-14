using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class player1 : MonoBehaviour
    {
        private TankView tankView;

        public void SetTankView(TankView tank)
        {
            tankView = tank;
        }

        public Transform GetTankTransform()
        {
            return tankView.transform;
        }

        void Start()
        {
            Debug.Log(tankView.transform.position);
        }
    }
}