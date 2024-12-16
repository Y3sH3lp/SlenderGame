using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollectable : MonoBehaviour
{
    public int booksCollected = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Book"))
        {
            booksCollected++;
            Destroy(other.gameObject); 
            NewBehaviourScript.instance.UpdateEnemyAttributes(booksCollected);
        }
    }
}
