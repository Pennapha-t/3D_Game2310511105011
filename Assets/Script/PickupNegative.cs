using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupNegative : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(30, 30, 30) * Time.deltaTime);
    }
}
