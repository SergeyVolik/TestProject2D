using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{
    public class Axe : Projectile2D
    {
        public Rigidbody2D rb;
        private Collider2D[] colliders;

        protected override void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.collider.TryGetComponent<IAxeVisitor>(out var visitor))
            {
                print("Axe visit");
                visitor.Visit(this, collision);
            }
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            //throw new System.NotImplementedException();
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            colliders = GetComponentsInChildren<Collider2D>();
        }

        public void Stop(Transform parent)
        {          
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            transform.parent = parent;

            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }

        public class Factory : PlaceholderFactory<Axe> { }
    }

}
