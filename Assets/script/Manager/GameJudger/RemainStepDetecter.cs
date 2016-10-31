using UnityEngine;
using System.Collections;

public class RemainStepDetecter : GameDetecter {

    private UILabel stepRemainLabel;
    public override bool checkMissionCompleted(params object[] objects)
    {
        stepRemainLabel = GameObject.Find("needRemain").GetComponent<UILabel>();
        stepRemainLabel.text = "必须剩下数目"+(int)(objects[0]);
        return checkIfRemianStep(Cubes.instance.cubesList,(int)(objects[0]));

    }

    private bool checkIfRemianStep(Cube[,] cbs,int remianStep)
    {
        int remain=0;

        int n1 = cbs.GetLength(0);
        int n2 = cbs.GetLength(1);
        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                if (cbs[i, j].getNeedCrossTime()>0)
                {
                    remain += cbs[i, j].getNeedCrossTime();
                }
            }
        }

        if (remain == remianStep)
        {
            stepRemainLabel.text="";
            return true;
            
        }
        else {
            return false;
        }

    }
}
