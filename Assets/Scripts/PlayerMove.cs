using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float inputAccel = 10;
  new Rigidbody2D rigidbody;

  Vector2 input;

  void Start()
  {
    rigidbody = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    input.x = Input.GetAxisRaw("Horizontal");
    input.y = Input.GetAxisRaw("Vertical");
  }

  void FixedUpdate()
  {
    rigidbody.mass = transform.localScale.x;
    rigidbody.AddForce(input * inputAccel);
  }
}
