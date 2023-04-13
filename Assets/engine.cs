using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engine : generator.Mass
{
    
    

    public override void onStart(generator.Info info)
    {
        this.info = info;
        this.rigid = GetComponent<Rigidbody2D>();

        transform.position = info.pos;
        transform.localScale = info.size;
        rigid.mass = info.mass;
    }

    public override void onUpdate()
    {
        
    }
}
