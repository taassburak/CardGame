using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BackPackConfig BackPackConfig => _backPackConfig;

    [SerializeField] BackPackConfig _backPackConfig;
    void Start()
    {
        BackPack.Initialize();
        BackPack.Instance.SoftInitialize(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
