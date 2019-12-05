#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcGoodsLuaExWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsLuaEx), L, translator, 0, 9, 2, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateByPkgGoodsInfo", _m_UpdateByPkgGoodsInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CallLuaFunc", _m_CallLuaFunc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLuaValue", _m_GetLuaValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLuaValue", _m_SetLuaValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetValue", _m_SetValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetItemSlot", _m_SetItemSlot);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshMatch", _m_RefreshMatch);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBetterThanBody", _m_IsBetterThanBody);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Copy", _m_Copy);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LuaObject", _g_get_LuaObject);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ExData", _g_get_ExData);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ExData", _s_set_ExData);
            
			XUtils.EndObjectRegister(typeof(xc.GoodsLuaEx), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsLuaEx), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsLuaEx));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsLuaEx), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GoodsLuaEx __cl_gen_ret = new xc.GoodsLuaEx();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					uint typeid = LuaAPI.xlua_touint(L, 2);
					string lua_script = LuaAPI.lua_tostring(L, 3);
					
					xc.GoodsLuaEx __cl_gen_ret = new xc.GoodsLuaEx(typeid, lua_script);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsLuaEx constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateByPkgGoodsInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    XLua.LuaTable goodsInfo = (XLua.LuaTable)translator.GetObject(L, 2, typeof(XLua.LuaTable));
                    
                    __cl_gen_to_be_invoked.UpdateByPkgGoodsInfo( goodsInfo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CallLuaFunc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string func_name = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CallLuaFunc( func_name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLuaValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    
                        object __cl_gen_ret = __cl_gen_to_be_invoked.GetLuaValue( key );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLuaValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    object value = translator.GetObject(L, 3, typeof(object));
                    
                        object __cl_gen_ret = __cl_gen_to_be_invoked.SetLuaValue( key, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    string value = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.SetValue( name, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetItemSlot(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject itemSlot = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    
                    __cl_gen_to_be_invoked.SetItemSlot( itemSlot );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshMatch(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Goods matchGoods = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    UnityEngine.GameObject itemSlot = (UnityEngine.GameObject)translator.GetObject(L, 3, typeof(UnityEngine.GameObject));
                    
                    __cl_gen_to_be_invoked.RefreshMatch( matchGoods, itemSlot );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBetterThanBody(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBetterThanBody(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Copy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsLuaEx cp = (xc.GoodsLuaEx)translator.GetObject(L, 2, typeof(xc.GoodsLuaEx));
                    
                        xc.Goods __cl_gen_ret = __cl_gen_to_be_invoked.Copy( cp );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LuaObject);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ExData);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLuaEx __cl_gen_to_be_invoked = (xc.GoodsLuaEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ExData = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
