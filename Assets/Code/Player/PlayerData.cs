using UnityEngine;

namespace testtask.sausage
{
    [CreateAssetMenu(fileName = "dataPlayer", menuName = "Data/dataPlayer")]
    public sealed class PlayerData :
        ScriptableObject
    {
        [Header("physics settings")]
        public float BaseForce;
        public float MaxForce;
        [Header("check grount settings")]
        public LayerMask GroundLayerMask;
        public float CheckDistance;
    }
}
