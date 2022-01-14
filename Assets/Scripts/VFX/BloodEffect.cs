using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
  
    public class BloodEffect : BaseEffect
    {
       
        public class Factory : PlaceholderFactory<BloodEffect>
        {
            
        }
    }

}
