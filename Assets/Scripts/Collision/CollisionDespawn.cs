using UnityEngine;

public class CollisionDespawn : MonoBehaviour
{
    private Score scoreScript;

    void Start()
    {
        scoreScript = FindObjectOfType<Score>();
    }

    // Destroy GameObject once it hits the Despawner GameObject
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collision"))
        {
            // Z�hler im Score-Skript erh�hen
            if (scoreScript != null)
            {
                scoreScript.IncreaseScore();
            }

            // Zerst�re das kollidierende Objekt
            Destroy(other.gameObject);
        }
    }
}
