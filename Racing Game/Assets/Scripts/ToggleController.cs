using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public Toggle toggle;

    //public TopDownCarControls topDownCarControls;
    //public NewBehaviourScript newBehaviour;
    //public PathFollowCar pathFollowCar;


   public static string lvl = "Level 2";
    //bool player2 = false;
    private void Start()
    {


        //topDownCarControls =  GameObject.FindGameObjectWithTag("player2").GetComponent<TopDownCarControls>();
        //newBehaviour = GameObject.FindGameObjectWithTag("player2").GetComponent<NewBehaviourScript>();
        //pathFollowCar = GameObject.FindGameObjectWithTag("player2").GetComponent<PathFollowCar>();

        // Attach a listener to the toggle's onValueChanged event
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // Callback method for the toggle's onValueChanged event
    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("lvl1");
            lvl = "Level 1";
            
        }
        else
        {
            Debug.Log("lvl2");
            lvl = "Level 2";

            
        }
    }

    public string getLvl()
    {
        return lvl;
    }
}
