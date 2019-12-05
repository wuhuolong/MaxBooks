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
    public class XLuaLuaTableWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(XLua.LuaTable), L, translator, 0, 3, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetKeys", _m_GetKeys);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetMetaTable", _m_SetMetaTable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToString", _m_ToString);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Length", _g_get_Length);
            
			
			XUtils.EndObjectRegister(typeof(XLua.LuaTable), L, translator, __CSIndexer, __NewIndexer,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(XLua.LuaTable), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(XLua.LuaTable));
			
			
			XUtils.EndClassRegister(typeof(XLua.LuaTable), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<XLua.LuaEnv>(L, 3))
				{
					int reference = LuaAPI.xlua_tointeger(L, 2);
					XLua.LuaEnv luaenv = (XLua.LuaEnv)translator.GetObject(L, 3, typeof(XLua.LuaEnv));
					
					XLua.LuaTable __cl_gen_ret = new XLua.LuaTable(reference, luaenv);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to XLua.LuaTable constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				
				if ((LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TTABLE) && translator.Assignable<object>(L, 2))
				{
					
					XLua.LuaTable __cl_gen_to_be_invoked = (XLua.LuaTable)translator.FastGetCSObj(L, 1);
					object index = translator.GetObject(L, 2, typeof(object));
					LuaAPI.lua_pushboolean(L, true);
					translator.PushAny(L, __cl_gen_to_be_invoked[index]);
					return 2;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
			
            LuaAPI.lua_pushboolean(L, false);
			return 1;
        }
		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __NewIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
			try {
				
				if ((LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TTABLE) && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && translator.Assignable<object>(L, 3))
				{
					
					XLua.LuaTable __cl_gen_to_be_invoked = (XLua.LuaTable)translator.FastGetCSObj(L, 1);
					string key = LuaAPI.lua_tostring(L, 2);
					__cl_gen_to_be_invoked[key] = translator.GetObject(L, 3, typeof(object));
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
				if ((LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TTABLE) && translator.Assignable<object>(L, 2) && translator.Assignable<object>(L, 3))
				{
					
					XLua.LuaTable __cl_gen_to_be_invoked = (XLua.LuaTable)translator.FastGetCSObj(L, 1);
					object key = translator.GetObject(L, 2, typeof(object));
					__cl_gen_to_be_invoked[key] = translator.GetObject(L, 3, typeof(object));
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
			
			LuaAPI.lua_pushboolean(L, false);
            return 1;
        }
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetKeys(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            XLua.LuaTable __cl_gen_to_be_invoked = (XLua.LuaTable)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.IEnumerable __cl_gen_ret = __cl_gen_to_be_invoked.GetKeys(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMetaTable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            XLua.LuaTable __cl_gen_to_be_invoked = (XLua.LuaTable)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    XLua.LuaTable metaTable = (XLua.LuaTable)translator.GetObject(L, 2, typeof(XLua.LuaTable));
                    
                    __cl_gen_to_be_invoked.SetMetaTable( metaTable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            XLua.LuaTable __cl_gen_to_be_invoked = (XLua.LuaTable)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Length(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                XLua.LuaTable __cl_gen_to_be_invoked = (XLua.LuaTable)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Length);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
