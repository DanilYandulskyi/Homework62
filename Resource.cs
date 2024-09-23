using UnityEngine;

public class Resource : MonoBehaviour
{
    public void Attach(Transform transform)
    {
        this.transform.SetParent(transform);
    }
}