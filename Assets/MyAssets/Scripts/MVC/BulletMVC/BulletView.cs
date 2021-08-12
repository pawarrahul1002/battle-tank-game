using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }
        public ParticleSystem BullectDestroyVFX;
        public float m_MaxLifeTime = 1f;
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        void Start()
        {
            // If it isn't destroyed by then, destroy the shell after it's lifetime.
            Destroy(gameObject, m_MaxLifeTime);
        }


        private void FixedUpdate()
        {
            bulletController.Movement();
        }

        void OnTriggerEnter(Collider other)
        {


            BullectDestroyVFX.transform.parent = null;
            BullectDestroyVFX.Play();

            Destroy(BullectDestroyVFX.gameObject, BullectDestroyVFX.main.duration);
            Destroy(gameObject);
        }





    }
}