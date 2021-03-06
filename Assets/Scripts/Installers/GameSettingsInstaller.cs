using System;
using UnityEngine;
using Zenject;

namespace TestProject
{
    [CreateAssetMenu(menuName = "TestProject2D/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {

        public GameSounds Sounds;
        public ShootingSettigs ShootingSettigs;
        public PlayerSettings PlayerSettings;
        public BonusSettings BonusSettings;
        public GameEndSettings GameEndSettings;
        public RagdollSettings RagdollSettings;
        public override void InstallBindings()
        {
            Container.BindInstance(Sounds);
            Container.BindInstance(ShootingSettigs);
            Container.BindInstance(PlayerSettings);
            Container.BindInstance(BonusSettings);
            Container.BindInstance(GameEndSettings);
            Container.BindInstance(RagdollSettings);
        }


    }

    [Serializable]
    public class GameSounds
    {
        public SFXSettingsSO HitSFX;
        public SFXSettingsSO DeathSFX;
        public SFXSettingsSO BulletCollisionSFX;
        public SFXSettingsSO ShotSFX;
        public SFXSettingsSO ExplosionSFX;
    }

    [Serializable]
    public class GameEndSettings
    {
        public float ShowUIDelay = 1f;
        public float FadeUITime = 1f;
        public float FadePlayerTextTime = 1f;
        public string LeftPlayerWinnerText = "Left player is the winner!";
        public string RightPlayerWinnerText = "Right player is the winner!";
        public string WinnerText = "Winner!";

    }
    [Serializable]
    public class RagdollSettings
    {
        public float mass = 2;
        public float gravity = 4;
        public float breakForce = 2000f;
        public float bulletDeathForce = 600f;
    }

    [Serializable]
    public class BonusSettings
    {
        [MinMaxSlider(5, 20)]
        public Vector2 SpawnBonusTimeRange;

        public BombSettings Bomb;
        public ShieldSettings Shield;
        public FirstAidKitSettings AidKit;
        public RoketBulletsBonusSettings RoketBonus;

        [Serializable]
        public class BombSettings
        {
            public int timeToExplosion = 5;
            public int explosionForce = 2000;
            public int explosionRadius = 4;
            public int explosionDamage = 99999;
            public float bombMass = 4;
            public float bombSize = 4;
        }

       
        [Serializable]
        public class ShieldSettings
        {
            public int duration = 5;
            public int headShieldDuration = 20;
            public float size = 5;
            public Color color;
        }

        [Serializable]
        public class FirstAidKitSettings
        {
            public int MaxHealth = 10;
            public int HealthStrength = 5;
            public float lifetime = 5;
        }

        [Serializable]
        public class RoketBulletsBonusSettings
        {
            public int duration = 5;
            public Sprite RoketSprite;

        }
    }

    [Serializable]
    public class ShootingSettigs
    {
        public float BulletSpeed = 1000f;
        public float DelayBetweenShots = 0.5f;
        public int HeadDamage = 3;
        public int ChessDamage = 2;
        public int LegDamage = 1;
    }

    [Serializable]
    public class PlayerSettings
    {
        public int MaxHealth = 5;
        public LayerMask GoundMask;
        public int AdditionalJumps = 1;
        public float JumpForce = 600;

    }
}
