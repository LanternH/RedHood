using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SpriteRenderer theSR;

    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.CompareTag("Player"))
        {
            CheckPointsController.instance.DeactivateCheckPoints();
            theSR.sprite = sprites[0];
            CheckPointsController.instance.SetSpawnPoint(transform.position);
        }    
    }

    public void ResetCheckPoints()
    {
        theSR.sprite = sprites[1];
    }
}
