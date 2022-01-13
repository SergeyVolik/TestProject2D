using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class BulletCollisionVFX : MonoBehaviour
    {
        VFXManager m_VFXManager;
        Bullet m_Bullet;
        [Inject]
        void Construct(VFXManager vFXManager, Bullet bullet)
        {
            m_VFXManager = vFXManager;
            m_Bullet = bullet;
        }

        private void OnEnable()
        {
            m_Bullet.OnBulletCollision += OnShot;
        }

        private void OnDisable()
        {
            m_Bullet.OnBulletCollision -= OnShot;
        }

        void OnShot(Vector2 pos)
        {
            m_VFXManager.PlayBulletCollision(pos);
        }
    }

}
