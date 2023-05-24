using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggerTransformer : MonoBehaviour
{
    Vector3 startingposition;
    UIManager uiManager;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    public float period = .1f;
    public float maxPeriod = 6f;


    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        period = uiManager.PlayerPrefsFloatKey("DiggerSpeed", 3f);
        startingposition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if(period == Mathf.Epsilon) 
        {
            return;
        }

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;

        float rawSinWawe = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWawe + 1f) / 2;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingposition + offset; 
    }
}
