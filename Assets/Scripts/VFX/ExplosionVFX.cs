using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    [RequireComponent(typeof(Bomb))]
    public class ExplosionVFX : MonoBehaviour
    {
        VFXManager m_VFXManager;
        Bomb m_Bomb;
        [Inject]
        void Construct(VFXManager vFXManager, Bomb bomb)
        {
            m_VFXManager = vFXManager;
            m_Bomb = bomb;
        }

        private void OnEnable()
        {
            m_Bomb.OnExploded += OnExploded;
        }

        private void OnDisable()
        {
            m_Bomb.OnExploded -= OnExploded;
        }

        void OnExploded(Vector2 pos)
        {
            m_VFXManager.PlayExplosionWithPos(pos);
        }
    }

}
