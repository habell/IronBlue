using System.Collections;
using UnityEngine;

namespace BaseCode.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}