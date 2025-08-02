using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopNPCController : EnemyController
{

    protected ShopNPCContext _context;
    protected List<Shelf> _shelfs;
    public void SetMoveList(List<Shelf> shelfs)
    {
        _shelfs = shelfs;
    }
}
