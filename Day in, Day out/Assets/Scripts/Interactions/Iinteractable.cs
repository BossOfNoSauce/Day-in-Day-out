using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iinteractable
{
   [SerializeField] string InteractionPrompt { get; }
   [SerializeField] bool Interact(Interactor interactor);
}
