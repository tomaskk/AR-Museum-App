using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public string btnName;
    private bool isExtraTextRendererEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        ToggleExtraInfoPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))  // For dev-test purposes only to work on PC
        {
            ToggleExtraInfoPanel();  
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) // For tracking virtual buttons via Android's touchscreen
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                btnName = hit.transform.name;

                if (btnName == "MoreInfoBtn")
                {
                    ToggleExtraInfoPanel();
                }
            }
        }
    }

    void ToggleExtraInfoPanel()
    {
        if (isExtraTextRendererEnabled)
        {
            var panel = GameObject.FindWithTag("MoreInfoTextPanel");

            panel.SetActive(false);
            isExtraTextRendererEnabled = false;
        }
        else
        {
            var parent = GameObject.FindWithTag("TomasK_QR_Code");
            Transform[] trs = parent.GetComponentsInChildren<Transform>(true);

            foreach (Transform t in trs)
            {
                if (t.name == "MoreInfoTextPanel")
                {
                    var panelObj = t.gameObject;
                    panelObj.SetActive(true);
                    isExtraTextRendererEnabled = true;
                }
            }
        }
    }
}
