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
        BonusSettings m_Settings;
        [Inject]
        void Construct(
            Bomb.Factory bombFactory,
            FirstAidKit.Factory fikFactory,
            ShieldBuster.Factory shieldBusterFactory,
            RoketBulletsBonus.Factory roketBulletsBonus,
            BonusSettings settings
            )
        {
            m_Settings = settings;
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

        float m_Time;
        float m_NextSpawnTime;
        private void Start()
        {
            GenerateNextTime();
        }

        void GenerateNextTime()
        {
            m_NextSpawnTime = UnityEngine.Random.Range(m_Settings.SpawnBonusTimeRange.x, m_Settings.SpawnBonusTimeRange.y);
        }

        void SpawnRandomBonus()
        {
            int bonus = Random.Range(0, 3);

            switch (bonus)
            {
                case 0:
                    SpawnBomb();
                    break;
                case 1:
                    SpawnFirstAidKit();
                    break;
                case 2:
                    SpawnShieldBuster();
                    break;
                case 3:
                    SpawnRoketBulletsBonus();
                    break;
                default:
                    break;
            }
        }
        private void Update()
        {
            if (m_Time >= m_NextSpawnTime)
            {
                GenerateNextTime();
                SpawnRandomBonus();
                m_Time = 0;
            }

            m_Time += Time.deltaTime;
        }



    }

}
