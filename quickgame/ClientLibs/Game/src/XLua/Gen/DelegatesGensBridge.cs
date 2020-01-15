#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;


namespace XLua
{
    public partial class DelegateBridge : DelegateBridgeBase
    {
		
		public void __Gen_Delegate_Imp0()
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                
                int __gen_error = LuaAPI.lua_pcall(L, 0, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public double __Gen_Delegate_Imp1(double arg1, double arg2)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushnumber(L, arg1);
                LuaAPI.lua_pushnumber(L, arg2);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                double __gen_ret = LuaAPI.lua_tonumber(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp2(UnityEngine.GameObject arg1, int arg2)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, arg1);
                LuaAPI.xlua_pushinteger(L, arg2);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp3(UnityEngine.GameObject arg1)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, arg1);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp4(UnityEngine.Vector2 arg1)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushUnityEngineVector2(L, arg1);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp5(int arg1)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushinteger(L, arg1);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp6(string obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushstring(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp7(bool obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushboolean(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp8(UnityEngine.GameObject obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp9(double obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushnumber(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp10(uint obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushuint(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp11(int arg1, int arg2)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushinteger(L, arg1);
                LuaAPI.xlua_pushinteger(L, arg2);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp12(string arg1, object arg2)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushstring(L, arg1);
                translator.PushAny(L, arg2);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp13(XLua.LuaTable obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp14(float arg0)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushnumber(L, arg0);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp15(UnityEngine.Vector2 arg0)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushUnityEngineVector2(L, arg0);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp16(int arg0)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushinteger(L, arg0);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp17(xc.ui.ugui.IUIBehaviour obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp18(SGameEngine.AssetResource obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public char __Gen_Delegate_Imp19(string text, int charIndex, char addedChar)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushstring(L, text);
                LuaAPI.xlua_pushinteger(L, charIndex);
                LuaAPI.xlua_pushinteger(L, addedChar);
                
                int __gen_error = LuaAPI.lua_pcall(L, 3, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                char __gen_ret = (char)LuaAPI.xlua_tointeger(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp20(object obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp21(UnityEngine.GameObject go, UIRollNumWidget wid)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, go);
                translator.Push(L, wid);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp22(UnityEngine.RectTransform vec)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, vec);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp23(xc.ui.UILockCDSlot item)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, item);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp24(xc.ui.UINewLockCDSlot item)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, item);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp25(object obj, xc.ui.UIItemNewSlot item)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, obj);
                translator.Push(L, item);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp26(xc.Goods goods)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, goods);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp27(xc.Goods goods, int num)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, goods);
                LuaAPI.xlua_pushinteger(L, num);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp28(xc.Goods goods, xc.ui.UIItemNewSlot item)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, goods);
                translator.Push(L, item);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp29(xc.ui.ugui.UITweener tweener)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, tweener);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp30(int idx, UnityEngine.GameObject go)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushinteger(L, idx);
                translator.Push(L, go);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp31(xc.CommonLuaInstanceState obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp32(xc.instance_behaviour.Behaviour obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp33(CEventBaseArgs arg)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, arg);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp34(ushort protocol, byte[] data)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushinteger(L, protocol);
                LuaAPI.lua_pushstring(L, data);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp35(object[] args)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                for (int __gen_i = 0; __gen_i < args.Length; ++__gen_i) translator.PushAny(L, args[__gen_i]);
                
                int __gen_error = LuaAPI.lua_pcall(L, 0 + args.Length, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp36(xc.ui.ugui.UIBaseWindow obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp37(xc.GoodsLuaEx obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp38(xc.GoodsItem obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp39(string url, string error, string reply, object userData)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushstring(L, url);
                LuaAPI.lua_pushstring(L, error);
                LuaAPI.lua_pushstring(L, reply);
                translator.PushAny(L, userData);
                
                int __gen_error = LuaAPI.lua_pcall(L, 4, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp40(string url, System.Collections.Generic.Dictionary<string, string> data, string error, string reply, object userData)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushstring(L, url);
                translator.Push(L, data);
                LuaAPI.lua_pushstring(L, error);
                LuaAPI.lua_pushstring(L, reply);
                translator.PushAny(L, userData);
                
                int __gen_error = LuaAPI.lua_pcall(L, 5, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp41(bool toggleIsOn, object param)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushboolean(L, toggleIsOn);
                translator.PushAny(L, param);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp42(Actor obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp43(xc.ui.UIItemNewSlot obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp44(object[] obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp45(xc.ClientModel obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp46(UnityEngine.Sprite obj)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.Push(L, obj);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp47(UnityEngine.Vector3 next)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushUnityEngineVector3(L, next);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
        
		static DelegateBridge()
		{
		    Gen_Flag = true;
		}
		
		public override Delegate GetDelegateByType(Type type)
		{
		
		    if (type == typeof(System.Action))
			{
			    return new System.Action(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction))
			{
			    return new UnityEngine.Events.UnityAction(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(DynamicScorll.OnSlider2Top))
			{
			    return new DynamicScorll.OnSlider2Top(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(DynamicScorll.OnSlider2Bottom))
			{
			    return new DynamicScorll.OnSlider2Bottom(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(xc.ui.ugui.SliderEx.OnFinished))
			{
			    return new xc.ui.ugui.SliderEx.OnFinished(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(xc.ui.ugui.ToggleEx.UIDelegate))
			{
			    return new xc.ui.ugui.ToggleEx.UIDelegate(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(xc.VoiceControlComponent.OnClickDelegate))
			{
			    return new xc.VoiceControlComponent.OnClickDelegate(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(ParticleAutoHide.OnStopped))
			{
			    return new ParticleAutoHide.OnStopped(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(System.Func<double, double, double>))
			{
			    return new System.Func<double, double, double>(__Gen_Delegate_Imp1);
			}
		
		    if (type == typeof(System.Func<UnityEngine.GameObject, int, bool>))
			{
			    return new System.Func<UnityEngine.GameObject, int, bool>(__Gen_Delegate_Imp2);
			}
		
		    if (type == typeof(System.Func<UnityEngine.GameObject, bool>))
			{
			    return new System.Func<UnityEngine.GameObject, bool>(__Gen_Delegate_Imp3);
			}
		
		    if (type == typeof(System.Func<UnityEngine.Vector2, bool>))
			{
			    return new System.Func<UnityEngine.Vector2, bool>(__Gen_Delegate_Imp4);
			}
		
		    if (type == typeof(System.Func<int, bool>))
			{
			    return new System.Func<int, bool>(__Gen_Delegate_Imp5);
			}
		
		    if (type == typeof(System.Action<string>))
			{
			    return new System.Action<string>(__Gen_Delegate_Imp6);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<string>))
			{
			    return new UnityEngine.Events.UnityAction<string>(__Gen_Delegate_Imp6);
			}
		
		    if (type == typeof(EmojiText.OnClickHref))
			{
			    return new EmojiText.OnClickHref(__Gen_Delegate_Imp6);
			}
		
		    if (type == typeof(System.Action<bool>))
			{
			    return new System.Action<bool>(__Gen_Delegate_Imp7);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<bool>))
			{
			    return new UnityEngine.Events.UnityAction<bool>(__Gen_Delegate_Imp7);
			}
		
		    if (type == typeof(xc.ui.ugui.UINoticeWindow.OnClickToggleDelegate))
			{
			    return new xc.ui.ugui.UINoticeWindow.OnClickToggleDelegate(__Gen_Delegate_Imp7);
			}
		
		    if (type == typeof(System.Action<UnityEngine.GameObject>))
			{
			    return new System.Action<UnityEngine.GameObject>(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(xc.ui.ugui.UICenterOnChild.OnCenterCallback))
			{
			    return new xc.ui.ugui.UICenterOnChild.OnCenterCallback(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(xc.ui.ugui.EventTriggerListener.UIDelegate))
			{
			    return new xc.ui.ugui.EventTriggerListener.UIDelegate(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(xc.EffectEmitter.InitFunc))
			{
			    return new xc.EffectEmitter.InitFunc(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(System.Action<double>))
			{
			    return new System.Action<double>(__Gen_Delegate_Imp9);
			}
		
		    if (type == typeof(System.Action<uint>))
			{
			    return new System.Action<uint>(__Gen_Delegate_Imp10);
			}
		
		    if (type == typeof(TrigramItem.ToggleChanged))
			{
			    return new TrigramItem.ToggleChanged(__Gen_Delegate_Imp10);
			}
		
		    if (type == typeof(xc.ui.ugui.SliderEx.OnOneFinished))
			{
			    return new xc.ui.ugui.SliderEx.OnOneFinished(__Gen_Delegate_Imp10);
			}
		
		    if (type == typeof(System.Action<int, int>))
			{
			    return new System.Action<int, int>(__Gen_Delegate_Imp11);
			}
		
		    if (type == typeof(System.Action<string, object>))
			{
			    return new System.Action<string, object>(__Gen_Delegate_Imp12);
			}
		
		    if (type == typeof(System.Action<XLua.LuaTable>))
			{
			    return new System.Action<XLua.LuaTable>(__Gen_Delegate_Imp13);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<float>))
			{
			    return new UnityEngine.Events.UnityAction<float>(__Gen_Delegate_Imp14);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<UnityEngine.Vector2>))
			{
			    return new UnityEngine.Events.UnityAction<UnityEngine.Vector2>(__Gen_Delegate_Imp15);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<int>))
			{
			    return new UnityEngine.Events.UnityAction<int>(__Gen_Delegate_Imp16);
			}
		
		    if (type == typeof(System.Action<xc.ui.ugui.IUIBehaviour>))
			{
			    return new System.Action<xc.ui.ugui.IUIBehaviour>(__Gen_Delegate_Imp17);
			}
		
		    if (type == typeof(System.Action<SGameEngine.AssetResource>))
			{
			    return new System.Action<SGameEngine.AssetResource>(__Gen_Delegate_Imp18);
			}
		
		    if (type == typeof(UnityEngine.UI.InputField.OnValidateInput))
			{
			    return new UnityEngine.UI.InputField.OnValidateInput(__Gen_Delegate_Imp19);
			}
		
		    if (type == typeof(ComTouchPress.OnPress))
			{
			    return new ComTouchPress.OnPress(__Gen_Delegate_Imp20);
			}
		
		    if (type == typeof(xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate))
			{
			    return new xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate(__Gen_Delegate_Imp20);
			}
		
		    if (type == typeof(xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate))
			{
			    return new xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate(__Gen_Delegate_Imp20);
			}
		
		    if (type == typeof(UIRollNumWidget.Finish))
			{
			    return new UIRollNumWidget.Finish(__Gen_Delegate_Imp21);
			}
		
		    if (type == typeof(ContentSizeFitByTarget.ItemCellChange))
			{
			    return new ContentSizeFitByTarget.ItemCellChange(__Gen_Delegate_Imp22);
			}
		
		    if (type == typeof(xc.ui.UILockCDSlot.OnClickFunc))
			{
			    return new xc.ui.UILockCDSlot.OnClickFunc(__Gen_Delegate_Imp23);
			}
		
		    if (type == typeof(xc.ui.UINewLockCDSlot.OnClickFunc))
			{
			    return new xc.ui.UINewLockCDSlot.OnClickFunc(__Gen_Delegate_Imp24);
			}
		
		    if (type == typeof(xc.ui.UIItemNewSlot.OnClickCustomFunc))
			{
			    return new xc.ui.UIItemNewSlot.OnClickCustomFunc(__Gen_Delegate_Imp25);
			}
		
		    if (type == typeof(xc.ui.UIItemNewSlot.OnClickFunc))
			{
			    return new xc.ui.UIItemNewSlot.OnClickFunc(__Gen_Delegate_Imp26);
			}
		
		    if (type == typeof(xc.ui.UIItemNewSlot.OnClickFunc1))
			{
			    return new xc.ui.UIItemNewSlot.OnClickFunc1(__Gen_Delegate_Imp27);
			}
		
		    if (type == typeof(xc.ui.UIItemNewSlot.OnClickFunc2))
			{
			    return new xc.ui.UIItemNewSlot.OnClickFunc2(__Gen_Delegate_Imp28);
			}
		
		    if (type == typeof(xc.ui.ugui.UITweener.OnFinished))
			{
			    return new xc.ui.ugui.UITweener.OnFinished(__Gen_Delegate_Imp29);
			}
		
		    if (type == typeof(DynamicScorll.OnSetItemFunc))
			{
			    return new DynamicScorll.OnSetItemFunc(__Gen_Delegate_Imp30);
			}
		
		    if (type == typeof(System.Action<xc.CommonLuaInstanceState>))
			{
			    return new System.Action<xc.CommonLuaInstanceState>(__Gen_Delegate_Imp31);
			}
		
		    if (type == typeof(System.Action<xc.instance_behaviour.Behaviour>))
			{
			    return new System.Action<xc.instance_behaviour.Behaviour>(__Gen_Delegate_Imp32);
			}
		
		    if (type == typeof(ClientEventMgr.ClientEventFunc))
			{
			    return new ClientEventMgr.ClientEventFunc(__Gen_Delegate_Imp33);
			}
		
		    if (type == typeof(EventCtrl.EventProcessFunc))
			{
			    return new EventCtrl.EventProcessFunc(__Gen_Delegate_Imp33);
			}
		
		    if (type == typeof(xc.Game.DataReplyDelegate))
			{
			    return new xc.Game.DataReplyDelegate(__Gen_Delegate_Imp34);
			}
		
		    if (type == typeof(xc.RouterManager.OpenSysWindowDelegate))
			{
			    return new xc.RouterManager.OpenSysWindowDelegate(__Gen_Delegate_Imp35);
			}
		
		    if (type == typeof(System.Action<xc.ui.ugui.UIBaseWindow>))
			{
			    return new System.Action<xc.ui.ugui.UIBaseWindow>(__Gen_Delegate_Imp36);
			}
		
		    if (type == typeof(System.Action<xc.GoodsLuaEx>))
			{
			    return new System.Action<xc.GoodsLuaEx>(__Gen_Delegate_Imp37);
			}
		
		    if (type == typeof(System.Action<xc.GoodsItem>))
			{
			    return new System.Action<xc.GoodsItem>(__Gen_Delegate_Imp38);
			}
		
		    if (type == typeof(HttpRequest.GETCB))
			{
			    return new HttpRequest.GETCB(__Gen_Delegate_Imp39);
			}
		
		    if (type == typeof(HttpRequest.POSTCB))
			{
			    return new HttpRequest.POSTCB(__Gen_Delegate_Imp40);
			}
		
		    if (type == typeof(xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate))
			{
			    return new xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate(__Gen_Delegate_Imp41);
			}
		
		    if (type == typeof(System.Action<Actor>))
			{
			    return new System.Action<Actor>(__Gen_Delegate_Imp42);
			}
		
		    if (type == typeof(System.Action<xc.ui.UIItemNewSlot>))
			{
			    return new System.Action<xc.ui.UIItemNewSlot>(__Gen_Delegate_Imp43);
			}
		
		    if (type == typeof(System.Action<object[]>))
			{
			    return new System.Action<object[]>(__Gen_Delegate_Imp44);
			}
		
		    if (type == typeof(System.Action<xc.ClientModel>))
			{
			    return new System.Action<xc.ClientModel>(__Gen_Delegate_Imp45);
			}
		
		    if (type == typeof(System.Action<UnityEngine.Sprite>))
			{
			    return new System.Action<UnityEngine.Sprite>(__Gen_Delegate_Imp46);
			}
		
		    if (type == typeof(xc.ActorMachine.ReachTarget))
			{
			    return new xc.ActorMachine.ReachTarget(__Gen_Delegate_Imp47);
			}
		
		    throw new InvalidCastException("This delegate must add to CSharpCallLua: " + type);
		}
	}
    
    
}