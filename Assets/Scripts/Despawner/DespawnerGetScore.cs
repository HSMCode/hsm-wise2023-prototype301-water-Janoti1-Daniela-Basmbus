using UnityEngine;

public class DespawnerGetScore : MonoBehaviour
{
    public int ScoreCount = 0;

    void OnCollisionEnter (Collision collision){
        if (collision.collider.tag == "Collision")
        {
            ScoreCount++;
        }
    }

}
