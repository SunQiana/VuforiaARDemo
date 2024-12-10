using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationSystem
{
    [CreateAssetMenu(fileName = "AnimationData")]
    public class AnimationDatas : ScriptableObject
    {
        public GameObject BaseModel;

        [SerializeField]
        private List<AnimationData> animationDatas = new();
        public List<AnimationData> Animations => animationDatas;
    }

    [System.Serializable]
    public class AnimationData
    {
        public AnimationClip animation;
        public AnimationKey key;
    }
}
