using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationSystem
{
    [CreateAssetMenu(fileName = "AnimationData")]
    public class AnimationData : ScriptableObject
    {
        public GameObject BaseModel;
        public List<Animation> animations = new();
    }
}
