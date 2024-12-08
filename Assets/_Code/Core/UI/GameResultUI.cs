using System.Collections;
using Core.Concreates.Managers;
using Core.Concreates.UI;
using Core.NetWork;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResultUI : _UIMenubase
{
    public GameObject canvas;
    public TextMeshProUGUI text;
    int score;
    int star;

    [SerializeField]
    GameObject star1;

    [SerializeField]
    GameObject star2;

    [SerializeField]
    GameObject star3;

    public void Show(int _score, int _star)
    {
        base.ShowCanvas();
        score = _score;
        star = _star;
        canvas.SetActive(true);     
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        ShowResult();
    }
    private void ShowResult()
    {
        if (score == 0)
            text.text = "GAME OVER";
        else
        {
            text.text = "Score = " + score;
            if (star >= 1)
                star1.SetActive(true);
            if (star >= 2)
                star2.SetActive(true);
            if (star == 3)
                star3.SetActive(true);
        }
        StartCoroutine(Post(score, star));
    }

    public void Reload()
    {
        LevelManager.ReloadCurrentScene();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("AlarmManager");
        foreach (var item in objs)
            Destroy(item);
    }

    public void Exit()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AlarmManager");
        foreach (var item in objs)
            Destroy(item);
        SceneManager.LoadScene(1);
    }
  
    public IEnumerator Post(int Score, int star)
    {
        string result = null;
        var address = $"{NetworkConst.URL}/{NetworkConst.AddScore}";
        var body =
            "{\"username\":\""
            + UserManager.UserName
            + "\", \"userId\":"
            + UserManager.UserId
            + ", \"scenarioNumber\":"
            + LevelManager.GetScenarioNumber()
            + ", \"score\":"
            + Score
            + ", \"scoreStar\":"
            + star
            + "}";
        Debug.Log(body);
        using (UnityWebRequest w = UnityWebRequest.Post(address, body, "application/json"))
        {
            yield return w.SendWebRequest();
            if (w.result == UnityWebRequest.Result.Success)
            {
                result = w.downloadHandler.text;
                Debug.Log("result" + result);
            }
            else
            {
                Debug.Log(w.error);
            }
        }
    }
}
