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
    public class xcDBSuitWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBSuit), L, translator, 0, 2, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneInfo", _m_GetOneInfo);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mInfos", _g_get_mInfos);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mInfos", _s_set_mInfos);
            
			XUtils.EndObjectRegister(typeof(xc.DBSuit), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBSuit), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "MeetColorAndStarCondition", _m_MeetColorAndStarCondition_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBSuit));
			
			
			XUtils.EndClassRegister(typeof(xc.DBSuit), L, translator);
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
					
					xc.DBSuit __cl_gen_ret = new xc.DBSuit(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBSuit constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBSuit __cl_gen_to_be_invoked = (xc.DBSuit)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetOneInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBSuit __cl_gen_to_be_invoked = (xc.DBSuit)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    uint lv = LuaAPI.xlua_touint(L, 3);
                    
                        xc.DBSuit.DBSuitInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetOneInfo( id, lv );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MeetColorAndStarCondition_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint color = LuaAPI.xlua_touint(L, 1);
                    uint star = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<xc.DBSuit.DBSuitInfo.NeedInfo> needInfos = (System.Collections.Generic.List<xc.DBSuit.DBSuitInfo.NeedInfo>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<xc.DBSuit.DBSuitInfo.NeedInfo>));
                    
                        bool __cl_gen_ret = xc.DBSuit.MeetColorAndStarCondition( color, star, needInfos );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit __cl_gen_to_be_invoked = (xc.DBSuit)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSuit __cl_gen_to_be_invoked = (xc.DBSuit)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mInfos = (System.Collections.Generic.Dictionary<string, xc.DBSuit.DBSuitInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, xc.DBSuit.DBSuitInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
