using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopNPCController : EnemyController
{

    protected ShopNPCContext _context;
    protected List<Vector3> _positions;
    public void SetMoveList(List<Vector3> positions)
    {
        _positions = positions;
    }
}
