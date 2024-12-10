using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnimationSystem
{
    [CreateAssetMenu(fileName = "UI_RefrenceProvidor")]
    public class UI_ReferencesProvidor : ScriptableObject
    {
        public Canvas RootCanvas;
        
        [SerializeField]
        private List<UI_Button> buttonReferences = new List<UI_Button>();
        public List<UI_Button> ButtonReferences => buttonReferences;
    }

    [System.Serializable]
    public class UI_Button
    {
        public Button button;
        public ButtonKey key;
    }
}
