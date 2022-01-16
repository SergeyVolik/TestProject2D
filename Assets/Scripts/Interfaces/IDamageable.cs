using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestProject
{
    public interface IDamageable
    {
        void TakeDamge(int damage, Collision2D collision, bool fromLeft);
    }
}
