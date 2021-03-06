﻿using UnityEngine;

public class CellCollide : MonoBehaviour
{
  public Vector2 velocity;

  new Rigidbody2D rigidbody;

  private void Start()
  {
    rigidbody = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    velocity = rigidbody.velocity;
  }

  void OnTriggerStay2D(Collider2D other)
  {
    // Assumes the cell is circular, and is scaled evenly in both dimensions.
    float radius = transform.localScale.x / 2;
    float otherRadius = other.transform.localScale.x / 2;
    float overlap = Util.CircleOverlap(transform.position, radius, other.transform.position, otherRadius);
    if (other.tag == "Cell" && transform.localScale.x > 0 && overlap > 0)
    {
      // Compare sizes. If you're smaller, shrink. If you're larger, grow.
      if (transform.localScale.x > other.transform.localScale.x)
      {
        // Grow.
        // When growing, take on the velocity of any mass you aquire.
        // Get the area before we take on any new mass.
        float massBefore = Util.CircleArea(transform.localScale.x);
        // Increase size
        transform.localScale += new Vector3(overlap, overlap, 0);
        // Get the area again after taking on new mass.
        float massAfter = Util.CircleArea(transform.localScale.x);
        // Compute the amount of new mass aquired.
        float massAquired = massAfter - massBefore;
        // Apply force proportional to the mass aquired.
        rigidbody.velocity = rigidbody.velocity * massBefore / massAfter + other.GetComponent<Rigidbody2D>().velocity * massAquired / massAfter;
      }
      else
      {
        // Shrink
        transform.localScale -= new Vector3(overlap, overlap, 0);
        // Self destruct once you become very small.
        if (transform.localScale.x < 0.1)
        {
          Destroy(gameObject);
        }
      }
    }
  }
}
