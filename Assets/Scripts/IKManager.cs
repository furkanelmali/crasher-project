using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    //Root of arm
    public Joint[] root;
    
    //End 
    public Joint[] end;

    public GameObject[] Target;
    
    public float threasold= 0.05f;
    public float rate = 20f;

    public Fuel fuel;
    public Length length;
   
  

    // Update is called once per frame
    void Update()
    {
        if (fuel.currentFuel > 0)
        {
            if (getDistance(end[length.armNum].transform.position, Target[length.armNum].transform.position) > threasold)
            {
                Joint current = root[length.armNum];
                while (current != null)
                {
                    float slope = calculateSlope(current);
                    current.rotate(-slope * rate);
                    current = current.get_Child();
                }
            }
        }
      
    }

    float calculateSlope(Joint _joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = getDistance(end[length.armNum].transform.position,Target[length.armNum].transform.position);
        
        _joint.rotate(deltaTheta);
        
        float distance2 = getDistance(end[length.armNum].transform.position,Target[length.armNum].transform.position);
        
        _joint.rotate(-deltaTheta);
        
        return(distance2-distance1)/deltaTheta;
    }
    
    float getDistance(Vector3 point1, Vector3 point2)
    {
        return Vector3.Distance(point1, point2);
    }
}

