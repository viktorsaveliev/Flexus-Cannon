using System;

namespace FlexusCannon.CameraSystem
{
    [Serializable]
    public struct CameraShakeContext
    {
        public float Amplitude;
        public float Frequency;
        public float Duration;
    }
}
