using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace AnimationSystem
{
    public class AnimationSystem : MonoBehaviour
    {
        [SerializeField]
        AnimationData data;
        AnimationSystemUtility utility;
        AnimationSystemUI ui;
        GameObject target;


        private void Awake()
        {
            if (TryInit())
            {
                utility = new AnimationSystemUtility(data);
                ui = new();
            }
        }

        bool TryInit()
        {
            if (data == null)
            {
                Debug.LogError("No Animation Type Is Assigned");
                return false;
            }

            if(transform.TryGetComponent<AnimationSystemUI>(out ui) == false)
            {
                Debug.LogError("UI Rect Is Null");
                return false;
            }

            return true;
        }


    }
}
