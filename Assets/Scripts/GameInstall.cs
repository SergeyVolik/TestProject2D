using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class GameInstall : MonoInstaller
    {
        [SerializeField]
        TapManager Tap;

        public override void InstallBindings()
        {

            Container.Bind<TapManager>().FromInstance(Tap).AsSingle();
        }
    }
}
