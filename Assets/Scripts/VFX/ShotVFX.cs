using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class ShotVFX : MonoBehaviour
    {
        VFXManager m_VFXManager;
        Gun m_Gun;
        [Inject]
        void Construct(VFXManager vFXManager, Gun gun)
        {
            m_VFXManager = vFXManager;
            m_Gun = gun;
        }

        private void OnEnable()
        {
            m_Gun.OnShot += OnShot;
        }

        private void OnDisable()
        {
            m_Gun.OnShot -= OnShot;
        }

        void OnShot(Vector2 pos)
        {
            m_VFXManager.PlayMuzzleEffectWithPos(pos);
        }
    }

}
