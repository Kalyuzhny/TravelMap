using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelMap.Monads
{
    public static class Maybe
    {
        public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
            where TInput : class
            where TResult : class
        {
            if (o == null) return null;
            return evaluator(o);
        }

        public static bool HasValue<TInput>(this TInput o)
            where TInput : class
        {
            return o != null;
        }


    }
}