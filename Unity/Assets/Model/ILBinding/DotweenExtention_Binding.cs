using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class DotweenExtention_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(global::DotweenExtention);
            args = new Type[]{typeof(DG.Tweening.Tween), typeof(System.Threading.CancellationToken), typeof(global::TweenCancelBehaviour)};
            method = type.GetMethod("ToAwaiter", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ToAwaiter_0);


        }


        static StackObject* ToAwaiter_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            global::TweenCancelBehaviour @behaviour = (global::TweenCancelBehaviour)typeof(global::TweenCancelBehaviour).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Threading.CancellationToken @cancellationToken = (System.Threading.CancellationToken)typeof(System.Threading.CancellationToken).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            DG.Tweening.Tween @tween = (DG.Tweening.Tween)typeof(DG.Tweening.Tween).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = global::DotweenExtention.ToAwaiter(@tween, @cancellationToken, @behaviour);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }



    }
}
