using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class DeathSFX : MonoBehaviour
    {

        SoundManager m_SManager;
        DeathHandler m_DeathHanlder;

        [Inject]
        void Construct(SoundManager sManager, DeathHandler deathHandler)
        {
            m_SManager = sManager;
            m_DeathHanlder = deathHandler;
        }

        private void OnEnable() =>
            m_DeathHanlder.OnDeath += PlayHitSound;




        private void OnDisable() =>
            m_DeathHanlder.OnDeath -= PlayHitSound;


        void PlayHitSound()
        {
           
            m_SManager.PlayDeathSound();
        }
    }

}
