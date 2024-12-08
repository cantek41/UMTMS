using System.ComponentModel;

public class ScoreManager
{
    private static ScoreManager _instance;

    public static ScoreManager CreateInstance()
    {
        if (_instance == null)
            _instance = new();
        return _instance;
    }

    private ScoreManager() { }

    private int Score;

    public void SetDefault()
    {
        Score = 100;
    }

    public void Fault(int val)
    {
        if (Score - val >= 0)
            Score -= val;
    }

    public int GetScore()
    {
        return Score;
    }

    public int CalcScore(float timeRate)
    {
        if (timeRate == 0)
            Score = 0;
        if (timeRate < 0.20)
        {
            Score += 10;
        }
        else if (timeRate < 0.30)
        {
            Score -= 5;
        }
        else if (timeRate < 0.50)
        {
            Score -= 10;
        }
        else if (timeRate < 0.70)
        {
            Score -= 15;
        }
        else if (timeRate < 0.80)
        {
            Score -= 20;
        }
        Score = Score > 100 ? 100 : Score;
        Score = Score < 0 ? 0 : Score;
        return Score;
    }

    public int CalcStar()
    {
        int star = 0;
        if (Score < 10)
        {
            star = 0;
        }
        else if (Score < 50)
        {
            star = 1;
        }
        else if (Score < 80)
        {
            star = 2;
        }
        else
        {
            star = 3;
        }
        return star;
    }
}
