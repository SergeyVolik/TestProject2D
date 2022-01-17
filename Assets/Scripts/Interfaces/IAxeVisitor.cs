using TestProject.PVE;
using UnityEngine;

namespace TestProject
{
    public interface IAxeVisitor
    {
        void Visit(Axe bullet, Collision2D Collision2D);
    }
}
