using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class HitSFX : MonoBehaviour
    {

        SoundManager m_SManager;
        HealthHandler m_HealthHanlder;

        [Inject]
        void Construct(SoundManager sManager, HealthHandler healthHandler)
        {
            
            m_SManager = sManager;
            m_HealthHanlder = healthHandler;
        }

        private void OnEnable() =>
            m_HealthHanlder.OnDamageTaken += PlayHitSound;




        private void OnDisable() =>
            m_HealthHanlder.OnDamageTaken -= PlayHitSound;


        void PlayHitSound(int damage, Collision2D pos, bool fromLeft)
        {
           
            m_SManager.PlayHitSound();
        }
    }

}
