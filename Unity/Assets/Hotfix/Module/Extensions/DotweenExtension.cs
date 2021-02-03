using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public static class DotweenExtension
    {
        public static ETTask GetAwaiter(this Tween tween)
        {
            ETTaskCompletionSource source = new ETTaskCompletionSource();
            return source.Task;
        }
    }
}

