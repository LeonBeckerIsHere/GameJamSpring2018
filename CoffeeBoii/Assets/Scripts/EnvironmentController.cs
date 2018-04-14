using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {
    Transform mCTransform;
    Camera camera;

    SpriteRenderer rend;
    [HideInInspector]
    public List<bool> sEList;

    float grow;
    bool growFlag;
    Color invis;

    float count;
    float angleAmount;
    bool firstIter;

    float zoomScale;


    // Use this for initialization
    void Start () {
        mCTransform = transform.Find("Main Camera");
        camera = mCTransform.GetComponent<Camera>();
        rend = transform.GetComponent<SpriteRenderer>();
        sEList = new List<bool>();
        for(int i = 0; i < 4; ++i)
            sEList.Add(false);

        grow = 0f;
        invis = new Color(0, 0, 0, 0);

        count = -10f;
        angleAmount = 0.1f;
        firstIter = true;

        zoomScale = 25f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (sEList[0])
        {
            mCTransform.Rotate(0f, 0f, 180f);
            sEList[0] = false;
        }
        if (sEList[1])
        {
            if (growFlag)
            {
                grow+=0.01f;
            }
            else
            {
                grow-=0.01f;
            }

            if (grow < 0 || grow > 1)
                growFlag = !growFlag;

            rend.color = new Color(0, 0, 0, Ease(grow));

        }
        else
        {
            rend.color = invis;
        }
        if(sEList[2])
        {
            camera.orthographicSize = zoomScale;
            zoomScale *= 2;
            sEList[2] = false;
        }

        if (sEList[3])
        {
            if (firstIter)
            {
                if (count > 10 || count < -10)
                {
                    angleAmount *= -1;
                    count = 20f;
                    firstIter = false;
                }
            }
            else
            {
                if (count > 20 || count < -20)
                {
                    angleAmount *= -1;
                }
            }

            mCTransform.Rotate(0f, 0f, angleAmount);
            count += angleAmount;
        }
        else
        {
            if (!firstIter)
            {
                mCTransform.Rotate(0f, 0f, (-1) * count);
                count = 0f;
                angleAmount = 0.1f;
                firstIter = true;
            }
        }
	}
    float Ease(float x)
    {
        return Mathf.Pow(x, 3) / (Mathf.Pow(x, 3) + Mathf.Pow(1 - x, 3));
    }
}

