using UnityEngine;
using UnityEngine.UI;

public class ModelControlManager : MonoBehaviour
{
    Transform transformOfLastModel;
    [SerializeField] Text Rtext, Stext;
    [SerializeField] GameObject selectModel;
    [SerializeField] private ObjectSpawner objectSpawner;

    /// <summary>
    ///  Increase transformOfLastModel Rotation 
    /// </summary>
    public void increaseRotation()
    {
        if (updatetransformOfLastModel())
        {

            transformOfLastModel.Rotate(transformOfLastModel.up * 2.5f);
            updateRotationTXT(transformOfLastModel.localEulerAngles.y);
        }
    }
    /// <summary>
    ///  Decrease transformOfLastModel Rotation 
    /// </summary>
    public void decreaseRotation()
    {
        if (updatetransformOfLastModel())
        {
            transformOfLastModel.Rotate(-transformOfLastModel.up * 2.5f);
            updateRotationTXT(transformOfLastModel.localEulerAngles.y);
        }
    }
    /// <summary>
    ///  Increase transformOfLastModel Scale 
    /// </summary>
    public void increaseScale()
    {
        if (updatetransformOfLastModel())
        {
            transformOfLastModel.localScale += Vector3.one * Time.deltaTime * 0.15f;
            updateScaleTXT(transformOfLastModel.localScale.y);
        }

    }
    /// <summary>
    ///  Decrease transformOfLastModel Rotation 
    /// </summary>
    public void decreaseScale()
    {
        if (updatetransformOfLastModel())
        {
            transformOfLastModel.localScale -= Vector3.one * Time.deltaTime * 0.15f;
            updateScaleTXT(transformOfLastModel.localScale.y);
        }
    }

    //______________________________________________________________________
    // Comming 2 Functions to Update the TEXT ON UI 
    private void updateRotationTXT(float val)
    {
        Rtext.text = System.Math.Round(val, 2) + "";
    }
    private void updateScaleTXT(float val)
    {
        Stext.text = System.Math.Round(val, 3)+"";
    }
    //______________________________________________________________________


    /// <summary>
    /// Function to Update transformOfLastModel property 
    /// </summary>
    private bool updatetransformOfLastModel()
    {
        if (objectSpawner.LastCreatedObject != null)
        {
            // assign New Value 
            this.transformOfLastModel = objectSpawner.LastCreatedObject.transform;
            selectModel.SetActive(false);
            return true;
        }
        else
        {
            selectModel.SetActive(true);
            selectModel.GetComponent<DestroyBlink>().disableBlink();
            return false;
        }
    }
}
