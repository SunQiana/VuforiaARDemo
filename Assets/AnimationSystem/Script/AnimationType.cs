using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationType")]
public class AnimationType : ScriptableObject
{
    public GameObject BaseModel;
    public List<Animation> animations = new();
}
