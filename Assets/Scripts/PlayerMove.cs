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

  void OnTriggerStay2D(Collider2D other)
  {
    if (other.tag == "Cell")
    {
      // Assumes the cell is circular, and is scaled evenly in both dimensions
      float radius = transform.localScale.x / 2;
      float otherRadius = other.transform.localScale.x / 2;
      float overlap = Util.ComputeCircleOverlap(transform.position, radius, other.transform.position, otherRadius);
      //Debug.Log(overlap);
      if (other.transform.localScale.x > 0 && overlap > 0)
      {
        other.transform.localScale -= new Vector3(overlap * 2, overlap * 2, 0);
      }
    }
  }
}
