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
    public class xcCustomDataMgrWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.CustomDataMgr), L, translator, 0, 7, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterMessages", _m_RegisterMessages);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddCustomData", _m_AddCustomData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveCustomData", _m_RemoveCustomData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCustomData", _m_GetCustomData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsExistCustomData", _m_IsExistCustomData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PutCustomoData", _m_PutCustomoData);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.CustomDataMgr), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.CustomDataMgr), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.CustomDataMgr));
			
			
			XUtils.EndClassRegister(typeof(xc.CustomDataMgr), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.CustomDataMgr __cl_gen_ret = new xc.CustomDataMgr();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.CustomDataMgr constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterMessages(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CustomDataMgr __cl_gen_to_be_invoked = (xc.CustomDataMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterMessages(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CustomDataMgr __cl_gen_to_be_invoked = (xc.CustomDataMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddCustomData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CustomDataMgr __cl_gen_to_be_invoked = (xc.CustomDataMgr)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& translator.Assignable<xc.CustomDataType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    xc.CustomDataType dataType;translator.Get(L, 2, out dataType);
                    int value = LuaAPI.xlua_tointeger(L, 3);
                    bool bPutServer = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.AddCustomData( dataType, value, bPutServer );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.CustomDataType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.CustomDataType dataType;translator.Get(L, 2, out dataType);
                    int value = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.AddCustomData( dataType, value );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<xc.CustomDataType>(L, 2)&& translator.Assignable<System.Collections.Generic.List<int>>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    xc.CustomDataType dataType;translator.Get(L, 2, out dataType);
                    System.Collections.Generic.List<int> data = (System.Collections.Generic.List<int>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<int>));
                    bool bPutServer = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.AddCustomData( dataType, data, bPutServer );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.CustomDataType>(L, 2)&& translator.Assignable<System.Collections.Generic.List<int>>(L, 3)) 
                {
                    xc.CustomDataType dataType;translator.Get(L, 2, out dataType);
                    System.Collections.Generic.List<int> data = (System.Collections.Generic.List<int>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<int>));
                    
                    __cl_gen_to_be_invoked.AddCustomData( dataType, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.CustomDataMgr.AddCustomData!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveCustomData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CustomDataMgr __cl_gen_to_be_invoked = (xc.CustomDataMgr)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& translator.Assignable<xc.CustomDataType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    xc.CustomDataType dataType;translator.Get(L, 2, out dataType);
                    int value = LuaAPI.xlua_tointeger(L, 3);
                    bool bPutServer = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.RemoveCustomData( dataType, value, bPutServer );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.CustomDataType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.CustomDataType dataType;translator.Get(L, 2, out dataType);
                    int value = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.RemoveCustomData( dataType, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.CustomDataMgr.RemoveCustomData!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCustomData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CustomDataMgr __cl_gen_to_be_invoked = (xc.CustomDataMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.CustomDataType type;translator.Get(L, 2, out type);
                    
                        System.Collections.Generic.List<int> __cl_gen_ret = __cl_gen_to_be_invoked.GetCustomData( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsExistCustomData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CustomDataMgr __cl_gen_to_be_invoked = (xc.CustomDataMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.CustomDataType type;translator.Get(L, 2, out type);
                    int value = LuaAPI.xlua_tointeger(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsExistCustomData( type, value );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PutCustomoData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CustomDataMgr __cl_gen_to_be_invoked = (xc.CustomDataMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.CustomDataType dataType;translator.Get(L, 2, out dataType);
                    
                    __cl_gen_to_be_invoked.PutCustomoData( dataType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
