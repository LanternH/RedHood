using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Image[] hearts;

    public Sprite heartFull, heartEmpty, halfHeart;
    public Text gemText;

    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        UpdateGemCount();
    }

    public void UpdateHealthDisplay()
    {
        int currentHealth = PlayerHealthController.instance.currentHealth;
        int maxHealth = PlayerHealthController.instance.maxHealth;
        int heartFragments = (int)(maxHealth / hearts.Length);
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if( (i + 1) * heartFragments <= currentHealth)
            {
                hearts[i].sprite = heartFull;
            }
            else if( i * heartFragments < currentHealth)
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = heartEmpty;
            }
        }
    }

    public void UpdateGemCount()
    {
        gemText.text = LevelManager.instance.gemColleted.ToString();
    }
}
