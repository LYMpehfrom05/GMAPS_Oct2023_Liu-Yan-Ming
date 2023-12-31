 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class Util
 {
     public static float FindDistance(HVector2D p1, HVector2D p2)
     {
        // Difference in 2 x and y coordinates
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;

        // Distance is sqrt(dx^2 + dy^2) according to Pythagora's Theorem
        return Mathf.Sqrt(dx * dx + dy * dy);
    }
 }

