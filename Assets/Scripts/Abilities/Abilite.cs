using UnityEngine;
using JAM.Characters;
using JAM.InputManagement;

namespace JAM.Abilites {

  public interface IAbility {
    void Enter();
    void HandleInput();
    void InternalInput();
    void HandleAbility();
    void PhysicsUpdate();
    void Exit();
  }

  public enum AbiliteState {
    Ready,
    Active,
    Cooldown
  }

  public abstract class Ability<T> : MonoBehaviour, IAbility {

    private string abilityName = typeof(T).Name.Replace("Ability", "");
    [field: SerializeField] protected AbiliteState state = AbiliteState.Ready;
    [field: SerializeField] protected float cooldownTime;
    [field: SerializeField] protected float activeTime;

    protected CharacterBase character;
    protected InputHandler input;

    private void Awake() {
      character = GetComponent<CharacterBase>();
      input = character.characterComponents.input;
    }
    public virtual void Enter(){}
    public virtual void Exit(){}
    public virtual void PhysicsUpdate(){}
    public virtual void HandleAbility(){}
    public virtual void HandleInput(){}
    public virtual void InternalInput(){}
    public virtual void ValidateCooldown() {
      switch (state) {
        case AbiliteState.Ready:
          state = AbiliteState.Active;
        break;
        case AbiliteState.Active:
          state = AbiliteState.Cooldown;
        break;
        case AbiliteState.Cooldown:
          if( cooldownTime >=0 ) {
            cooldownTime -= Time.deltaTime;
            return;
          }
          state = AbiliteState.Ready;
        break;
      }
    }

  }
}