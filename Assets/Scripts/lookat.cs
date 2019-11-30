
using UnityEngine;

public class lookat : MonoBehaviour
{

    public Transform lookThere;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookThere);
    }
}
