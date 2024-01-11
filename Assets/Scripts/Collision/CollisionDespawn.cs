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
            // Zähler im Score-Skript erhöhen
            if (scoreScript != null)
            {
                scoreScript.IncreaseScore();
            }

            // Zerstöre das kollidierende Objekt
            Destroy(other.gameObject);
        }
    }
}
