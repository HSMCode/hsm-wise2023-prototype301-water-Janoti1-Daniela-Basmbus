using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public int CollisionCounter = 0;
    private TextMeshProUGUI ScoreText;

    private GameObject scoreTextObject;

    private GameObject despawner;
    private DespawnerGetScore despawnerScript;

    void Start() {
        scoreTextObject = GameObject.FindWithTag("Score");
        ScoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
    }

    // set the Score Number Text to the Active Score
    void Update()
    {
        ScoreText.text = getStoneCount().ToString();    
    }

    // get the Stone Count from the Despawner
    public int getStoneCount(){
        despawner = GameObject.FindWithTag("Despawner");
        despawnerScript = despawner.GetComponent<DespawnerGetScore>();

        return despawnerScript.ScoreCount;
    }
}
