using UnityEngine;

namespace TestProject
{
    public interface IRoketVisitor
    {
        void Visit(RoketBullet roket, Collision2D Collision2D);
    }
}
