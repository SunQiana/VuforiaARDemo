using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AnimationSystem
{
    public class AnimationSystem : MonoBehaviour
    {
        [SerializeField]
        AnimationType type;
        AnimationSystemUtility utility;
        AnimationSystemUI ui;
        GameObject target;


        private void Awake()
        {
            if (type == null)
            {
                Debug.LogError("No Animation Type Is Assigned");
                return;
            }

            utility = new AnimationSystemUtility(type);
            ui = new();
        }

        private void Start()
        {
            utility.StartAnimation(1);
        }
    }
}
