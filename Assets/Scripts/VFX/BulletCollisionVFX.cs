using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public interface IBulletCollision
    {
        event Action<Vector2> OnCollision;
    }

    public class BulletCollisionVFX : MonoBehaviour
    {
        VFXManager m_VFXManager;
        IBulletCollision m_Bullet;
        [Inject]
        void Construct(VFXManager vFXManager, IBulletCollision bullet)
        {
            m_VFXManager = vFXManager;
            m_Bullet = bullet;
        }

        private void OnEnable()
        {
            m_Bullet.OnCollision += OnShot;
        }

        private void OnDisable()
        {
            m_Bullet.OnCollision -= OnShot;
        }

        void OnShot(Vector2 pos)
        {
            m_VFXManager.PlayBulletCollision(pos);
        }
    }

}
