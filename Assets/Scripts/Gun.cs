using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class Gun : MonoBehaviour
    {
        Bullet.Factory m_Factory;
        Player m_Player;
        [SerializeField]
        Transform m_SpawnPoint;

        [SerializeField]
        float ShootForce = 1000;

        [Inject]
        void Construct(Bullet.Factory factory, Player player)
        {
            m_Factory = factory;
            m_Player = player;
        }

        public void Shot()
        {
            var bullet = m_Factory.Create();
            bullet.transform.position = m_SpawnPoint.position;

            if (m_Player.LookLeft)
                bullet.SpriteRenderer.flipX = true;

            bullet.Rigidbody2D.AddForce(m_Player.LookDiraction * ShootForce);
        }


    }

}
