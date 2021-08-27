using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    /*tankview is attched to player tank prefab, takes input for player tank working on modifications */
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        private float movement, rotation;
        private float canFire = 0f;
        public Transform BulletShootPoint;
        // public GameObject tankDestroyVFX;
        public MeshRenderer[] childs;

        public ParticleSystem TankDestroyVFX;

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        void Update()
        {
            Movement();
            ShootBullet();
        }

        private void FixedUpdate()
        {
            tankController.MoveTank(movement, tankController.tankModel.movementSpeed);
            tankController.RotateTank(rotation, tankController.tankModel.rotationSpeed);
        }

        private void Movement()
        {
            rotation = Input.GetAxisRaw("Horizontal");
            movement = Input.GetAxisRaw("Vertical");
        }

        private void ShootBullet()
        {
            if (Input.GetButtonDown("Fire1") && canFire < Time.time)
            {
                canFire = tankController.tankModel.fireRate + Time.time;
                tankController.ShootBullet();
            }
        }

        public void DestroyView()
        {
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i] = null;
            }
            tankController = null;
            BulletShootPoint = null;
            TankDestroyVFX.transform.parent = null;
            TankDestroyVFX.Play();
            Destroy(TankDestroyVFX.gameObject, TankDestroyVFX.main.duration + 1f);
            Destroy(this.gameObject);
        }


        // public void TakeDamage(float damage)
        // {
        //     tankController.ApplyDamage(damage);
        // }

    }//class
}

