using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public List<IDamageable> Damageables { get; } = new();

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if(damageable != null)
        {
            Damageables.Add(damageable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if(damageable != null && Damageables.Contains(damageable))
        {
            Damageables.Remove(damageable);
        }
    }
}
