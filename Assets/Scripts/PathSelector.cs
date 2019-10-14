using System.Collections;
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
        float x = trajectories[0].GetComponent<Path>().getPointA().x;
        float y = trajectories[0].GetComponent<Path>().getPointA().y;
        if (fireBall != null)
            Destroy(fireBall);
        fireBall = Instantiate(prefabBall, new Vector3(x, y, 0), prefabBall.transform.rotation);
        trajectories[0].GetComponent<Path>().StartMoving(fireBall);
        UI.GetComponent<UI>().getTxtPathSetting().gameObject.SetActive(false);
        UI.GetComponent<UI>().setSliderSpeed(1);
    }

    public void BtnSawPathWasPressed()
    {
        float x = trajectories[1].GetComponent<Path>().getPointA().x;
        float y = trajectories[1].GetComponent<Path>().getPointA().y;
        if (fireBall != null)
            Destroy(fireBall);  
        fireBall = Instantiate(prefabBall, new Vector3(x, y, 0), prefabBall.transform.rotation);
        fireBall.name = "fireBall";
        trajectories[1].GetComponent<Path>().StartMoving(fireBall);
        UI.GetComponent<UI>().setSliderSpeed(1);
        UI.GetComponent<UI>().getTxtPathSetting().gameObject.SetActive(true);
        UI.GetComponent<UI>().getTxtPathSetting().tag = "Saw";
        UI.GetComponent<UI>().setTxtPathSetting("N = " + trajectories[1].GetComponent<SawPath>().getN().ToString());
    }

    public void setSpeed(float s)
    {
        fireBall.GetComponent<Ball>().SetSpeed(s);
        UI.GetComponent<UI>().setTxtSpeed(s.ToString());
    }

    public void btnPlusWasPressed()
    {
        if (UI.GetComponent<UI>().getTxtPathSetting().tag == "Saw")
        {
            int N = trajectories[1].GetComponent<SawPath>().getN() + 1;
            trajectories[1].GetComponent<SawPath>().setN(N);
            BtnSawPathWasPressed();
        }
    }

    public void btnMinusWasPressed()
    {
        if (UI.GetComponent<UI>().getTxtPathSetting().tag == "Saw")
        {
            int N = trajectories[1].GetComponent<SawPath>().getN() - 1;
            if (N == 0)
                N = 1;
            trajectories[1].GetComponent<SawPath>().setN(N);
            BtnSawPathWasPressed();
        }
    }

}
