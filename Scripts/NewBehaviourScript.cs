using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    
    public static NewBehaviourScript instance; 
    public float _viewDistance;               
    public Transform target;                  
    public AudioSource audioSource;           
    public Canvas _canvas;                    
    public float _speed;                      
    public float _speedIncrement = 0.5f;      
    public float _viewDistanceIncrement = 2f;

    private NavMeshAgent agent;  

    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = _speed; 
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _viewDistance);
    }
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < _viewDistance)
        {
            agent.SetDestination(target.position);
        }
        
        if (distance < 3)
        {
            float angle = Vector3.Angle(transform.forward, target.position - transform.position);
            if (angle > 160f)
            {
                
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                _canvas.enabled = true;
            }
        }
    }
    public void UpdateEnemyAttributes(int booksCollected)
    {
        agent.speed = _speed + (booksCollected * _speedIncrement); 
        _viewDistance += booksCollected * _viewDistanceIncrement; 
    }
}
