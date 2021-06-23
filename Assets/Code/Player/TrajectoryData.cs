using UnityEngine;


namespace testtask.sausage
{
    [CreateAssetMenu(fileName = "dataTrajectory", menuName = "Data/dataTrajectory")]
    public sealed class TrajectoryData :
        ScriptableObject
    {
        [Header("trajectory settings")]
        public float DistanceBtwPoints;
        public int PointsLenght;
    }
}