using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class SimpleEnemyInstall : MonoInstaller
    {


        [SerializeField]
        DeathHandler deathHandlder;
        [SerializeField]
        HealthHandler healthHandlder;
        [SerializeField]
        RagdollModel RagdollModel;
        [SerializeField]
        Animator Animator;

        public override void InstallBindings()
        {
            Container.Bind<DeathHandler>().FromInstance(deathHandlder).AsSingle();
            Container.Bind<HealthHandler>().FromInstance(healthHandlder).AsSingle();
            Container.Bind<RagdollModel>().FromInstance(RagdollModel).AsSingle();
            Container.Bind<Animator>().FromInstance(Animator).AsSingle();
        }
    }
}
