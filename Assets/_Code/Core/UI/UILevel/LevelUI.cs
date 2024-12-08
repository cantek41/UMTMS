using System.Collections;
using Core.Abstract;
using Core.Base;
using Core.Concreates.Component.Base;
using Core.Concreates.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    private int index;
    public TextMeshProUGUI title;
    public TextMeshProUGUI time;
    public TextMeshProUGUI info;
    public TextMeshProUGUI url;
    public GameObject loading;

    private void Start()
    {
        LevelManager.ReadAllScenario();
        loading.SetActive(false);
        ScenarioLoad(0);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Debug.Log(UserManager.UserId);
        Debug.Log(UserManager.UserName);
    }

    public void ScenarioLoad(int _index)
    {
        try
        {
            index = _index;
            var scenario = LevelManager.GetScenario(_index);
            title.text = scenario.title;
            info.text = string.Format("Scenario {0} :\n {1}", index + 1, scenario.description);
            url.text = scenario.DocLink;
            time.text = ((int)scenario.time).ToString();
        }
        catch { }
    }

    public void Play()
    {
        loading.SetActive(true);
        LevelManager.SetActiveScenarioNumber(index);
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoWebSite(string _url)
    {
        Application.OpenURL(url.text);
    }
}
