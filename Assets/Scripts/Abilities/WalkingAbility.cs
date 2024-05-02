using UnityEngine;

namespace JAM.Abilites {

  [DisallowMultipleComponent]
  public class WalkingAbility : Ability<WalkingAbility> {

    public override void Enter(){
      base.Enter();
      // TODO: add some logic
    }
    public override void HandleInput(){
      base.HandleInput();
      // TODO: add some logic for input
    }
    public override void HandleAbility(){
      base.HandleAbility();
      // TODO: add some logic for ability in loop
    }
    public override void PhysicsUpdate(){
      base.PhysicsUpdate();
      // TODO: add some logic for physics
    }
    public override void Exit(){
      base.Exit();
      // TODO: add some logic
    }
  }
}