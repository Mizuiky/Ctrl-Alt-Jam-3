using UnityEngine;
using UnityEngine.Events;
using JAM.Movements;
using System;


namespace JAM.Characters {

  [Serializable]
  public class CharacterEvents : IMovementUpdater {
    private CharacterBase character;
    public virtual UnityEvent<Vector2> OnMovementVelocityNormal() => character.movementVelocityNormal;
    public virtual UnityEvent<Vector2> OnMovementPositionNormal() => character.movementPositionNormal;

    public CharacterEvents( CharacterBase character ) {
      this.character = character;
    }
  }
}