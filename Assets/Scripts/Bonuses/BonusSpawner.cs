using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class BonusSpawner : MonoBehaviour
    {

        [SerializeField]
        Transform m_SpawnPoint;

        Bomb.Factory m_BombFactory;
        FirstAidKit.Factory m_FIKFactory;
        ShieldBuster.Factory m_ShieldBusterFactory;
        RoketBulletsBonus.Factory m_RoketBulletsBonus;

        [Inject]
        void Construct(Bomb.Factory bombFactory, FirstAidKit.Factory fikFactory, ShieldBuster.Factory shieldBusterFactory, RoketBulletsBonus.Factory roketBulletsBonus)
        {
            m_BombFactory = bombFactory;
            m_FIKFactory = fikFactory;
            m_ShieldBusterFactory = shieldBusterFactory;
            m_RoketBulletsBonus = roketBulletsBonus;
        }


        public void SpawnBomb()
        {
            var bomb = m_BombFactory.Create();
            bomb.transform.position = m_SpawnPoint.position;


        }

        public void SpawnFirstAidKit()
        {
            var fik = m_FIKFactory.Create();
            fik.transform.position = m_SpawnPoint.position;


        }

        public void SpawnShieldBuster()
        {
            var fik = m_ShieldBusterFactory.Create();
            fik.transform.position = m_SpawnPoint.position;


        }

        public void SpawnRoketBulletsBonus()
        {
            var fik = m_RoketBulletsBonus.Create();
            fik.transform.position = m_SpawnPoint.position;


        }

    }

}
