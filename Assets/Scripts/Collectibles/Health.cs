using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Collectibles
{
    [SerializeField] private int amoutToHeal;
    protected override void Collected()
    {
        
        if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
        {
            PlayerHealthController.instance.HealPlayer(amoutToHeal);

            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
