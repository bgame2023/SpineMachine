using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Column : MonoBehaviour
{
    [SerializeField] RectTransform[] icons;
    [SerializeField] Animator[] effects;

    [SerializeField]  private VerticalLayoutGroup verticalLayoutGroup;

    private float pointEnd;
    private float moveDuration = 3f;
    private float moveSpeed = 46f;
    private const float fixedDeltaTime = 0.0166666666f;
    List<int> indexList = new List<int>();

    private void Start()
    {
        pointEnd = -1495+ 230;
        indexList  = Enumerable.Range(0, icons.Length).ToList();

    }
    public void SetUp( float moveDuration)
    {
        this.moveDuration = moveDuration;
    }
    public void Spine(float speed)
    {
        this.moveSpeed = speed;
        StartCoroutine(MoveColumn());
    }
    IEnumerator MoveColumn()
    {
        float elapsedTime = 0f;
       
        while (elapsedTime < moveDuration)
        {
            for (int i = 0; i < icons.Length; i++)
            {
                icons[i].Translate(Vector3.down * moveSpeed);

                if (icons[i].localPosition.y <= pointEnd)
                {
                    int removedIndex = indexList[indexList.Count - 1];
                    indexList.RemoveAt(indexList.Count - 1);
                    indexList.Insert(0, removedIndex);
                    icons[i].SetAsFirstSibling();
                }
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        verticalLayoutGroup.enabled = false;
        verticalLayoutGroup.enabled = true;

    }
    public int[] GetResult()
    {
        int[] Result = new int[] { 0, 0, 0 };
        Result[0] = indexList[2];
        Result[1] = indexList[3];
        Result[2] = indexList[4];
        return Result;
    }

    public void PlayEffect(int index)
    {
        effects[index].SetTrigger("effect");
    }

}
