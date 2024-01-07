using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int CollisionCounter = 0;
    private TextMeshProUGUI ScoreText;

    private void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
        UpdateScoreText();
    }

    void Update()
    {
        ScoreText.text = getStoneCount().ToString();    
    }

    public int getStoneCount()
    {
        return CollisionCounter;
    }

    public void IncreaseScore()
    {
        CollisionCounter++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        ScoreText.text = CollisionCounter.ToString();
    }
}
