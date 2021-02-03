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
    unsafe class EventHandler_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(global::EventHandler);

            field = type.GetField("OnDragAction", flag);
            app.RegisterCLRFieldGetter(field, get_OnDragAction_0);
            app.RegisterCLRFieldSetter(field, set_OnDragAction_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnDragAction_0, AssignFromStack_OnDragAction_0);
            field = type.GetField("OnBeginDragAction", flag);
            app.RegisterCLRFieldGetter(field, get_OnBeginDragAction_1);
            app.RegisterCLRFieldSetter(field, set_OnBeginDragAction_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnBeginDragAction_1, AssignFromStack_OnBeginDragAction_1);
            field = type.GetField("OnPointerUpAction", flag);
            app.RegisterCLRFieldGetter(field, get_OnPointerUpAction_2);
            app.RegisterCLRFieldSetter(field, set_OnPointerUpAction_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnPointerUpAction_2, AssignFromStack_OnPointerUpAction_2);
            field = type.GetField("OnPointerDownAction", flag);
            app.RegisterCLRFieldGetter(field, get_OnPointerDownAction_3);
            app.RegisterCLRFieldSetter(field, set_OnPointerDownAction_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnPointerDownAction_3, AssignFromStack_OnPointerDownAction_3);


        }



        static object get_OnDragAction_0(ref object o)
        {
            return ((global::EventHandler)o).OnDragAction;
        }

        static StackObject* CopyToStack_OnDragAction_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::EventHandler)o).OnDragAction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnDragAction_0(ref object o, object v)
        {
            ((global::EventHandler)o).OnDragAction = (global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>)v;
        }

        static StackObject* AssignFromStack_OnDragAction_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            global::BridgeEvent<UnityEngine.EventSystems.PointerEventData> @OnDragAction = (global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>)typeof(global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((global::EventHandler)o).OnDragAction = @OnDragAction;
            return ptr_of_this_method;
        }

        static object get_OnBeginDragAction_1(ref object o)
        {
            return ((global::EventHandler)o).OnBeginDragAction;
        }

        static StackObject* CopyToStack_OnBeginDragAction_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::EventHandler)o).OnBeginDragAction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnBeginDragAction_1(ref object o, object v)
        {
            ((global::EventHandler)o).OnBeginDragAction = (global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>)v;
        }

        static StackObject* AssignFromStack_OnBeginDragAction_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            global::BridgeEvent<UnityEngine.EventSystems.PointerEventData> @OnBeginDragAction = (global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>)typeof(global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((global::EventHandler)o).OnBeginDragAction = @OnBeginDragAction;
            return ptr_of_this_method;
        }

        static object get_OnPointerUpAction_2(ref object o)
        {
            return ((global::EventHandler)o).OnPointerUpAction;
        }

        static StackObject* CopyToStack_OnPointerUpAction_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::EventHandler)o).OnPointerUpAction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnPointerUpAction_2(ref object o, object v)
        {
            ((global::EventHandler)o).OnPointerUpAction = (global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>)v;
        }

        static StackObject* AssignFromStack_OnPointerUpAction_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            global::BridgeEvent<UnityEngine.EventSystems.PointerEventData> @OnPointerUpAction = (global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>)typeof(global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((global::EventHandler)o).OnPointerUpAction = @OnPointerUpAction;
            return ptr_of_this_method;
        }

        static object get_OnPointerDownAction_3(ref object o)
        {
            return ((global::EventHandler)o).OnPointerDownAction;
        }

        static StackObject* CopyToStack_OnPointerDownAction_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::EventHandler)o).OnPointerDownAction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnPointerDownAction_3(ref object o, object v)
        {
            ((global::EventHandler)o).OnPointerDownAction = (global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>)v;
        }

        static StackObject* AssignFromStack_OnPointerDownAction_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            global::BridgeEvent<UnityEngine.EventSystems.PointerEventData> @OnPointerDownAction = (global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>)typeof(global::BridgeEvent<UnityEngine.EventSystems.PointerEventData>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((global::EventHandler)o).OnPointerDownAction = @OnPointerDownAction;
            return ptr_of_this_method;
        }



    }
}
