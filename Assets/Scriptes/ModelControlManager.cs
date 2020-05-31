using UnityEngine;
using UnityEngine.UI;

public class ModelControlManager : MonoBehaviour
{
    [SerializeField] Text Rtext, Stext;
    [SerializeField] GameObject selectModel;
    [SerializeField] private ObjectSpawner objectSpawner;

    /// <summary>
    ///  Increase transformOfLastModel Rotation 
    /// </summary>
    public void increaseRotation()
    {
        if (checkIfObjSelected())
        {
            objectSpawner.LastCreatedObject.transform.Rotate(objectSpawner.transform.up*0.5f);
            updateRotationTXT(objectSpawner.LastCreatedObject.transform.localEulerAngles.y);
        }
    }
    /// <summary>
    ///  Decrease transformOfLastModel Rotation 
    /// </summary>
    public void decreaseRotation()
    {
        if (checkIfObjSelected())
        {
            objectSpawner.LastCreatedObject.transform.Rotate(-objectSpawner.transform.up*0.5f);
            updateRotationTXT(objectSpawner.LastCreatedObject.transform.localEulerAngles.y);
        }
    }
    /// <summary>
    ///  Increase transformOfLastModel Scale 
    /// </summary>
    public void increaseScale()
    {
        if (checkIfObjSelected())
        {
            objectSpawner.LastCreatedObject.transform.localScale += Vector3.one * Time.deltaTime * 0.15f;
            updateScaleTXT(objectSpawner.LastCreatedObject.transform.localScale.y);
        }

    }
    /// <summary>
    ///  Decrease transformOfLastModel Rotation 
    /// </summary>
    public void decreaseScale()
    {
        if (checkIfObjSelected())
        {
            objectSpawner.LastCreatedObject.transform.localScale -= Vector3.one * Time.deltaTime * 0.15f;
            updateScaleTXT(objectSpawner.LastCreatedObject.transform.localScale.y);
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
        Stext.text = System.Math.Round(val, 2)+"";
    }
    //______________________________________________________________________


    /// <summary>
    /// Function to Update transformOfLastModel property 
    /// </summary>
    private bool checkIfObjSelected()
    {
        if (objectSpawner.LastCreatedObject != null)
        { 
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
