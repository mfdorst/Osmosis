using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCollide : MonoBehaviour
{
  void OnTriggerStay2D(Collider2D other)
  {
    // Assumes the cell is circular, and is scaled evenly in both dimensions
    float radius = transform.localScale.x / 2;
    float otherRadius = other.transform.localScale.x / 2;
    float overlap = Util.ComputeCircleOverlap(transform.position, radius, other.transform.position, otherRadius);
    if (other.tag == "Cell" && transform.localScale.x > 0 && overlap > 0)
    {
      // Compare sizes. If you're smaller, shrink. If you're larger, grow.
      if (transform.localScale.x > other.transform.localScale.x)
      {
        // Grow
        transform.localScale += new Vector3(overlap, overlap, 0);
      }
      else
      {
        // Shrink
        transform.localScale -= new Vector3(overlap, overlap, 0);
        if (transform.localScale.x < 0.1)
        {
          Destroy(gameObject);
        }
      }
    }
  }
}
