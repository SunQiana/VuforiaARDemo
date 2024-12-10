using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace AnimationSystem
{
    public class AnimationSystemUI
    {
        Canvas root;
        Dictionary<ButtonKey, Button> btns = new();

        public AnimationSystemUI(UI_ReferencesProvidor providor)
        {
            SpawnUI(providor);

            SetEnable(false);
        }

        void SpawnUI(UI_ReferencesProvidor providor)
        {
            if (providor == null)
            {
                Debug.LogError("ReferencesProvidor is null");
                return;
            }

            root = GameObject.Instantiate(providor.RootCanvas);

            var btnsReferences = providor.ButtonReferences;

            foreach (var item in btnsReferences)
            {
                Button btn = GameObject.Instantiate(item.button, root.transform);
                btns.Add(item.key, btn);
            }
        }

        public void BindButton(Action action, ButtonKey key)
        {
            if (action == null)
            {
                Debug.LogError("One of Action is null when trying to bind");
                return;
            }

            if (btns.ContainsKey(key) == false)
            {
                Debug.LogError("One of Button Is Unknown when trying to bind");
                return;
            }

            Button btn = btns[key];
            btn.onClick.AddListener(() => action.Invoke());
        }

        public void SetEnable(bool condition)
        {
            root.gameObject.SetActive(condition);
        }
    }

    public enum ButtonKey
    {
        ResetAction,
        Action1,
        Action2,
        Action3,
    }
}





