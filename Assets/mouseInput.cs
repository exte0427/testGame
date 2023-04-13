using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInput : MonoBehaviour
{

    public generator gen;

    bool isCreate;
    bool isMove;
    GameObject clickedObj;

    Vector2 firLoc;
    Vector2 lastLoc;

    Vector2 getLoc()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    GameObject CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider == null)
            return null;

        return hit.collider.gameObject;
    }

    Vector2 getSize(Vector2 firLock, Vector2 lastLoc)
    {
        Vector2 size = lastLoc - firLoc;
        return new Vector2(Mathf.Abs(size.x), Mathf.Abs(size.y));
    }

    private void Start()
    {
        isMove = false;
        isCreate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedObj = CastRay();

            if (clickedObj == null)
            {
                // making process
                isCreate = true;
                clickedObj = gen.generateBox(new generator.BoxSetter(Vector2.zero,Vector2.zero,0,0));
                firLoc = getLoc();
            }
            else
            {
                // move
                isMove = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (isMove)
            {
                lastLoc = getLoc();
                clickedObj.GetComponent<sizedBox>().move(lastLoc);
            }

            if (isCreate)
            {
                lastLoc = getLoc();

                var size = getSize(firLoc, lastLoc);
                var realLoc = (firLoc + lastLoc) / 2f;
                var angle = 0;
                var mass = size.x * size.y;

                clickedObj.GetComponent<sizedBox>().set(new generator.BoxSetter(realLoc, size, angle, mass));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMove = false;
            isCreate = false;
        }
    }
}
