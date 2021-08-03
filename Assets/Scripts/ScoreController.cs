using UnityEngine;
using TMPro;
public sealed class ScoreController : MonoBehaviour
{
    [SerializeField] private int _score;
    private int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            ScoreText.text = string.Format(ScoreTextFormat, _score);
        }
    }
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI LooseScreenScoreText;

    [SerializeField, Multiline] private string ScoreTextFormat;
    [SerializeField, Multiline] private string LooseScreenScoreTextFormat;

    public static ScoreController instance { get; private set; }

    private void Awake() => instance = this;
    private void Start()
    {
        Score = 0;

        InvokeRepeating("UpdateScore", 1, 1);
    }
    private void UpdateScore()
    {
        if (Settings.IsPlaying)
            Score++;
    }
    public void UpdateLooseScreenScore()
    {
        LooseScreenScoreText.text = string.Format(LooseScreenScoreTextFormat, Score);
    }
}
