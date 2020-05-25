using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelControlManager : MonoBehaviour
{
    Transform transformOfLastModel; 
    public void increaseRotation()
    {
        updatetransformOfLastModel();
        transformOfLastModel.Rotate(transform.up *2.5f);
    }
    public void decreaseRotation()
    {
        updatetransformOfLastModel();
        transformOfLastModel.Rotate(-transform.up *2.5f);
    }
    public void increaseScale()
    {
        updatetransformOfLastModel();
        transformOfLastModel.localScale += Vector3.one* Time.deltaTime * 0.15f;
    }
    public void decreaseScale()
    {
        updatetransformOfLastModel();
        transformOfLastModel.localScale -= Vector3.one* Time.deltaTime* 0.15f;
    }
    private void updatetransformOfLastModel()
    {
        // assign New Value 
        this.transformOfLastModel = GameObject.Find("7777").transform;
    }
}
