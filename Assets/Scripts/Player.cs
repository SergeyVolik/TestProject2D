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
        public Vector2 LookDiraction => transform.rotation.eulerAngles.y == 180 ? Vector2.left : Vector2.right;
        public bool LookLeft => transform.rotation.eulerAngles.y == 180 ? true : false;
        public bool IsGrounded => m_IsGrounded;

        public event Action OnJumped;

    

        [Inject]
        private void Construct(HealthHandler healthHandler, Gun gun, PlayerSettings settings)
        {
            m_HealthHandler = healthHandler;
            m_HealthHandler.Health = settings.MaxHealth;
          
            healthHandler.MaxHealth = settings.MaxHealth;
            m_Gun = gun;
            PlayerSettings = settings;
        }

        private bool CheckGrounded()
        {
            return Physics2D.Raycast(BodyCollider.bounds.center, Vector2.down, BodyCollider.bounds.extents.y + .1f, PlayerSettings.GoundMask);
        }

        private void Update()
        {

            m_IsGrounded = CheckGrounded();

            if (m_IsGrounded)
                m_CurrentJump = 0;
        }

        public void Jump()
        {
            if (m_CurrentJump < PlayerSettings.AdditionalJumps)
            {
                m_CurrentJump++;
                BodyRB.velocity = new Vector2(BodyRB.velocity.x, 0);
                BodyRB.AddForce(Vector2.up * PlayerSettings.JumpForce);
                OnJumped.Invoke();
            }
        }

        public void Shot()
        {
            m_Gun.Shot();
        }

        public void Heal(int value)
        {
            m_HealthHandler.Heal(value);
        }

        public void TakeDamge(int damage, Collision2D collision, bool fromLeft)
        {
            m_HealthHandler.TakeDamge(damage, collision, fromLeft);
        }
    }

}
