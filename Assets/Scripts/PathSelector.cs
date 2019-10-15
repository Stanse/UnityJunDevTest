using System.Collections.Generic;
using UnityEngine;

public class PathSelector : MonoBehaviour
{
    [SerializeField] private GameObject prefabBall;
    [SerializeField] private GameObject UI;
    [SerializeField] private List<GameObject> trajectories;

    public GameObject fireBall;

    private float pointA;
    
    // Start is called before the first frame update
    void Start()
    {
        fireBall = null;
    }

    public void BtnLinePathWasPressed()
    {
        float x = trajectories[0].GetComponent<Path>().GetPointA().x;
        float y = trajectories[0].GetComponent<Path>().GetPointA().y;
        if (fireBall != null)
            Destroy(fireBall);
        fireBall = Instantiate(prefabBall, new Vector3(x, y, 0), prefabBall.transform.rotation);
        trajectories[0].GetComponent<Path>().StartMoving(fireBall);
        UI.GetComponent<UI>().getTxtPathSetting().gameObject.SetActive(false);
        UI.GetComponent<UI>().setSliderSpeed(1);
    }

    public void BtnSawPathWasPressed()
    {
        float x = trajectories[1].GetComponent<Path>().GetPointA().x;
        float y = trajectories[1].GetComponent<Path>().GetPointA().y;
        if (fireBall != null)
            Destroy(fireBall);  
        fireBall = Instantiate(prefabBall, new Vector3(x, y, 0), prefabBall.transform.rotation);
        fireBall.name = "fireBall";
        trajectories[1].GetComponent<Path>().StartMoving(fireBall);
        UI.GetComponent<UI>().setSliderSpeed(1);
        UI.GetComponent<UI>().getTxtPathSetting().gameObject.SetActive(true);
        UI.GetComponent<UI>().getTxtPathSetting().tag = "Saw";
        UI.GetComponent<UI>().setTxtPathSetting("N = " + trajectories[1].GetComponent<SawPath>().GetN().ToString());
    }

    public void BtnSpiralWasPressed()
    {
        float x = trajectories[2].GetComponent<Path>().GetPointA().x;
        float y = trajectories[2].GetComponent<Path>().GetPointA().y;
        if (fireBall != null)
            Destroy(fireBall);
        fireBall = Instantiate(prefabBall, new Vector3(x, y, 0), prefabBall.transform.rotation);
        fireBall.name = "fireBall";
        trajectories[2].GetComponent<Path>().StartMoving(fireBall);
        UI.GetComponent<UI>().setSliderSpeed(1);
        UI.GetComponent<UI>().getTxtPathSetting().gameObject.SetActive(true);
        UI.GetComponent<UI>().getTxtPathSetting().tag = "Spiral";
        UI.GetComponent<UI>().setTxtPathSetting("R = " + trajectories[2].GetComponent<SpiralPath>().getRadius());
    }

    public void SetSpeed(float s)
    {
        fireBall.GetComponent<Ball>().SetSpeed(s);
        UI.GetComponent<UI>().setTxtSpeed(s.ToString());
    }

    public void BtnPlusWasPressed()
    {
        if (UI.GetComponent<UI>().getTxtPathSetting().tag == "Saw")
        {
            int N = trajectories[1].GetComponent<SawPath>().GetN() + 1;
            trajectories[1].GetComponent<SawPath>().SetN(N);
            BtnSawPathWasPressed();
        }
    }

    public void BtnMinusWasPressed()
    {
        if (UI.GetComponent<UI>().getTxtPathSetting().tag == "Saw")
        {
            int N = trajectories[1].GetComponent<SawPath>().GetN() - 1;
            if (N == 0)
                N = 1;
            trajectories[1].GetComponent<SawPath>().SetN(N);
            BtnSawPathWasPressed();
        }
    }

    public void Update()
    {
        if (UI.GetComponent<UI>().getTxtPathSetting().tag == "Spiral")
        {
            UI.GetComponent<UI>().setTxtPathSetting("R = " + trajectories[2].GetComponent<SpiralPath>().getRadius());
        }
    }

}
