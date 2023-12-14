using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Highscore : MonoBehaviour
{

    private TextMeshProUGUI highScoreText;
    private GameObject highScoreTextObject;

    private Score ScoreTextScript;
    private GameObject scoreTextObject;

    private PlayerPrefsX playerPrefsX;
    private GameObject scriptMasterEmpty;

    private string highscore = "highscore";
    private int highscoreNumber = 0;

    void Start() {

        // get the Highscore Text element
        highScoreTextObject = GameObject.FindWithTag("Highscore");
        highScoreText = highScoreTextObject.GetComponent<TextMeshProUGUI>();

        // get the Score Script
        scoreTextObject = GameObject.FindWithTag("Score");
        ScoreTextScript = scoreTextObject.GetComponent<Score>();

        // get the Player Pref Script
        scriptMasterEmpty = GameObject.FindWithTag("ScriptEmpty");
        playerPrefsX = scriptMasterEmpty.GetComponent<PlayerPrefsX>();

        // create playerpref entry for the first time
        if (playerPrefsX.GetPlayerPrefs(highscore) == 0) {
            playerPrefsX.SetSavePrefs(highscore, 0);
        }
    
        // write highscore to text
        highScoreText.text = playerPrefsX.GetPlayerPrefs(highscore).ToString();

    }

    void Update()
    {
        // set highscore = score if score > highscore
        if (ScoreTextScript.getStoneCount() > playerPrefsX.GetPlayerPrefs(highscore)){
            highScoreText.text = ScoreTextScript.getStoneCount().ToString();
        }

        // Save the highscore
        if (highscoreNumber != _setHighscore()){
            highscoreNumber = _setHighscore();
            playerPrefsX.SetSavePrefs(highscore, highscoreNumber);
        }
    }

    // compare scores and return highscore
    private int _setHighscore(){
        int highscoreNumber = 0;

        if (ScoreTextScript.getStoneCount() > playerPrefsX.GetPlayerPrefs(highscore)){
            highscoreNumber = ScoreTextScript.getStoneCount();
        }
        else {
            highscoreNumber = playerPrefsX.GetPlayerPrefs(highscore);
        }

        return highscoreNumber;
    }
}
