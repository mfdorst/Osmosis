using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float inputAccel;
  public Rigidbody2D rigidBody;

  Vector2 input;

  void Start()
  {
    rigidBody = GetComponent<Rigidbody2D>();
    rigidBody.mass = transform.localScale.x;
  }

  void Update()
  {
    input.x = Input.GetAxisRaw("Horizontal");
    input.y = Input.GetAxisRaw("Vertical");
  }

  void FixedUpdate()
  {
    rigidBody.AddForce(input * inputAccel);
  }
}
