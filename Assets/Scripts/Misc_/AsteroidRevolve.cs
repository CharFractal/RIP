using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRevolve : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0f, 0f, 10f * Time.deltaTime);
    }
}
