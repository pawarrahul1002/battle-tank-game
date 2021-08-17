﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankController
    {
        public TankModel tankModel { get; private set; }
        public TankView tankView { get; private set; }
        private Rigidbody rb;
        public TankController(TankModel _tankModel, TankView _tankView)
        {
            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);
            CameraController.GetInstance().SetTarget(tankView.transform);
            rb = tankView.GetComponent<Rigidbody>();
            tankView.SetTankController(this);
            tankModel.SetTankController(this);

        }

        public void MoveTank(float movement, float movementSpeed)
        {
            Vector3 move = tankView.transform.position;
            move += tankView.transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
            rb.MovePosition(move);
            TankService.GetInstance().GetPlayerPos(tankView.transform);
        }

        public void RotateTank(float rotation, float rotateSpeed)
        {
            Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
            Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        public void ShootBullet()
        {
            BulletServices.GetInstance().CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        public Vector3 GetFiringPosition()
        {
            return tankView.BulletShootPoint.position;
        }
        public Quaternion GetFiringAngle()
        {
            return tankView.transform.rotation;
        }
        public BulletScriptableObjects GetBullet()
        {
            return tankModel.bulletType;
        }


        public void ApplyDamage(float damage)
        {
            tankModel.health -= damage;
            // UIService.instance.UpdateHealthText(tankModel.health);

            if (tankModel.health <= 0)
            {
                Dead();
            }
        }

        private void Dead()
        {
            TankService.GetInstance().DestroyTank(this);
        }

        public void DestroyController()
        {
            // GameService.instance.CheckForHighScore();
            // SFXService.instance.PlaySoundAtTrack1(tankView.TankDestroySFX, 1f, 10, true);
            // VFXService.instance.InstantiateEffects(tankView.TankDestroyVFX, tankView.transform.position);
            // UIService.instance.ResetScore();
            tankModel.DestroyModel();
            tankView.DestroyView();
            tankModel = null;
            tankView = null;
            rb = null;
            // UnSubscribeEvents();
        }

    }

}//class


































// public TankView TankView { get; private set; }
// public TankModel TankModel { get; private set; }
// // private Rigidbody rigidbody;
// public TankController(TankModel tankModel, TankView tankPrefab)
// {
//     TankModel = tankModel;
//     TankView = GameObject.Instantiate<TankView>(tankPrefab);
//     // rigidbody = TankView.GetComponent<Rigidbody>();
//     TankView.SetTankController(this);
//     tankModel.SetTankController(this);
// }


// public void Move(float movement, float movementSpeed)
// {
//     Vector3 move = TankView.transform.transform.position += TankView.transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
//     rigidbody.MovePosition(move);
// }

// public void Rotate(float rotation, float rotateSpeed)
// {
//     Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
//     Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
//     rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
// }