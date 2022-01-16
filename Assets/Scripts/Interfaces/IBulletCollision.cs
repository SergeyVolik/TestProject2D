using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestProject
{
    public interface IBulletCollision
    {
        event Action<Vector2> OnCollision;
    }
}
