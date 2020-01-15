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
    public class xcDBEquipPosWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBEquipPos), L, translator, 0, 2, 2, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneInfo", _m_GetOneInfo);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AllEquipPosInfos", _g_get_AllEquipPosInfos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mInfos", _g_get_mInfos);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mInfos", _s_set_mInfos);
            
			XUtils.EndObjectRegister(typeof(xc.DBEquipPos), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBEquipPos), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBEquipPos));
			
			
			XUtils.EndClassRegister(typeof(xc.DBEquipPos), L, translator);
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
					
					xc.DBEquipPos __cl_gen_ret = new xc.DBEquipPos(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBEquipPos constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBEquipPos __cl_gen_to_be_invoked = (xc.DBEquipPos)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            xc.DBEquipPos __cl_gen_to_be_invoked = (xc.DBEquipPos)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint posId = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBEquipPos.DBEquipPosItem __cl_gen_ret = __cl_gen_to_be_invoked.GetOneInfo( posId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllEquipPosInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos __cl_gen_to_be_invoked = (xc.DBEquipPos)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AllEquipPosInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEquipPos __cl_gen_to_be_invoked = (xc.DBEquipPos)translator.FastGetCSObj(L, 1);
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
			
                xc.DBEquipPos __cl_gen_to_be_invoked = (xc.DBEquipPos)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mInfos = (System.Collections.Generic.Dictionary<uint, xc.DBEquipPos.DBEquipPosItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, xc.DBEquipPos.DBEquipPosItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
