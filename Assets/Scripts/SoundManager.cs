using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class SoundManager : MonoBehaviour
    {
        SoundShot.Factory m_Factory;
        GameSounds m_Sounds;
        [Inject]
        void Construct(SoundShot.Factory factory, GameSounds sounds)
        {
            m_Factory = factory;
            m_Sounds = sounds;
        }

        public void PlayPistolShot()
        {
            var shot = m_Factory.Create();
            shot.Play(m_Sounds.ShotSFX);

        }

        public void PlayBulletCollistion()
        {
            var shot = m_Factory.Create();
            shot.Play(m_Sounds.BulletCollisionSFX);
        }

        public void PlayHitSound()
        {
            var shot = m_Factory.Create();
            shot.Play(m_Sounds.HitSFX);
        }
    }

}

