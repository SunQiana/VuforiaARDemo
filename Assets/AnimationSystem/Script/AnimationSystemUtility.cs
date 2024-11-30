using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AnimationSystem
{
    public class AnimationSystemUtility
    {
        Animator animator;
        AnimationType type;
        public AnimationSystemUtility(AnimationType type)
        {
            this.type = type;
            if (type.animations == null || type.BaseModel == null)
            {
                Debug.LogError($"Something In AnimationType {type.name} Is Null");
            }

            var animationTarget = GameObject.Instantiate(type.BaseModel);
            animator = animationTarget.AddComponent<Animator>();
        }

        public void StartAnimation(int index)
        {
            if (type.animations[index] == null)
            {
                Debug.LogError($"Animation Clip In AnimationType {type.name} Is Null");
                return;
            }

            string animationClipName = type.animations[index].name;
            animator.Play(animationClipName);
        }
    }
}