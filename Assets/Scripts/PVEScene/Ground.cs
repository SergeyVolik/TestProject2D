using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.PVE
{
    public class Ground : MonoBehaviour, IAxeVisitor
    {
        public void Visit(Axe bullet, Collision2D Collision2D)
        {
            bullet.Stop(transform);
        }

       
    }

}
