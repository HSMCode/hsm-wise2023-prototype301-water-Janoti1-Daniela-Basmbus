using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab f�r den zu spawnenden Feind

    public float minYPosition = 0f; // Minimale Y-Position, an der Feinde spawnen k�nnen
    public float maxYPosition = 5f; // Maximale Y-Position, an der Feinde spawnen k�nnen

    public float spawnFrequency = 2f; // Spawn-Frequenz in Sekunden (Zeit zwischen den Spawns)
    private float spawnTimer = 0f; // Timer f�r die Spawn-Frequenz

    void Update()
    {
        // Aktualisiere den Timer basierend auf der vergangenen Zeit
        spawnTimer += Time.deltaTime;

        // �berpr�fe, ob es Zeit ist, einen Feind zu spawnen
        if (spawnTimer >= spawnFrequency)
        {
            // Setze den Timer zur�ck
            spawnTimer = 0f;

            // Rufe die Methode zum Spawnen eines Feindes auf
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
    // Generiere eine zuf�llige Y-Position f�r den Spawn innerhalb des definierten Bereichs
    float randomYPosition = Random.Range(minYPosition, maxYPosition);

    // Erstelle einen neuen Feind an der generierten Position
    GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, randomYPosition, transform.position.z), Quaternion.identity);

    // Rotiere den neuen Feind um -90 Grad auf der Y-Achse
    newEnemy.transform.Rotate(new Vector3(0f, -90f, 0f));
    }
}