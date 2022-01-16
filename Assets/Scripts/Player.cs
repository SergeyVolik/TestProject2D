using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class Player : MonoBehaviour, IHealable, IDamageable
    {
        [SerializeField]
        private BoxCollider2D BodyCollider;
        [SerializeField]
        private Rigidbody2D BodyRB;
        [SerializeField]
        private bool m_IsGrounded = false;

        private int m_CurrentJump;
        private HealthHandler m_HealthHandler;
        private Gun m_Gun;
        private PlayerSettings PlayerSettings;
        private BodyShield m_Shield;

        [SerializeField]
        RagdollModel m_Ragdoll;
        [SerializeField]
        bool m_LookLeft;


        public Vector2 LookDiraction => !m_LookLeft ? Vector2.right : Vector2.left;
        public bool LookLeft => m_LookLeft;

        public bool IsGrounded => m_IsGrounded;

        public event Action OnJumped;

        private bool m_IsAlive = true;
        public bool IsAlive => m_IsAlive;

        [Inject]
        private void Construct(HealthHandler healthHandler, Gun gun, PlayerSettings settings, BodyShield shield)
        {
            m_HealthHandler = healthHandler;
            m_HealthHandler.Health = settings.MaxHealth;
          
            healthHandler.MaxHealth = settings.MaxHealth;
            m_Gun = gun;
            PlayerSettings = settings;
            m_Shield = shield;
        }

        private void OnEnable()
        {
            m_HealthHandler.OnDamageTaken += CheckDeath;
        }

     

        private void Update()
        {

            m_IsGrounded = CheckGround();

            if (m_IsGrounded)
                m_CurrentJump = 0;
        }

        private void OnDisable()
        {
            m_HealthHandler.OnDamageTaken -= CheckDeath;
        }

        private void CheckDeath(int damage, Collision2D collision, bool fromLeft)
        {
            if (m_HealthHandler.Health <= 0)
            {
                ActivateRagdoll(fromLeft, collision);
              
            }
        }

        private void ActivateRagdoll(bool fromLeft, Collision2D collision)
        {
            Debug.Log($"{gameObject.name} killed");
            var vector = fromLeft ? Vector2.left : Vector2.right;

            m_IsAlive = false;
            BodyCollider.enabled = false;
            BodyRB.simulated = false;

            m_Gun.Drop();
            m_Ragdoll.Activate();

            if (collision != null)
            {
                collision.rigidbody.AddForce(vector * 5000);
            }
        }

        private bool CheckGround()
        {
            return Physics2D.Raycast(BodyCollider.bounds.center, Vector2.down, BodyCollider.bounds.extents.y + .1f, PlayerSettings.GoundMask);
        }

      

        public void Jump()
        {
            if (m_CurrentJump < PlayerSettings.AdditionalJumps && m_IsAlive) 
            {
                m_CurrentJump++;
                BodyRB.velocity = new Vector2(BodyRB.velocity.x, 0);
                BodyRB.AddForce(Vector2.up * PlayerSettings.JumpForce);
                OnJumped.Invoke();
            }
        }

        public void Shot()
        {
            if (m_IsAlive)
            {
                m_Gun.Shot();
            }
        }

        public void Heal(int value)
        {
            m_HealthHandler.Heal(value);
        }

        public void TakeDamge(int damage, Collision2D collision, bool fromLeft)
        {
            m_HealthHandler.TakeDamge(damage, collision, fromLeft);
        }

        public void ActivateShield()
        {
            m_Shield.Activate();
        }

        public void ActivateRoketBullets()
        {
            m_Gun.ActivateRoketBullets();
        }
    }

}
