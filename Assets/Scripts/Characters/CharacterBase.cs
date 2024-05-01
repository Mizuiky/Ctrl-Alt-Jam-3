using UnityEngine;
using UnityEngine.Events;
using System;

namespace JAM.Characters {

  public enum CharacterType {
    Player,
    IA,
    NPC,
  }

  [Serializable]
  public abstract class CharacterBase : MonoBehaviour {
    
    [HideInInspector] public CharacterEvents characterEvents;
    [HideInInspector] public UnityEvent<Vector2> movementVelocityNormal;
    [HideInInspector] public UnityEvent<Vector2> movementPositionNormal;
    [HideInInspector] public UnityEvent<Vector2> movementVelocityAbility;
    [HideInInspector] public UnityEvent<Vector2> movementPositionAbility;
    [HideInInspector] public UnityEvent disableAbility;
    
    [Tooltip("Sets character data.")]
    public CharacterData characterData;
    
    [Tooltip("Gets character components.")]
    public CharacterComponents characterComponents;

    public virtual void Awake() {
      LoadComponents();
    }

    private void LoadComponents() {
      characterComponents = new CharacterComponents(this);
      characterData = new CharacterData();
      characterEvents = new CharacterEvents(this);
    }


    private void OnValidate() {
      LoadComponents();
    }
    
  }
}