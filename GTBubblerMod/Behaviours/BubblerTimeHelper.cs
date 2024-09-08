using UnityEngine;

namespace GTBubblerMod.Behaviours
{
    [RequireComponent(typeof(Bubbler))]
    public class BubblerTimeHelper : MonoBehaviour
    {
        public float Timestamp
        {
            get => bubbler.bubblerAudio.time;
            set => bubbler.bubblerAudio.time = value;
        }

        public bool Activated => bubbler.bubblerAudio.isPlaying;

        private Bubbler bubbler;
        private float lastTimestamp;
        private bool lastActivated;

        public void Awake()
        {
            bubbler = GetComponent<Bubbler>();
            lastTimestamp = Timestamp;
            lastActivated = Activated;
        }

        public void LateUpdate()
        {
            if (Activated && lastActivated == Activated)
            {
                lastTimestamp = Timestamp;
            }
            else if (!Activated && lastActivated != Activated)
            {
                Timestamp = lastTimestamp;
            }

            lastActivated = Activated;
        }
    }
}
