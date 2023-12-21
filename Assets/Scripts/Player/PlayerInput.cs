using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    // Variables for Player Components
    public GameObject player;
    private Rigidbody playerRigidBody;
    private Animator anim; 
    public AudioSource audioPlayer;
   

    // Jump Control Parameters
    public int JumpHeight = 30;
    public float GravityChange = -80; //for bigger impact and faster gameplay

    // Fly/ Gravity Control Parameters
    private float timer = 0;
    public float gravitydelay = 0.2f;
    public float gravitydown = -9.81f;
    public float gravityup = 9.81f;
    public float GravityDifficultyMultiplier = 1f;

    // Situation Check Variables
    public int checkpoint = 1;
    public bool playerInputs = true;
    private bool collide_with_enviroment = true;
    private bool gravity = true;
 
    void Start(){
        // Get Player Components
        playerRigidBody = player.GetComponent<Rigidbody>();
        anim = player.GetComponent<Animator>();
   
        
    }

    void Update()
    {

        // Checkpoint 0 = Just Jump
        if (checkpoint == 0 && playerInputs == true)
        {
            if (Input.GetButtonDown("Jump") && collide_with_enviroment == true) //no double jumps 
            {
                
                
                //player.transform.Translate(0, JumpHeight, 0, Space.World); //allows it to teleport through roof
                //playerRigidBody.velocity = new Vector3(0, JumpHeight, 0);

                // Adjust Jump Impact
                Physics.gravity = new Vector3(0, GravityChange * GravityDifficultyMultiplier, 0);

                // Jump
                playerRigidBody.AddForce(0, JumpHeight, 0, ForceMode.VelocityChange);
                
            }
        }

        // Checkpoint 1 = Fly
        if (checkpoint == 1 && playerInputs == true)  
        {
            gravitydown = -9.81f;
            gravityup = 9.81f; 

            if (Input.GetButton("Jump")) {

                audioPlayer.Play();
                
                timer += Time.deltaTime;

                if (timer > gravitydelay) {
                    //Change Gravity
                    Physics.gravity = new Vector3(0, gravityup, 0);
                    timer = 0;
                }

                // Enable Jump Animation (Return to Run Animation)
                anim.SetBool("Swim", true);

            }
            else {

                Physics.gravity = new Vector3(0, gravitydown, 0);

                // Disable Jump Animation (Return to Run Animation)
                anim.SetBool("Swim", false);
            }
        }

        //Checkpoint 2 = Change Gravity
        if (checkpoint == 2 && playerInputs == true) 
        {

            //gravitydown = gravitydown * 10;
            //gravityup = gravityup * 10;
            gravitydown = -900.81f;
            gravityup = 900.81f;


            if (collide_with_enviroment == true)
            {
                Debug.Log("collide");
                if (gravity == true)
                {
                    Debug.Log("gravity");
                    if (Input.GetButtonDown("Jump"))
                    {
                        Physics.gravity = new Vector3(0, gravityup, 0);
                        gravity = false;
                    }
                }
                if (gravity == false)
                { 
                    if (Input.GetButtonUp("Jump"))
                    {
                        Physics.gravity = new Vector3(0, gravitydown, 0);
                        gravity = true;                        
                    }
                }
            }
        }

    }

    // Check if Player Touches Floor or Roof
    void OnCollisionEnter (Collision collision)
    {
        if (collision.collider.tag == "Enviroment")
        {
            collide_with_enviroment = true;
        }

    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Enviroment")
        {
            collide_with_enviroment = false;
        }

    }
    
}
/*
    TODO:
    - Somehow Change public player to private.. 
    - when doing it the classic way I get "Object reference not set to an instance of an Object"
*/