using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class Gun : MonoBehaviour
    {

        [SerializeField]
        Transform m_SpawnPoint;

        Bullet.Factory m_Factory;
        Player m_Player;
        ShootingSettigs m_ShootingSettigs;
        VFXManager m_VFXManager;

        private bool m_CanShoot = true;

        public event Action<Vector2> OnShot;

        [Inject]
        void Construct(
             Bullet.Factory factory,
             Player player,
             ShootingSettigs settings,
             SoundManager soundsManager,
             VFXManager vfxManager)
        {
            m_Factory = factory;
            m_Player = player;
            m_ShootingSettigs = settings;
            m_VFXManager = vfxManager;

        }

        public void Shot()
        {
            if (m_CanShoot)
            {
                var bullet = m_Factory.Create();
                bullet.transform.position = m_SpawnPoint.position;

                if (m_Player.LookLeft)
                    bullet.SpriteRenderer.flipX = true;

                bullet.Rigidbody2D.AddForce(m_Player.LookDiraction * m_ShootingSettigs.BulletSpeed);

                StartCoroutine(WaiDelay());

                OnShot?.Invoke(m_SpawnPoint.position);
            }
        }

   
        IEnumerator WaiDelay()
        {
            m_CanShoot = false;
            yield return new WaitForSeconds(m_ShootingSettigs.DelayBetweenShots);
            m_CanShoot = true;
        }


    }

}
