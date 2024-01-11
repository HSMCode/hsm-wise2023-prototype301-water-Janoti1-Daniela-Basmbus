using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab für den zu spawnenden Feind

    public float minYPosition = 0f; // Minimale Y-Position, an der Feinde spawnen können
    public float maxYPosition = 5f; // Maximale Y-Position, an der Feinde spawnen können

    public float spawnFrequency = 2f; // Spawn-Frequenz in Sekunden (Zeit zwischen den Spawns)
    private float spawnTimer = 0f; // Timer für die Spawn-Frequenz

    void Update()
    {
        // Aktualisiere den Timer basierend auf der vergangenen Zeit
        spawnTimer += Time.deltaTime;

        // Überprüfe, ob es Zeit ist, einen Feind zu spawnen
        if (spawnTimer >= spawnFrequency)
        {
            // Setze den Timer zurück
            spawnTimer = 0f;

            // Rufe die Methode zum Spawnen eines Feindes auf
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
    // Generiere eine zufällige Y-Position für den Spawn innerhalb des definierten Bereichs
    float randomYPosition = Random.Range(minYPosition, maxYPosition);

    // Erstelle einen neuen Feind an der generierten Position
    GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, randomYPosition, transform.position.z), Quaternion.identity);

    // Rotiere den neuen Feind um -90 Grad auf der Y-Achse
    newEnemy.transform.Rotate(new Vector3(0f, -90f, 0f));
    }
}