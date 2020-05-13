using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float inputAccel;
  Vector2 input;
  Vector3 momentum;

  void Update()
  {
    input.x = Input.GetAxisRaw("Horizontal");
    input.y = Input.GetAxisRaw("Vertical");
  }

  void FixedUpdate()
  {
    momentum.x += input.x * inputAccel * Time.fixedDeltaTime;
    momentum.y += input.y * inputAccel * Time.fixedDeltaTime;
    transform.position += momentum;
  }
}
