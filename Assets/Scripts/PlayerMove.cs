using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float inputAccel;
  public Rigidbody2D rigidBody;
  Vector2 input;
  Vector2 momentum;

  void Update()
  {
    input.x = Input.GetAxisRaw("Horizontal");
    input.y = Input.GetAxisRaw("Vertical");
  }

  void FixedUpdate()
  {
    momentum.x += input.x * inputAccel * Time.fixedDeltaTime;
    momentum.y += input.y * inputAccel * Time.fixedDeltaTime;
    rigidBody.MovePosition(rigidBody.position + momentum);
  }
}
