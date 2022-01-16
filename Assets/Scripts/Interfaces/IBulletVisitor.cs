using UnityEngine;

namespace TestProject
{
    public interface IBulletVisitor
    {
        void Visit(Bullet bullet, Collision2D Collision2D);
    }
}
