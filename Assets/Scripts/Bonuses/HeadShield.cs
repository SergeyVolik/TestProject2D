using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HeadShield : BodyShield, IDamageable, IBulletVisitor, IRoketVisitor
    {

        protected override void Start()
        {
            m_SR = GetComponent<SpriteRenderer>();
            m_SR.color = m_ShieldSettins.color;
            //m_SR.transform.localScale = new Vector3(m_ShieldSettins.size, m_ShieldSettins.size, m_ShieldSettins.size);
            duration = m_ShieldSettins.headShieldDuration;
            gameObject.SetActive(false);
        }

      
    }

}
