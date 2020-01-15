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
    public class xcDBWorldBossWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBWorldBoss), L, translator, 0, 2, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetData", _m_GetData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_sortData", _g_get_m_sortData);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_sortData", _s_set_m_sortData);
            
			XUtils.EndObjectRegister(typeof(xc.DBWorldBoss), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBWorldBoss), L, __CreateInstance, 3, 0, 0);
			
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TAG_PK", xc.DBWorldBoss.TAG_PK);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TAG_PEACE", xc.DBWorldBoss.TAG_PEACE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBWorldBoss));
			
			
			XUtils.EndClassRegister(typeof(xc.DBWorldBoss), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					string strName = LuaAPI.lua_tostring(L, 2);
					string strPath = LuaAPI.lua_tostring(L, 3);
					
					xc.DBWorldBoss __cl_gen_ret = new xc.DBWorldBoss(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBWorldBoss constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBWorldBoss __cl_gen_to_be_invoked = (xc.DBWorldBoss)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBWorldBoss.DBWorldBossItem __cl_gen_ret = __cl_gen_to_be_invoked.GetData( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBWorldBoss __cl_gen_to_be_invoked = (xc.DBWorldBoss)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Unload(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_sortData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss __cl_gen_to_be_invoked = (xc.DBWorldBoss)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_sortData);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_sortData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss __cl_gen_to_be_invoked = (xc.DBWorldBoss)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_sortData = (System.Collections.Generic.List<xc.DBWorldBoss.DBWorldBossItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBWorldBoss.DBWorldBossItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
