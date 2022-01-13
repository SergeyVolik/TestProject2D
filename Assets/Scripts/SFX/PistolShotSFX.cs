using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class PistolShotSFX : MonoBehaviour
    {

        SoundManager m_SManager;
        Gun m_Gun;

        [Inject]
        void Construct(SoundManager sManager, Gun gun)
        {
            m_SManager = sManager;
            m_Gun = gun;
        }

        private void OnEnable() =>
            m_Gun.OnShot += PlayShot;




        private void OnDisable() =>
            m_Gun.OnShot -= PlayShot;


        void PlayShot(Vector2 pos)
        {
            m_SManager.PlayPistolShot();
        }
    }

}
