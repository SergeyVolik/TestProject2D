using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class MuzzleFlashEffect : BaseEffect
    {
        public class Factory : PlaceholderFactory<MuzzleFlashEffect> { }
    }

}
