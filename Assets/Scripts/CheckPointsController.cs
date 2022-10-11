using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsController : MonoBehaviour
{
    public static CheckPointsController instance;

    [SerializeField] private CheckPoint[] checkpoints;

    public Vector3 spawnPoint;

    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        checkpoints = FindObjectsOfType<CheckPoint>();    

        spawnPoint = PlayerController.instance.transform.position;
    }

    public void DeactivateCheckPoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoints();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
