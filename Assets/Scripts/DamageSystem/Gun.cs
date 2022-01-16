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
        [SerializeField]
        Rigidbody2D m_RB;

        Bullet.Factory m_DefaultBulletFactory;
        RoketBullet.Factory m_RoketBulletFactory;
        Player m_Player;
        ShootingSettigs m_ShootingSettigs;
        BonusSettings.RoketBulletsBonusSettings m_RoketBulletsSettings;

        private bool m_CanShoot = true;
        private bool m_RoketBollets = false;
        public event Action<Vector2> OnShot;

        [Inject]
        void Construct(
             Bullet.Factory factory,
             RoketBullet.Factory roketBulletFactory,
             Player player,
             ShootingSettigs settings,
             BonusSettings bonusSettings)
        {
            m_RoketBulletsSettings = bonusSettings.RoketBonus;
            m_DefaultBulletFactory = factory;
            m_Player = player;
            m_ShootingSettigs = settings;
            m_RoketBulletFactory = roketBulletFactory;

        }

        public void Shot()
        {
            if (m_CanShoot)
            {
                Projectile2D bullet;
                if (m_RoketBollets)
                {
                    bullet = m_RoketBulletFactory.Create();
                }
                else bullet = m_DefaultBulletFactory.Create();

                bullet.transform.position = m_SpawnPoint.position;

                if (m_Player.LookLeft)
                    bullet.SpriteRenderer.flipX = true;

                bullet.Rigidbody2D.AddForce(m_Player.LookDiraction * m_ShootingSettigs.BulletSpeed);
                bullet.Owner = m_Player;

                if (m_RoketBollets)
                {
                    bullet.SpriteRenderer.sprite = m_RoketBulletsSettings.RoketSprite;

                }

                StartCoroutine(WaitDelay(m_ShootingSettigs.DelayBetweenShots, () => m_CanShoot = false, () => m_CanShoot = true));

                OnShot?.Invoke(m_SpawnPoint.position);
            }
        }

        public void ActivateRoketBullets()
        {
            StartCoroutine(WaitDelay(m_RoketBulletsSettings.duration, () => m_RoketBollets = true, () => m_RoketBollets = false));
        }

        IEnumerator WaitDelay(float delay, Action beforeDelay, Action afterDelay)
        {
            beforeDelay?.Invoke();
            yield return new WaitForSeconds(delay);
            afterDelay?.Invoke();
        }

        internal void Drop()
        {
            transform.parent = null;
            m_RB.bodyType = RigidbodyType2D.Dynamic;
        }
    }

}
