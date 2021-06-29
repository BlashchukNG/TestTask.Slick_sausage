using UnityEngine;

namespace testtask.sausage
{
    [CreateAssetMenu(fileName = "dataControllerData", menuName = "Data/dataControllerData")]
    public sealed class ColorControllerData :
        ScriptableObject
    {
        public Color[] Colors;
    }
}
