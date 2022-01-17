using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{
    public class SimpleEnemySpawner : MonoBehaviour
    {
        private SimpleEnemy.Factory m_Factory;

        [Inject]
        void Construct(SimpleEnemy.Factory factory)
        {
            m_Factory = factory;
        }

        [SerializeField]
        private Transform m_spawnPoint;

        [SerializeField]
        private float m_RandomXOffset = 1;

        SimpleEnemy m_PrevEnemy;

        private void Start()
        {
            SpawnNewEnemy();
        }


        private void SpawnNewEnemy()
        {
           
            var enemy = m_Factory.Create();
            enemy.transform.position = new Vector3(m_spawnPoint.position.x + UnityEngine.Random.Range(-m_RandomXOffset, m_RandomXOffset), m_spawnPoint.position.y, m_spawnPoint.position.z);
            m_PrevEnemy = enemy;

            m_PrevEnemy.Death.OnDeath += Death_OnDeath;
        }

        private void DestroyPrevEnemyAndSpawnNew()
        {
           
            m_PrevEnemy.Death.OnDeath -= Death_OnDeath;
            StartCoroutine(DestroyWithDelay(m_PrevEnemy.gameObject));
            
        }

        private void Death_OnDeath()
        {

            DestroyPrevEnemyAndSpawnNew();
        }

        IEnumerator DestroyWithDelay(GameObject obj)
        {
            yield return new WaitForSeconds(2f);
            SpawnNewEnemy();
            Destroy(obj);
        }
    }
}

