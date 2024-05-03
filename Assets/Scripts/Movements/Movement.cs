using UnityEngine;
using JAM.Characters;

namespace JAM.Movements {
  
  [AddComponentMenu("JAM/Movements/Movement")]
  public class Movement : Singleton<Movement> {

    private CharacterBase _character;
    private Rigidbody2D _rigidbody2D;
    private IMovementUpdater _movementEntity;
    private Vector2 velocity;
    [field: SerializeField] private bool isAbility;
    [HideInInspector] public Vector2 currentPosition { get; private set; }

    public void Awake() {
      _character = GetComponent<CharacterBase>();
      _movementEntity = _character.characterEvents;
      _movementEntity.OnMovementVelocityNormal().AddListener(OnMovementVelocityNormal);
      _movementEntity.OnMovementPositionNormal().AddListener(OnMovementPositionNormal);
    }
    private void Start() {
      _rigidbody2D = _character.characterComponents.characterRigidbody2D;
    }

    public void OnDisableAbility() {
      isAbility = false;
    }
    public void OnMovementVelocityNormal(Vector2 velocity) {
      if( !isAbility ) {
        this.velocity = velocity;
        Move();
      }
    }
    
    public void OnMovementPositionNormal(Vector2 velocity) {
      if( !isAbility ) {
        this.velocity = velocity;
        MovePosition();
      }
    }

    private void Move() {
      _rigidbody2D.velocity = velocity;
    }
    private void MovePosition() {
      _rigidbody2D.MovePosition(velocity);
    }

    private void OnDestroy() {
      _movementEntity?.OnMovementVelocityNormal()?.RemoveListener(OnMovementVelocityNormal);
      _movementEntity?.OnMovementPositionNormal()?.RemoveListener(OnMovementPositionNormal);
    }
    
  }
}
