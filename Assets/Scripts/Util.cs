using UnityEngine;

public static class Util
{
  public static float ComputeCircleOverlap(Vector2 center1, float radius1, Vector2 center2, float radius2)
  {
    Vector2 difference = center1 - center2;
    Vector2 differenceSquared = difference * difference;
    float distanceSquared = differenceSquared.x + differenceSquared.y;
    float distance = Mathf.Sqrt(distanceSquared);
    return radius1 + radius2 - distance;
  }
}
