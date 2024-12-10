using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AnimationSystem
{
    public class AnimationSystemUtility
    {
        const int BASE_MODEL_SCALE = 300;

        Animation animationPlayer;
        Dictionary<AnimationKey, AnimationClip> animations = new();

        public AnimationSystemUtility(AnimationDatas data)
        {
            LoadFromDatas(data);

            var target = SetTarget(data);
            LoadAnimations(target);

            SetEnable(false);
        }

        void LoadFromDatas(AnimationDatas data)
        {
            if (data == null)
            {
                Debug.LogError("Failed To Load Animation Data");
                return;
            }

            foreach (var item in data.Animations)
            {
                animations.Add(item.key, item.animation);
            }
        }

        GameObject SetTarget(AnimationDatas data)
        {
            if (data.BaseModel == null)
            {
                Debug.LogError("Base Model Is Null");
                return null;
            }

            var result = GameObject.Instantiate(data.BaseModel);
            result.transform.localScale = new Vector3(BASE_MODEL_SCALE, BASE_MODEL_SCALE, BASE_MODEL_SCALE);

            return result;
        }

        void LoadAnimations(GameObject target)
        {
            if (target.TryGetComponent<Animation>(out animationPlayer) == false)
            {
                animationPlayer = target.AddComponent<Animation>();
            }

            foreach (var item in animations)
            {
                AnimationKey key = item.Key;
                AnimationClip clip = item.Value;
                clip.wrapMode = WrapMode.Loop;

                animationPlayer.AddClip(clip, clip.name);
            }
        }

        public void StartAnimation(AnimationKey key)
        {
            if (animationPlayer == null)
            {
                Debug.LogError("Animation Component Is Null");
                return;
            }

            if (animationPlayer.gameObject.activeInHierarchy == false)
            {
                Debug.LogWarning("Base Model is not active, Start Animation has been returned");
                return;
            }

            animationPlayer.clip = animations[key];
            animationPlayer.Play();
        }

        public void SetEnable(bool condition)
        {
            animationPlayer.gameObject.SetActive(condition);
        }
    }

    public enum AnimationKey
    {
        ResetAction,
        Action1,
        Action2,
        Action3,
    }
}