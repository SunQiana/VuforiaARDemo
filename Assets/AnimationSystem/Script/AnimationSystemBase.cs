using System.Collections;
using UnityEngine;

namespace AnimationSystem
{
    public class AnimationSystemBase
    {
        public virtual void OnAwake() { }
        public virtual void OnStart() { }
        public virtual void OnAnimationPlay() { }
        public virtual void OnUpdate() { }
        public virtual void OnAnimationStop() { }
        public virtual void OnDestroy() { }
    }
}
