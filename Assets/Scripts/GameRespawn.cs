using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameReswan : MonoBehaviour
{

    
    public Vector3 PlayerPosition;
    [SerializeField] List<GameObject> CheckPoint;
    [SerializeField] Vector3 vectorPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -3)
        {
            transform.position = new Vector3(PlayerPosition.x,PlayerPosition.y,PlayerPosition.z);
            GameManager.Health = GameManager.Health - 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = other.transform.position;
        PlayerPosition = vectorPoint; 
    }
}
