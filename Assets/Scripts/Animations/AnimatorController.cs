using System.Collections.Generic;
using JAM.Characters;
using UnityEngine;

namespace JAM.Animations {
  
  [AddComponentMenu("JAM/Animator/Animator Controller")]
  [RequireComponent(typeof(CharacterBase))]
  [DisallowMultipleComponent]
  public class AnimatorController : MonoBehaviour {
    
    private Animator animator;
    private CharacterBase character;
    private readonly List<string> directions = new List<string> () {"N", "NW", "W", "SW", "S", "SE", "E", "NE"};
    private string facingDirection = "N";
    string animationName;

    void Awake() {
      character = GetComponent<CharacterBase>();
      animator = character.characterComponents.characterAnimator;
    }

    public void Play( Vector2 direction ) {
      if( direction == Vector2.zero ) {
        animationName = "Idle";
      }else if( direction != Vector2.zero || direction.magnitude != 0) {
        animationName = "Walk";
        int faceDirectionIndex = DirectionToIndex(direction);
        facingDirection = directions[faceDirectionIndex];
      }
      animator.Play(animationName + " " +  facingDirection);
    }

    private int DirectionToIndex (Vector2 _direction, int sliceCount = 8) {
      Vector2 norDir = _direction;
      float step = 360 / sliceCount;
      float offset = step / 2;
      float angle = Vector2.SignedAngle (Vector2.up, norDir);
      angle += offset;
      if (angle < 0) {
        angle += 360;
      }
      float stepCount = angle / step;
      return Mathf.FloorToInt (stepCount);
    }
  }
}