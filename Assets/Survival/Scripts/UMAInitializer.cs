using UnityEngine;
using UMA;

public class UMAInitializer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<UMADynamicAvatar>().Initialize();
    }
}
