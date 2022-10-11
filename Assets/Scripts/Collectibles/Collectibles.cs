using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)     
     {
        if(other.CompareTag("Player")) 
        {
            Collected();
        }
    }
    protected abstract void Collected();
}
