using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
  
    public class ExplosionEffect : BaseEffect
    {
       
        public class Factory : PlaceholderFactory<ExplosionEffect>
        {
            
        }
    }

}
