using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core.Abstract.AlarmSystem
{
    public class AlarmScreen
    {
        private static AlarmScreen _instance;
        private TextMeshProUGUI MessageScreen;
        string message = string.Empty;


        private AlarmScreen(TextMeshProUGUI _screen)
        {
            MessageScreen = _screen;
        }

        public static AlarmScreen CreateInstance(TextMeshProUGUI _screen)
        {
            if (_instance == null)
                _instance = new AlarmScreen(_screen);
            return _instance;
        }
         public void Kill()
        {
            _instance = null;
        }


        public void Start()
        {
            MessageScreen.color = Color.yellow;
        }

        public void setColor(Color color)
        {
            MessageScreen.color = color;
        }

        public void print(string _message)
        {
            message = _message;
            Update();
        }

        public void clear()
        {
            message = string.Empty;
            Update();
        }

        public void Update()
        {
            MessageScreen.text = message;
        }

    }

}
