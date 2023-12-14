using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreMainMenu : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;
    private GameObject highScoreTextObject;

    private PlayerPrefsX playerPrefsX;
    private GameObject scriptMasterEmpty;

    private string highscore = "highscore";

    void Start(){
        // get the Highscore Text element
        highScoreTextObject = GameObject.FindWithTag("Highscore");
        highScoreText = highScoreTextObject.GetComponent<TextMeshProUGUI>();

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
}
