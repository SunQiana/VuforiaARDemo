using UnityEngine;
using Vuforia;
using System.Reflection;
using System;

namespace AnimationSystem
{
    public class AnimationSystem : MonoBehaviour
    {
        [SerializeField]
        AnimationDatas data;

        AnimationSystemUtility utility;
        AnimationSystemUI ui;
        UI_ReferencesProvidor providor;

        ObserverBehaviour observerBehaviour;

        private void Awake()
        {
            LoadDatas();
            FindObserverBehaviourInstance();
        }

        private void Start()
        {
            BindBtns();
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        void LoadDatas()
        {
            if (data == null)
            {
                Debug.LogError("No Animation Type Is Assigned");
                return;
            }

            providor = Resources.Load<UI_ReferencesProvidor>("UI_RefrenceProvidor");

            if (providor == null)
            {
                Debug.LogError("UI Refrence Providor Is Not Found");
                return;
            }

            utility = new AnimationSystemUtility(data);
            ui = new AnimationSystemUI(providor);

            return;
        }

        void FindObserverBehaviourInstance()
        {
            Type type = typeof(ObserverBehaviour);
            GameObject[] gos = FindObjectsOfType<GameObject>();

            foreach (var go in gos)
            {
                if (go.TryGetComponent<ObserverBehaviour>(out var result))
                {
                    observerBehaviour = result;
                }
            }
        }

        void OnTargetStatusChanged(ObserverBehaviour observerbehavour, TargetStatus status)
        {
            if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
            {
                SetEnable(true);
                return;
            }

            if (status.Status == Status.EXTENDED_TRACKED && status.StatusInfo == StatusInfo.NORMAL)
            {
                SetEnable(true);
                return;
            }

            SetEnable(false);
        }

        void SetEnable(bool condition)
        {
            if (ui == null || utility == null)
            {
                Debug.LogError($"Faild To Set {condition} because ui or utility is null ");
                return;
            }

            ui.SetEnable(condition);
            utility.SetEnable(condition);

            if (condition)
                utility.StartAnimation(AnimationKey.ResetAction);
        }

        void BindBtns()
        {
            ui.BindButton(() => utility.StartAnimation(AnimationKey.ResetAction), ButtonKey.ResetAction);
            ui.BindButton(() => utility.StartAnimation(AnimationKey.Action1), ButtonKey.Action1);
            ui.BindButton(() => utility.StartAnimation(AnimationKey.Action2), ButtonKey.Action2);
            ui.BindButton(() => utility.StartAnimation(AnimationKey.Action3), ButtonKey.Action3);
        }

    }
}
