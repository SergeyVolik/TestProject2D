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

        Bomb.Factory m_Factory;

        [Inject]
        void Construct(Bomb.Factory factory)
        {
            m_Factory = factory;
        }


        public void SpawnBomb()
        {
            var bomb = m_Factory.Create();
            bomb.transform.position = m_SpawnPoint.position;


        }

    }

}
