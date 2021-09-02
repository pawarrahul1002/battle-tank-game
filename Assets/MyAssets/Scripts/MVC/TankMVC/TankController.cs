using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    /*TankController: intialized player tank, controlls all movement 
        and destroy fun also controls calling of bullets  */
    public class TankController
    {
        public TankModel tankModel { get; private set; }
        public TankView tankView { get; private set; }
        private Rigidbody rb;
        public TankController(TankModel _tankModel, TankView _tankView)
        {

            PlayerPrefs.DeleteAll();
            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);
            CameraController.instance.SetTarget(tankView.transform);
            rb = tankView.GetComponent<Rigidbody>();
            tankView.SetTankController(this);
            tankModel.SetTankController(this);
            SubscribeEvents();

        }

        private void SubscribeEvents()
        {
            EventService.GetInstance().OnPlayerFiredBullet += UpdateBulletsFiredCounter;
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

        private void UpdateBulletsFiredCounter()
        {
            tankModel.bulletFired += 1;
            // PlayerPrefs.SetInt("BulletsFired", tankModel.bulletFired);
            // Debug.Log(PlayerPrefs.GetInt("BulletsFired"));
            Debug.Log(tankModel.bulletFired);
            AchievementServices.GetInstance().GetAchievementController().CheckForBulletFiredAchievement();

        }

        public void ShootBullet()
        {
            EventService.GetInstance().InvokeOnPlayerFiredBulletEvent();
            BulletServices.GetInstance().CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        private void UnSubscribeEvents()
        {
            EventService.GetInstance().OnPlayerFiredBullet -= UpdateBulletsFiredCounter;
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
            Debug.Log("Player Health : " + tankModel.health);

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
            UnSubscribeEvents();
        }

    }

}//class
