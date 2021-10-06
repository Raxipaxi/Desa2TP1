using UnityEngine;

public abstract class MissileAbstract : MonoBehaviour
{
    [SerializeField] private string id;

    public string Id => id;
}


