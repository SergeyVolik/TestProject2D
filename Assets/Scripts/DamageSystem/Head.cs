using System.Collections;
using System.Collections.Generic;
using TestProject.PVE;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class Head : BodyPart, IHead, IBulletVisitor, IBombVisitor, IRoketVisitor, IAxeVisitor
    {
        int m_HeadDamage;
        [Inject]
        void Construct(ShootingSettigs settings)
        {
            m_HeadDamage = settings.HeadDamage;
        }

        public void Visit(Bullet bullet, Collision2D Collision2D)
        {
            m_Health.TakeDamge(m_HeadDamage, Collision2D, bullet.FromLeft);
        }

        public void Visit(Bomb bomb)
        {
            m_Health.TakeDamge(9999, null, false);
        }

        public void Visit(RoketBullet roket, Collision2D col)
        {
            m_Health.TakeDamge(9999, col, roket.FromLeft);
        }

        public void Visit(Axe axe, Collision2D Collision2D)
        {
            TakeDamge(5, Collision2D, axe.FromLeft);
            axe.Stop(transform);

        }
    }

}
