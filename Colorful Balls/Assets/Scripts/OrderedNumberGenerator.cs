using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderedNumberGenerator : NumberGenerator {

    public int[] order;
    int index = 0;

	public override int Next()
    {
        int result = order[index % order.Length];
        index++;
        return result;
    }
}
