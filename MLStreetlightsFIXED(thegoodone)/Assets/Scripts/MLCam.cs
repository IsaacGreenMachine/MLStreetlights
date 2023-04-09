using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Barracuda;

public class MLCam : MonoBehaviour
{
    public NNModel modelAsset;
    private Model m_RuntimeModel;
    // Start is called before the first frame update
    void Start()
    {
        m_RuntimeModel = ModelLoader.Load(modelAsset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
