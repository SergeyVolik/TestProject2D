using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class BulletCollisionSFX : MonoBehaviour
    {

        SoundManager m_SManager;
        IBulletCollision m_Bullet;

        [Inject]
        void Construct(SoundManager sManager, IBulletCollision healthHandler)
        {
            m_SManager = sManager;
            m_Bullet = healthHandler;
        }

        private void OnEnable() =>
            m_Bullet.OnCollision += PlayBulletCollision;




        private void OnDisable() =>
            m_Bullet.OnCollision -= PlayBulletCollision;


        void PlayBulletCollision(Vector2 pos)
        {
            m_SManager.PlayBulletCollistion();
        }
    }

}
