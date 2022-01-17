using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestProject.PVE
{
    public class ProjectileSlowShield : MonoBehaviour
    {

        class ManagedAxe 
        {
            public Axe Axe;

            public float SavedGravity;
        }
        List<ManagedAxe> Axes = new List<ManagedAxe>();

        [SerializeField]
        float slowingCoef;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Axe>(out var axe))
            {
                Axes.Add(new ManagedAxe { 
                     Axe = axe,
                     SavedGravity = axe.rb.gravityScale
                });
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Axe>(out var axe))
            {
                var managedAxe = Axes.FirstOrDefault(e => e.Axe == axe);
                managedAxe.Axe.rb.gravityScale = managedAxe.SavedGravity;
                Axes.Remove(managedAxe);
            }
        }

        
        private void FixedUpdate()
        {
            for (int i = 0; i < Axes.Count; i++)
            {
                Axes[i].Axe.rb.velocity = Axes[i].Axe.rb.velocity * slowingCoef;
                Axes[i].Axe.rb.angularVelocity = Axes[i].Axe.rb.angularVelocity * slowingCoef;
                Axes[i].Axe.rb.gravityScale = Axes[i].Axe.rb.gravityScale * slowingCoef;
            }
        }

    }

}
