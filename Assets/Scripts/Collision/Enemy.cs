// Enemy Script
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed = 3f; // Minimale Geschwindigkeit des Feinds
    public float maxSpeed = 6f; // Maximale Geschwindigkeit des Feinds

    void Update()
    {
        // Bewege den Feind vorw�rts in der Z-Achse mit einer zuf�lligen Geschwindigkeit zwischen minSpeed und maxSpeed
        float speed = Random.Range(minSpeed, maxSpeed);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // �berpr�fe, ob der Feind den Spieler ber�hrt
        if (other.CompareTag("Player"))
        {
            // Hole das PlayerDespawn-Skript und rufe die Methode f�r den Spieler-Hit auf
            PlayerDespawn playerDespawnScript = other.GetComponent<PlayerDespawn>();
            if (playerDespawnScript != null)
            {
                playerDespawnScript.PlayerHit();
            }
        }
    }
}
