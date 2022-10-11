using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    [SerializeField] public int currentHealth, maxHealth;

    [SerializeField] private float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer theSR;

    public GameObject deathEffect;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
        else 
        {
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
        }
    }

    public void DealDamage(int amountDamage)
    {
        if(invincibleCounter <= 0 )
        {
            currentHealth -= amountDamage;

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                //gameObject.SetActive(false);
                Instantiate(deathEffect, transform.position, transform.rotation);
                LevelManager.instance.RespawnPlayer();
            }
            else 
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);
                PlayerController.instance.Knockback();
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer(int amountToHeal)
    {
        currentHealth += amountToHeal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }
}
