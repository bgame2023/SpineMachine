using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public float spacingTime;
    public float moveDuration = 5;
    public int cointAuto = 1000;
    public int maxCoin = 20000;
    public int unitBet = 1000;
    public int maxBet = 20000;
    public int minBet = 1000;
    public int[][] DataSetAnswers()
    {
        return new int[][]
        {
        new int[] {0, 3, 6},
        new int[] {0, 3, 7},

        new int[] {0, 4, 6},
        new int[] {0, 4, 7},
        new int[] {0, 4, 8},

        new int[] {1, 3, 6},
        new int[] {1, 3, 7},

        new int[] {1, 4, 7},
        new int[] {1, 4, 7},
        new int[] {1, 4, 8},

        new int[] {1, 5, 7},
        new int[] {1, 5, 8},

        new int[] {2, 4, 6},
        new int[] {2, 4, 7},
        new int[] {2, 4, 8},

        new int[] {2, 5, 7},
        new int[] {2, 5, 8},
        };
    }
}
