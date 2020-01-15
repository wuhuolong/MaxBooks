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
    public class xcDBGuildBossWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGuildBoss), L, translator, 0, 3, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneItem", _m_GetOneItem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneStatisticItem", _m_GetOneStatisticItem);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSortStatisticArray", _g_get_mSortStatisticArray);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSortStatisticArray", _s_set_mSortStatisticArray);
            
			XUtils.EndObjectRegister(typeof(xc.DBGuildBoss), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGuildBoss), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGuildBoss));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGuildBoss), L, translator);
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
					
					xc.DBGuildBoss __cl_gen_ret = new xc.DBGuildBoss(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGuildBoss constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGuildBoss __cl_gen_to_be_invoked = (xc.DBGuildBoss)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetOneItem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGuildBoss __cl_gen_to_be_invoked = (xc.DBGuildBoss)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint boss_type = LuaAPI.xlua_touint(L, 2);
                    uint boss_level = LuaAPI.xlua_touint(L, 3);
                    
                        xc.DBGuildBoss.DBGuildBossItem __cl_gen_ret = __cl_gen_to_be_invoked.GetOneItem( boss_type, boss_level );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOneStatisticItem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGuildBoss __cl_gen_to_be_invoked = (xc.DBGuildBoss)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint boss_type = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_ret = __cl_gen_to_be_invoked.GetOneStatisticItem( boss_type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSortStatisticArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss __cl_gen_to_be_invoked = (xc.DBGuildBoss)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mSortStatisticArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSortStatisticArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss __cl_gen_to_be_invoked = (xc.DBGuildBoss)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSortStatisticArray = (System.Collections.Generic.List<xc.DBGuildBoss.DBGuildBossStatisticItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBGuildBoss.DBGuildBossStatisticItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
