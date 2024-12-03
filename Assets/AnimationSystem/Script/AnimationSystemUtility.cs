using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AnimationSystem
{
    public class AnimationSystemUtility
    {
        Animator animator;
        AnimationData data;
        public AnimationSystemUtility(AnimationData type)
        {
            this.data = type;

            if (type.animations == null || type.BaseModel == null)
            {
                Debug.LogError($"Something In AnimationType {type.name} Is Null");
            }

            var animationTarget = GameObject.Instantiate(type.BaseModel);
            animator = animationTarget.AddComponent<Animator>();
        }

        public void StartAnimation(int index)
        {
            if (animator == null)
            {
                Debug.LogError("Animator Is Null");
                return;
            }

            if (data.animations.Count >= index || data.animations[index] == null)
            {
                Debug.LogError($"No Such A Animation Exist Index:{index}");
                return;
            }

            string animationClipName = data.animations[index].name;
            animator.Play(animationClipName);
        }
    }
}