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

       [Inject]
        void Construct(Bomb.Factory bombFactory, FirstAidKit.Factory fikFactory)
        {
            m_BombFactory = bombFactory;
            m_FIKFactory = fikFactory;
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

    }

}
