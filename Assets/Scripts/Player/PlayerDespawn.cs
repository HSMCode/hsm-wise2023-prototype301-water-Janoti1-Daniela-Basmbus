using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDespawn : MonoBehaviour
{
    // Time before return to Main Screen
    public float DeathScreenTime = 1f;

    // Variables for Player object and its animatior
    private GameObject player;
    private Animator anim; 

    // Variables to get the Background
    private GameObject[] background;
    private Background backgroundScript;

    // Variables to get Player Input
    private PlayerInput playerInputsControl;

    public AudioSource audioPlayer;


    void Start() {

        // Define Player Components
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();

        // Define Background Components
        background = GameObject.FindGameObjectsWithTag("Background");

        // Define PlayerInput Components
        playerInputsControl = player.GetComponent<PlayerInput>();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Collision")
        {
            // Trigger the Death Animation
            anim.SetTrigger("Death");

            audioPlayer.Play();

            // Stop the various Backdrops from Moving
            _stopBackground();

            // Stop Player Inputs
            playerInputsControl.playerInputs = false;

            // wait before going back to to Main Menu
            StartCoroutine(Wait(DeathScreenTime));
            //Destroy(objectToDespawn);

        }
    }
    
    // Stop the various Backdrops from Moving
    private void _stopBackground(){
        // Stop the Background from Moving
        for (int i = 0; i< background.Length; i++) {
            backgroundScript = background[i].GetComponent<Background>();
            backgroundScript.scrollSpeed = 0;
        }
    }

    // wait for x amount of seconds, then reload to the main menu
    IEnumerator Wait(float seconds){

        yield return new WaitForSecondsRealtime(seconds);

        // Reload Main Menu 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

/*
    TODO:
*/