using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int booksCollected = 0; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Book"))
        {
            booksCollected++; 
            Destroy(other.gameObject); 

            
            if (NewBehaviourScript.instance != null)
            {
                NewBehaviourScript.instance.UpdateEnemyAttributes(booksCollected);
            }
        }
    }
}
