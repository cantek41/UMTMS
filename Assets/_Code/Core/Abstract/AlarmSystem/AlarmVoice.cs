using System.Collections.Generic;
using UnityEngine;

namespace Core.Abstract.AlarmSystem
{
    public class AlarmVoice
    {
        private List<AudioSource> alarmSource;
        private AlarmVoice(GameObject[] _alarmObject)
        {
            alarmSource = new();
            foreach(var item in _alarmObject)
                alarmSource.Add(item.GetComponent<AudioSource>());
        }

        private static AlarmVoice _instance;

        public static AlarmVoice CreateInstance(GameObject[] _alarmObject)
        {
            if (_instance == null)
                _instance = new AlarmVoice(_alarmObject);
            return _instance;
        }
        public void Kill()
        {
             Stop();
            _instance = null;
        }

        public void Start()
        {
            setHorns(true);
        }

        public void Stop()
        {
            setHorns(false);
        }
        private void setHorns(bool active)
        {
            foreach (var item in alarmSource)
                if (!active) item.Stop(); else if (!item.isPlaying) item.Play();
        }
    }
}