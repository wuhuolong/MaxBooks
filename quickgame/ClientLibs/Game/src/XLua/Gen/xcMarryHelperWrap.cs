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
    public class xcMarryHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.MarryHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.MarryHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.MarryHelper), L, __CreateInstance, 5, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GotoMarryNpcGuide", _m_GotoMarryNpcGuide_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CanJumpToMarryScene", _m_CanJumpToMarryScene_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ProcessTouchMarryNpc", _m_ProcessTouchMarryNpc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetWeddingCoupleJobs", _m_GetWeddingCoupleJobs_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MarryHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.MarryHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.MarryHelper __cl_gen_ret = new xc.MarryHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MarryHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoMarryNpcGuide_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.MarryHelper.GotoMarryNpcGuide(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanJumpToMarryScene_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    bool needTips = LuaAPI.lua_toboolean(L, 1);
                    
                        bool __cl_gen_ret = xc.MarryHelper.CanJumpToMarryScene( needTips );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessTouchMarryNpc_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    NpcPlayer npcPlayer = (NpcPlayer)translator.GetObject(L, 1, typeof(NpcPlayer));
                    
                        bool __cl_gen_ret = xc.MarryHelper.ProcessTouchMarryNpc( npcPlayer );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWeddingCoupleJobs_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint job1;
                    uint job2;
                    
                    xc.MarryHelper.GetWeddingCoupleJobs( out job1, out job2 );
                    LuaAPI.xlua_pushuint(L, job1);
                        
                    LuaAPI.xlua_pushuint(L, job2);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
