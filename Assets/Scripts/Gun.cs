using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class Gun : MonoBehaviour
    {
        Bullet.Factory m_Factory;
        MuzzleFlashEffect.Factory m_MuzzleFlashFactory;
        Player m_Player;
        [SerializeField]
        Transform m_SpawnPoint;

        [SerializeField]
        float ShootForce = 1000;

        [Inject]
        void Construct(Bullet.Factory factory, MuzzleFlashEffect.Factory muzzleFlashFactory, Player player)
        {
            m_Factory = factory;
            m_Player = player;
            m_MuzzleFlashFactory = muzzleFlashFactory;
        }

        public void Shot()
        {
            var bullet = m_Factory.Create();
            bullet.transform.position = m_SpawnPoint.position;

            if (m_Player.LookLeft)
                bullet.SpriteRenderer.flipX = true;

            bullet.Rigidbody2D.AddForce(m_Player.LookDiraction * ShootForce);
            var effect = m_MuzzleFlashFactory.Create();
            effect.Play();
            effect.transform.position = m_SpawnPoint.position;
        }


    }

}
