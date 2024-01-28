using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    private Collider2D collider;
    private void Start()
    {
        GameManager.Instance.SpinManager.OnNeedleHit.AddListener(test);
    }

    // Update is called once per frame
    void Update()
    {
        collider = GetComponentInChildren<Collider2D>();
    }

    public int GetNeedleHints()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        int hints = 3;

        if(hit.collider!= null)
        {
            hints = hit.collider.GetComponent<Slice>().hints;
            //Debug.Log($"obtained hints: {hints}");
        } else
        {
            Debug.LogError("something fucked up when checking collision for the needle the slice collider");
        }

        return hints;
    }

    private void test(int hints)
    {
        Debug.Log($"Event Hints: {hints}");
    }
}
