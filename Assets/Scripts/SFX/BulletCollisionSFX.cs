using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class BulletCollisionSFX : MonoBehaviour
    {

        SoundManager m_SManager;
        Bullet m_Bullet;

        [Inject]
        void Construct(SoundManager sManager, Bullet healthHandler)
        {
            m_SManager = sManager;
            m_Bullet = healthHandler;
        }

        private void OnEnable() =>
            m_Bullet.OnBulletCollision += PlayBulletCollision;




        private void OnDisable() =>
            m_Bullet.OnBulletCollision -= PlayBulletCollision;


        void PlayBulletCollision(Vector2 pos)
        {
            m_SManager.PlayBulletCollistion();
        }
    }

}
