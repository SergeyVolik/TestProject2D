using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class ExplosionSFX : MonoBehaviour
    {

        SoundManager m_SManager;
        Bomb m_Bomb;

        [Inject]
        void Construct(SoundManager sManager, Bomb bomb)
        {
            m_SManager = sManager;
            m_Bomb = bomb;
        }

        private void OnEnable() =>
            m_Bomb.OnExploded += PlayHitSound;




        private void OnDisable() =>
            m_Bomb.OnExploded -= PlayHitSound;


        void PlayHitSound(Vector2 pos)
        {
            m_SManager.PlayExplosionSound();
        }
    }

}
