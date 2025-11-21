using UnityEngine;

public class PickUpController : MonoBehaviour
{
    // Update se llama una vez por frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);      
    }
}
