using UnityEngine;

public class OpenBox : MonoBehaviour
{
    public GameObject prefab;
    public Transform instPos;

    void Start()
    {
        Instantiate(prefab, instPos.position, Quaternion.identity);
        prefab = null;
    }
}
