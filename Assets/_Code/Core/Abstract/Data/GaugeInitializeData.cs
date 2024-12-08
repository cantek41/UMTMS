using UnityEngine;

namespace Core.Abstract.Data
{
[CreateAssetMenu(fileName = "GaugeData", menuName = "ScriptableObjects/Gauge")]
    public class GaugeInitializeData : ScriptableObject
    {
        public float minVal = 0;
        public float maxVal = 0.6f;
        public float minAngle = -128;
        public float totalAngle = -256;

    }
}