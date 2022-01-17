using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{
    public class Axe : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Axe> { }
    }

}
