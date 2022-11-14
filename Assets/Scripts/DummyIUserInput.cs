using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyIUserInput : IUserInput
{
    IEnumerator Start()
    {
        while (true)
        {
            rb = true;
            yield return 0;
        }
    }

    private void Update()
    {
        UpdateDmagDvec(Dup, Dright);
    }
}