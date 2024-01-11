using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private bool spacePressed = false;
    private float spacePressTime = 0f;
    private float waitTime = 0.3f;
    private bool canQuit = false;
    public float holdTimeToQuit = 3f;

    public Slider holdSlider; // Der Slider f�r die visuelle Darstellung des Haltens

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
            spacePressTime = Time.time;
            canQuit = false; // Zur�cksetzen, um das erneute Dr�cken zu erm�glichen
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            spacePressed = false;
            if (Time.time - spacePressTime <= waitTime)
            {
                ConfirmFunction();
            }
            else
            {
                // Falls die Leertaste vor Ablauf der Zeit losgelassen wird, Slider zur�cksetzen
                UpdateSlider(0f);
            }
        }

        if (spacePressed && Time.time - spacePressTime > waitTime + 0.02f)
        {
            HoldFunction();
        }

        if (spacePressed && Time.time - spacePressTime >= holdTimeToQuit)
        {
            if (!canQuit)
            {
                QuitGame();
                canQuit = true;
            }
        }
    }

    void ConfirmFunction()
    {
        Debug.Log("Starte n�chste Szene!");
        LoadNextScene();
    }

    void HoldFunction()
    {
        Debug.Log("Space-Taste gehalten!");
        
        // Berechne den Fortschritt des Haltens als Normalized Value (0 bis 1)
        float holdProgress = Mathf.Clamp01((Time.time - spacePressTime - waitTime) / (holdTimeToQuit - waitTime));

        // Aktualisiere den Slider entsprechend
        UpdateSlider(holdProgress);
    }

    void UpdateSlider(float value)
    {
        if (holdSlider != null)
        {
            holdSlider.value = value;
        }
    }

    void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    void LoadNextScene()
    {
        // Hier die Indexnummer der n�chsten Szene in der Build Settings einstellen
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // �berpr�fe, ob es eine n�chste Szene gibt
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene available.");
        }
    }
}