using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class HealthBarWithHearts : AbstractHealthBar
    {
        [SerializeField]
        private List<GameObject> m_Hearts;


        protected override void UpdateHealthBar()
        {
            var health = m_Health.Health;

            for (int i = 0; i < m_Hearts.Count; i++)
            {

                if (i >= health)
                    m_Hearts[i].SetActive(false);
                else m_Hearts[i].SetActive(true);
            }
        }

    }


}
