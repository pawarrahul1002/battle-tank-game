using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    /* tankmodel : it is used to assiging behavious 
        to player tank with help of scriptable object*/
    public class TankModel
    {
        private TankController tankController;
        public TankType tankType { get; private set; }
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float health { get; set; }
        public BulletScriptableObjects bulletType { get; private set; }
        public float fireRate { get; private set; }
        public TankModel(TankScriptableObjects tankSO)
        {

            //type
            tankType = tankSO.tankType;

            // behaviour vars
            movementSpeed = tankSO.movementSpeed;
            rotationSpeed = tankSO.rotationSpeed;
            health = tankSO.health;
            fireRate = tankSO.fireRate;
            bulletType = tankSO.bulletType;
        }

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        public void DestroyModel()
        {
            // material = null;
            bulletType = null;
            tankController = null;
        }

    }//class


}

