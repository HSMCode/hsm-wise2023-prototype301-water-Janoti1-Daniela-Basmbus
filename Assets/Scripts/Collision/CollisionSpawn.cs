using UnityEngine;
using System.Collections;

/*
    Spawning of Collision Objects
    - needs the Collision Object to spawn it, 
    - and the spawner to determine the position
*/

public class CollisionSpawn : MonoBehaviour
{

    // Variables determining Spawnrate etc all public for dynamic increase possibility
    public float[] Spawnpositions = {6f, 2.5f, 0f, -2.5f, -4.5f};
    public float SpawnFrequency = 1.0f;
    public int SpawnAmount = 1;
    public int DifficultyStep = 3;

    // GameObjects of Collision Item and it's prefab (technically both variables are the same but one consistent is needed)
    public GameObject objectToSpawn;
    public GameObject CollisionInstance;
    
    private GameObject player;
    private PlayerInput playeScript;

    private GameObject background;
    private Background backgroundScript;

    private GameObject spawner;
    private GameObject despawner;

    private DespawnerGetScore despawnerScript;

    private Vector3 position = new Vector3(0, 0, 0);
    private Quaternion rotation = Quaternion.Euler(0, 0, 0);

    //private int score = 0;
   // private int minusScore = 0;
   

    void Start()
    {
        // get GameObject's
        spawner = GameObject.FindWithTag("Spawner");

        despawner = GameObject.FindWithTag("Despawner");
        despawnerScript = despawner.GetComponent<DespawnerGetScore>();

        player = GameObject.FindWithTag("Player");
        playeScript = player.GetComponent<PlayerInput>();

        background = GameObject.FindWithTag("Background");
        backgroundScript = background.GetComponent<Background>();

        // Invoke the function to spawn Collision elements
        InvokeRepeating("instance_of_object", 2.0f, SpawnFrequency);
      
    }

    void Update() {

        // Dynamically increase Spawnrate by reaching a certain Score

/*
        score = despawnerScript.ScoreCount;
        score = score - minusScore;

        

        if (score > DifficultyStep){

            Debug.Log(minusScore);
            
            // increase Spawn amount by 1
            //SpawnAmount++;

            // increase Gravity to counter the speed
            playeScript.GravityDifficultyMultiplier *= 1.5f;

            // increase Movement Speed of Elements, Background (multiply by 2)
            backgroundScript.scrollSpeed *= 1.1f;

            // set next threshold for increase
            minusScore = score;
            
        }
*/
    }

    // spawn an instance of the collider GameObject at the spawner 
    //position with a random offset according to rates dynamically set
    void instance_of_object(){

        // get position data of spawner
        position = position = spawner.transform.position;
        position.y = Spawnpositions[Random.Range(0, 5)];
       
        CollisionInstance = Instantiate(objectToSpawn, position, rotation);
        if (SpawnAmount > 1) {
            StartCoroutine(WaitForSpawning(SpawnFrequency, SpawnAmount));
        }

    }

    // wait for x amount of seconds, then reload to the main menu
    IEnumerator WaitForSpawning(float seconds, int spawnAmount){

        for (int i = 1; spawnAmount > i; i++){

            yield return new WaitForSecondsRealtime(seconds);

            CollisionInstance = Instantiate(objectToSpawn, position, rotation);

        }
        
    }

}
/*
    TODO:
    - What is the identifier of Quaternions and Vector3
*/

