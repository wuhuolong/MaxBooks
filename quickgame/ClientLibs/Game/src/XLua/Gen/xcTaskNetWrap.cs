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
    public class xcTaskNetWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.TaskNet), L, translator, 0, 13, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterMessages", _m_RegisterMessages);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AcceptTask", _m_AcceptTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SubmitTask", _m_SubmitTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DoTaskGoal", _m_DoTaskGoal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AcceptBountyTask", _m_AcceptBountyTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReceiveBountyTaskReward", _m_ReceiveBountyTaskReward);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FinishBounty", _m_FinishBounty);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AcceptGuildTask", _m_AcceptGuildTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReceiveGuildTaskReward", _m_ReceiveGuildTaskReward);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FinishGuild", _m_FinishGuild);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AcceptTransferTask", _m_AcceptTransferTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReceiveTransferTaskReward", _m_ReceiveTransferTaskReward);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FinishTransfer", _m_FinishTransfer);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.TaskNet), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.TaskNet), L, __CreateInstance, 2, 4, 4);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HandleServerData", _m_HandleServerData_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TaskNet));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "IsFirstReceiveTaskInfo", _g_get_IsFirstReceiveTaskInfo);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "IsFirstReceiveBountyTaskInfo", _g_get_IsFirstReceiveBountyTaskInfo);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "IsFirstReceiveGuildTaskInfo", _g_get_IsFirstReceiveGuildTaskInfo);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "HaveReceivedTaskInfo", _g_get_HaveReceivedTaskInfo);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "IsFirstReceiveTaskInfo", _s_set_IsFirstReceiveTaskInfo);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "IsFirstReceiveBountyTaskInfo", _s_set_IsFirstReceiveBountyTaskInfo);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "IsFirstReceiveGuildTaskInfo", _s_set_IsFirstReceiveGuildTaskInfo);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "HaveReceivedTaskInfo", _s_set_HaveReceivedTaskInfo);
            
			XUtils.EndClassRegister(typeof(xc.TaskNet), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.TaskNet __cl_gen_ret = new xc.TaskNet();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskNet constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterMessages(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_AcceptTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.AcceptTask( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubmitTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SubmitTask( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoTaskGoal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string goal = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.DoTaskGoal( goal );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string goal = LuaAPI.lua_tostring(L, 2);
                    int arg = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.DoTaskGoal( goal, arg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskNet.DoTaskGoal!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AcceptBountyTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.AcceptBountyTask(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReceiveBountyTaskReward(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ReceiveBountyTaskReward(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinishBounty(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FinishBounty(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AcceptGuildTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.AcceptGuildTask(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReceiveGuildTaskReward(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ReceiveGuildTaskReward(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinishGuild(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FinishGuild(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AcceptTransferTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.AcceptTransferTask(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReceiveTransferTaskReward(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ReceiveTransferTaskReward(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinishTransfer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskNet __cl_gen_to_be_invoked = (xc.TaskNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FinishTransfer(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleServerData_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    byte[] data = LuaAPI.lua_tobytes(L, 2);
                    
                    xc.TaskNet.HandleServerData( protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFirstReceiveTaskInfo(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.TaskNet.IsFirstReceiveTaskInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFirstReceiveBountyTaskInfo(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.TaskNet.IsFirstReceiveBountyTaskInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFirstReceiveGuildTaskInfo(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.TaskNet.IsFirstReceiveGuildTaskInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HaveReceivedTaskInfo(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.TaskNet.HaveReceivedTaskInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsFirstReceiveTaskInfo(RealStatePtr L)
        {
            
            try {
			    xc.TaskNet.IsFirstReceiveTaskInfo = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsFirstReceiveBountyTaskInfo(RealStatePtr L)
        {
            
            try {
			    xc.TaskNet.IsFirstReceiveBountyTaskInfo = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsFirstReceiveGuildTaskInfo(RealStatePtr L)
        {
            
            try {
			    xc.TaskNet.IsFirstReceiveGuildTaskInfo = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HaveReceivedTaskInfo(RealStatePtr L)
        {
            
            try {
			    xc.TaskNet.HaveReceivedTaskInfo = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
