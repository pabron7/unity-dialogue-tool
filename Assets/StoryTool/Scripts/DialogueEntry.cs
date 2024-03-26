using UnityEngine;
using System;

[Serializable]
public class DialogueEntry
{
    // public ParticleSystem particleSystem;
    public string text;
    public string optionOneText;
    public GameObject optionOneBlock;
    public DialogueController.Characters character;
}