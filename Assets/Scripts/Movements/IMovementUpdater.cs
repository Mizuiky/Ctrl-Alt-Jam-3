using UnityEngine;
using UnityEngine.Events;

namespace JAM.Movements {
  public interface IMovementUpdater {
    UnityEvent<Vector2> OnMovementVelocityNormal();
    UnityEvent<Vector2> OnMovementPositionNormal();
  }
}
