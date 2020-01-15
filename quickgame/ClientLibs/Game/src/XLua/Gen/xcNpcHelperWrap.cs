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
    public class xcNpcHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.NpcHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.NpcHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.NpcHelper), L, __CreateInstance, 12, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "MakeNpcDefine", _m_MakeNpcDefine_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetExchangeInfo", _m_GetExchangeInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ProcessNpcFunction", _m_ProcessNpcFunction_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "RunNpcFunction", _m_RunNpcFunction_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetNpcActorId", _m_GetNpcActorId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetNpcName", _m_GetNpcName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetNpcTaskState", _m_GetNpcTaskState_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "NpcCanAcceptBountyTask", _m_NpcCanAcceptBountyTask_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "NpcCanAcceptGuildTask", _m_NpcCanAcceptGuildTask_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "NpcCanAcceptEscortTask", _m_NpcCanAcceptEscortTask_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "NpcCanOpenMarryWin", _m_NpcCanOpenMarryWin_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.NpcHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.NpcHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.NpcHelper __cl_gen_ret = new xc.NpcHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.NpcHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeNpcDefine_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint npcId = LuaAPI.xlua_touint(L, 1);
                    
                        xc.NpcDefine __cl_gen_ret = xc.NpcHelper.MakeNpcDefine( npcId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetExchangeInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.NpcHelper.GetExchangeInfo( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessNpcFunction_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    NpcPlayer npcPlayer = (NpcPlayer)translator.GetObject(L, 1, typeof(NpcPlayer));
                    
                    xc.NpcHelper.ProcessNpcFunction( npcPlayer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunNpcFunction_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.NpcDefine npcDefine = (xc.NpcDefine)translator.GetObject(L, 1, typeof(xc.NpcDefine));
                    
                    xc.NpcHelper.RunNpcFunction( npcDefine );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcActorId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint npcId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.NpcHelper.GetNpcActorId( npcId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 1);
                    uint npcJsonId = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.NpcHelper.GetNpcName( instanceId, npcJsonId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcTaskState_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint npcJsonId = LuaAPI.xlua_touint(L, 1);
                    uint sceneId = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.NpcHelper.GetNpcTaskState( npcJsonId, sceneId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint npcJsonId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.NpcHelper.GetNpcTaskState( npcJsonId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.NpcHelper.GetNpcTaskState!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NpcCanAcceptBountyTask_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint npcJsonId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.NpcHelper.NpcCanAcceptBountyTask( npcJsonId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NpcCanAcceptGuildTask_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint npcJsonId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.NpcHelper.NpcCanAcceptGuildTask( npcJsonId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NpcCanAcceptEscortTask_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint npcJsonId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.NpcHelper.NpcCanAcceptEscortTask( npcJsonId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NpcCanOpenMarryWin_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint npcJsonId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.NpcHelper.NpcCanOpenMarryWin( npcJsonId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
