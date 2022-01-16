using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class Leg : BodyPart, ILeg, IBulletVisitor, IBombVisitor, IRoketVisitor
    {
        int m_LegDamage;


        [Inject]
        void Construct(ShootingSettigs settings)
        {
            m_LegDamage = settings.LegDamage;
        }

        public void Visit(Bullet bullet, Collision2D Collision2D)
        {
            m_Health.TakeDamge(m_LegDamage, Collision2D, bullet.FromLeft);
        }

        public void Visit(Bomb bomb)
        {
            m_Health.TakeDamge(9999, null, false);
        }

        public void Visit(RoketBullet roket, Collision2D col)
        {
            m_Health.TakeDamge(9999, col, roket.FromLeft);
        }
    }

}
