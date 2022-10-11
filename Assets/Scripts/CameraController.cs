using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform farBG, middleBG;

    public float minHeigth, maxHeigth;

    private Vector2 parallaxVector;
    private float offset = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        parallaxVector = (Vector2)transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Follow the Target
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeigth, maxHeigth), transform.position.z);

        // Parallax
        Vector2 amountToMove = (Vector2)transform.position - parallaxVector;

        farBG.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBG.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * offset ;

        parallaxVector = new Vector2(transform.position.x, transform.position.y);
        
    }
}
