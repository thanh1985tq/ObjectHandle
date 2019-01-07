using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] GameObject otherObject;

    float modifiedAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angleBetween2Object = GetAngleBetween2Object(gameObject, otherObject);

        //If object in this position (->) from the beginning, then modify angle is zero
        //Else if position like this (^), then modify angle is 90f
        //Else if position like this (v), then modify angle is -90f
        setAngle(angleBetween2Object + modifiedAngle);
    }

    private void Move()
    {
        //Get setting when key left or right is press (gravity, sensitive...)
        float xAxis = Input.GetAxis("Horizontal");

        //Get setting when key up or down is press (gravity, sensitive...)
        float yAxis = Input.GetAxis("Vertical"); //-1 is smallest number of this axis when key is hold

        //Define move speed = number of pixels per second
        float newXPos = xAxis * moveSpeed * Time.deltaTime;
        float newYPos = yAxis * moveSpeed * Time.deltaTime;

        //Update new position when move key is press
        transform.position = new Vector2(transform.position.x + newXPos, transform.position.y + newYPos);
    }

    private float GetAngleBetween2Object(GameObject object1, GameObject object2)
    {
        //Get position of 2 object
        Vector3 object1Position = object1.transform.position;
        Vector3 object2Position = object2.transform.position;

        //Caculate angle from object 1 to object 2
        float angle = Mathf.Atan2(object1Position.y - object2Position.y, object1Position.x - object2Position.x) * Mathf.Rad2Deg;

        return angle;
    }

    
    private void setAngle(float z)
    {
        //First way to set angle of object is change z value using Euler
        transform.rotation = Quaternion.Euler(0, 0, z);

        //Second way is using AngleAxis
        //transform.rotation = Quaternion.AngleAxis(z, Vector3.forward);
    }

}
