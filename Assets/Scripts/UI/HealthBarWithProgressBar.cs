using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public class HealthBarWithProgressBar : AbstractHealthBar
    {
        [SerializeField]
        private Slider m_Slider;


        protected override void UpdateHealthBar()
        {
            var health = m_Health.Health;

            m_Slider.value = health / (float)m_Health.MaxHealth;
        }

    }


}
