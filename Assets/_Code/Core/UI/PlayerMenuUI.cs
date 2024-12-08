using System.Collections;
using Core.Concreates.Managers;
using Core.Concreates.UI;
using Core.NetWork;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerMenuUI : _UIMenubase
{
    public GameObject canvas;
    public TextMeshProUGUI text;

    public void Show()
    {
        canvas.SetActive(true);
        base.ShowCanvas();
    }

    public void CheckAlarm()
    {
        var alarmManager = FindFirstObjectByType<AlarmManager>();
        if (alarmManager.getAlarmStatus() == false)
        {
            text.text = "Alarm is COMPLETED";
        }
        else
        {
            text.text = "Alaram status";
        }
    }


    public void Reload()
    {
        LevelManager.ReloadCurrentScene();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("AlarmManager");
        foreach (var item in objs)
            Destroy(item);
    }

    public void Resume()
    {
        HideCanvas();
        canvas.SetActive(false);
    }

    public void Exit()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AlarmManager");
        foreach (var item in objs)
            Destroy(item);
        SceneManager.LoadScene(1);
    }
   
}
