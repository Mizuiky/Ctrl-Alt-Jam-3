using System.Collections.Generic;
using UnityEngine;
using JAM.Movements;
using TMPro;
using System;
using JAM.Animations;
using JAM.InputManagement;

namespace JAM.Characters {

  [Serializable]
  public class CharacterComponents {
    
    #region Components Unity
    
    [field: SerializeField] public Rigidbody2D characterRigidbody2D { private set; get; }
    [field: SerializeField] public Animator characterAnimator { private set; get; }
    [field: SerializeField] public AnimatorController animatorController { private set; get; }
    [field: SerializeField] public SpriteRenderer spriteRenderer { private set; get; }
    [field: SerializeField] public InputHandler input { private set; get; }

    #endregion Components Unity

    #region Others components
    public CharacterBase character { private set; get; }
    public Movement movement { private set; get; }
    public Vector2 direction;

    #endregion

    public CharacterComponents( CharacterBase character ) {
      this.character = character;
      characterRigidbody2D = character.GetComponentInChildren<Rigidbody2D>();
      characterAnimator = character.GetComponentInChildren<Animator>();
      animatorController = character.GetComponentInChildren<AnimatorController>();
      spriteRenderer = character.GetComponentInChildren<SpriteRenderer>();
      movement = character.GetComponentInChildren<Movement>();
      input = character.GetComponent<InputHandler>();
    }

  }
}