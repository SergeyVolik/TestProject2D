using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace TestProject
{


    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Bullet : Projectile2D, IBullet, IBulletCollision, IBulletVisitor
    {
        public event Action<Vector2> OnCollision;
      

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            var visitor = collision.gameObject.GetComponent<IBulletVisitor>();

            visitor?.Visit(this, collision);
 
            Destroy(gameObject);

        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {

            if (!collision.CompareTag(Owner.tag))
            {
                MetalCollision();
            }

          
        }

        public void MetalCollision()
        {

            OnCollision?.Invoke(transform.position);


            StartCoroutine(WaitAndDestory());
        }


        public void TakeDamge(int damage, Collision2D collision, bool fromLeft)
        {
            if(collision != null && collision.contacts.Length > 0)
                OnCollision?.Invoke(collision.contacts[0].point);
            

            StartCoroutine(WaitAndDestory());
        }

        IEnumerator WaitAndDestory()
        {
            yield return null;
            yield return null;
            if(gameObject != null)
            Destroy(gameObject);
        }

        public void Visit(Bullet bullet, Collision2D Collision2D)
        {
            MetalCollision();
        }

        public class Factory : PlaceholderFactory<Bullet>
        {

        }
    }

}
