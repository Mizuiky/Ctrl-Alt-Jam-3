using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JAM.Movements;
using System;

namespace JAM.Characters {

  [Serializable]
  public class CharacterData {
    
    [field: SerializeField]
    [Tooltip("Character sprite render.")]
    public Sprite characterSpriteRender;

    [SerializeField]
    [Tooltip("Character Type.")]
    public CharacterType characterType;

    [SerializeField]
    [Range(0, 2)]
    [Tooltip("Direction for character.")]
    public int characterAnimationDirection = 2;

    [SerializeField]
    [Range(0, 10)]
    [Tooltip("Maximum speed for character.")]
    public float currentVelocity = 0;

    [SerializeField]
    [Range(0, 10)]
    [Tooltip("Maximum speed for character.")]
    public float originMaxSpeed = 0;
    
    [SerializeField]
    [Tooltip("Maximum speed for character.")]
    public Vector2 movementInput = Vector2.zero;

    [SerializeField]
    [Range(0, 1000)]
    [Tooltip("Maximum speed for character.")]
    public float maxSpeed = 5;

    [SerializeField]
    [Range(0.1f, 100)]
    [Tooltip("Acceleration speed for character.")]
    public float acceleration = 20;

    [SerializeField]
    [Range(0.1f, 100)]
    [Tooltip("Deceleration speed for character.")]
    public float deceleration = 20;

    public CharacterData( ) {
      originMaxSpeed = maxSpeed;
    }
  }
}