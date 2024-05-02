using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AM.Abilites {


  [AddComponentMenu("JAM/Abilities/Abilite Manager")]
  [DisallowMultipleComponent]

  public sealed class AbilityManager : MonoBehaviour {

    List<IAbility> _abilities = new List<IAbility>();

    void OnValidate() {
      _abilities.Clear();
      _abilities = GetComponents<IAbility>().ToList();
    }

    private void Awake() {
      enabled = false;
      _abilities = GetComponents<IAbility>().ToList();
    }

    private void Start() {
      foreach (IAbility ability in _abilities) {
        ability.Enter();
        ability.HandleInput();
        ability.InternalInput();
      }
    }

    private void Update() {
      foreach (IAbility ability in _abilities) {
        ability.HandleAbility();
      }
    }

    private void FixedUpdate(){
      foreach (IAbility ability in _abilities) {
        ability.PhysicsUpdate();
      }
    }
    
    private void OnDisable() {
      OnApplicationQuit();
    }

    private void OnDestroy() {
      OnApplicationQuit();
    }

    private void OnApplicationQuit() {
      foreach (IAbility ability in _abilities) {
        ability.Exit();
      }
    }

  }
}