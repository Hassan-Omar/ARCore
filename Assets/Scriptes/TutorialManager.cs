using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    private int currentInstruction = 1; 
    [SerializeField] private GameObject rigthPanel;
    [SerializeField] private GameObject placeMarker;
    [SerializeField] private GameObject arrow;
    [SerializeField] private RectTransform pointer;
    [SerializeField] private TextMeshProUGUI pointerText; 
    public void viewInstruction()
    {
        switch (currentInstruction)
        {
            case 1:
                {
                    rigthPanel.SetActive(true);
                    placeMarker.SetActive(false);
                    pointer.transform.localPosition = new Vector3(119, 252,0);
                    pointerText.text = "You can rotate and scale model from here";
                    break;
                }
            case 2:
                {
                    pointer.transform.localPosition = new Vector3(119, 84, 0);
                    pointerText.text = "Press this to take screen shot after place your models";
                    break;
                }
            case 3:
                {
                    pointer.transform.localPosition = new Vector3(119, -28, 0);
                    pointerText.text = "You can generate models from this scroller Menu";
                    break;
                }
            case 4:
                {
                    pointer.transform.localPosition = new Vector3(119, -246, 0);
                    pointerText.text = "You can change color from this scroller Menu";
                    break;
                }
            case 5:
                {
                    arrow.SetActive(false);
                    rigthPanel.SetActive(false);
                    pointer.transform.localPosition = new Vector3(410, 0, 0);
                    pointerText.text = "You can select models by touching it";
                    break;
                }
            case 6:
                {
                    pointerText.text = "To delete models click twice";
                    break;
                }
            case 7:
                {
                    pointerText.text = "You can drag the models to Place them in by your hand";
                    break;
                }
            case 8:
                {
                    loadSceneByName("ARScene");
                    break;
                }
        }

        currentInstruction++; 
    }

    public void loadSceneByName(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
