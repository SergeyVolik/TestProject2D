using UnityEngine;

namespace TestProject
{
    public interface IBombVisitor
    {
        void Visit(Bomb bomb);
    }
}
