using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    //Root of arm
    public Joint root;
    
    //End 
    public Joint end;

    public GameObject Target;
    
    public float threasold= 0.05f;
    public float rate = 5f;
    
   
  

    // Update is called once per frame
    void Update()
    {
        if (getDistance(end.transform.position, Target.transform.position) > threasold)
        {
            Joint current = root;
            while (current != null)
            {
                float slope = calculateSlope(current);
                current.rotate(-slope * rate);
                current = current.get_Child();
            }
        }
        
        
    }

    float calculateSlope(Joint _joint)
    {
        float deltaTheta = 0.001f;
        float distance1 = getDistance(end.transform.position,Target.transform.position);
        
        _joint.rotate(deltaTheta);
        
        float distance2 = getDistance(end.transform.position,Target.transform.position);
        
        _joint.rotate(-deltaTheta);
        
        return(distance2-distance1)/deltaTheta;
    }
    
    float getDistance(Vector3 point1, Vector3 point2)
    {
        return Vector3.Distance(point1, point2);
    }
}

