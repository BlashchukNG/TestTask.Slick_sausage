using UnityEngine;


namespace gig.fps
{
    public sealed class UIController :
        IController
    {
        public Transform MainCanvas { get; set; }

        public UIController(Transform mainCanvas)
        {
            MainCanvas = mainCanvas;
        }
    }
}

