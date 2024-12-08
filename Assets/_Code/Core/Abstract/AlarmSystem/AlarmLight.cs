using UnityEngine;

namespace Core.Abstract.AlarmSystem
{
    public class AlarmLight
    {
        GameObject[] lights;

        public AlarmLight(GameObject[] _lights)
        {
            lights = _lights;
            Stop();
        }

        public void Start()
        {
            setLight(true);
        }

        public void Stop()
        {
            setLight(false);
        }

        public bool getStatus()
        {
            return lights[0].active;
        }

        private void setLight(bool active)
        {
            foreach (var item in lights)
            {
                item.SetActive(active);
            }
        }
    }
}
