using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Collectibles
{
    protected override void Collected()
    {
        LevelManager.instance.gemColleted++;

        //isCollected = true;
        Destroy(gameObject);

        Instantiate(pickupEffect, transform.position, transform.rotation);
        UIController.instance.UpdateGemCount();
    }
}
