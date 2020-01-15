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
    public class xcTeamHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.TeamHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.TeamHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.TeamHelper), L, __CreateInstance, 3, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTeamTargetInstanceId", _m_GetTeamTargetInstanceId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTeamTargetMemberLimit", _m_GetTeamTargetMemberLimit_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TeamHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.TeamHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.TeamHelper __cl_gen_ret = new xc.TeamHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TeamHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTeamTargetInstanceId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = xc.TeamHelper.GetTeamTargetInstanceId(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTeamTargetMemberLimit_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = xc.TeamHelper.GetTeamTargetMemberLimit(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
