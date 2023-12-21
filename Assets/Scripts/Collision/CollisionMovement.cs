using UnityEngine;


public class CollisionMovement : MonoBehaviour
{
 /*   
    public float MovementSpeed = 1f;
    
    public GameObject spawner;

    //private int counter =  0;

    void Start(){

        // get Obstacle and Background GameObject's
        //collisionObject = GameObject.FindWithTag("Collision");
        
       spawner.transform.Translate(Vector3.left*MovementSpeed*Time.deltaTime, Space.World);


    }
    
    void Update()
    {

      

    }

    void FixedUpdate() {

    }



/*
/*
    TODO:
    - Fix Collision Objects getting faster and faster
*/


 public float MovementSpeedMultiplier = 50;

    // public because it has to be set to 0 when the player dies
    //[HideInInspector] 
    public float MovementSpeed = -0.025f;
    private float MovementSpeedCheck = -0.025f;
    
    //public float speed;
    private Vector3 collisionForce = new Vector3(0, 0, 0); 

    // Reference Collision Object
    //private GameObject collisionObject;
    private CollisionSpawn collisionInstance;
    private Rigidbody collisionObjectRigid;
    
    // Reference Background
    private GameObject background;
    private Background backgroundScript;

    // Reference Spawner
    private GameObject spawner;

    //private int counter =  0;

    void Start(){

        // get Obstacle and Background GameObject's
        //collisionObject = GameObject.FindWithTag("Collision");
        
        spawner = GameObject.FindWithTag("Spawner");
        collisionInstance = spawner.GetComponent<CollisionSpawn>();
        collisionObjectRigid = collisionInstance.CollisionInstance.GetComponent<Rigidbody>();

        background = GameObject.FindWithTag("Background");

        // get specific Components of GameObject's
        //collisionObjectRigid = collisionInstance.GetComponent<Rigidbody>();
        backgroundScript = background.GetComponent<Background>();

        // get the speed of the Background
        collisionForce.x = (MovementSpeed*(-1)) * MovementSpeedMultiplier;

        // set the CollisionObjects Speed to the Backgrounds Speed
        collisionObjectRigid.AddForce(collisionForce, ForceMode.VelocityChange);

    }
    
    void Update()
    {

        MovementSpeed = backgroundScript.scrollSpeed;

        if (MovementSpeed != MovementSpeedCheck){
            // get the speed of the Background
            collisionForce.x = (MovementSpeed*(-1)) * MovementSpeedMultiplier;

            // set the CollisionObjects Speed to the Backgrounds Speed
            collisionObjectRigid.AddForce(collisionForce, ForceMode.VelocityChange);

            MovementSpeedCheck = MovementSpeed;
        }

    }

    void FixedUpdate() {

    }
}