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
    public class xcMoveCtrlWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.MoveCtrl), L, translator, 0, 12, 2, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Interrupt", _m_Interrupt);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryWalkAlong", _m_TryWalkAlong);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryWalkAlongStop", _m_TryWalkAlongStop);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryWalkToAlong", _m_TryWalkToAlong);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendWalkEnd", _m_SendWalkEnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendFly", _m_SendFly);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MoveDirInAttacking", _m_MoveDirInAttacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReceiveWalkBegin", _m_ReceiveWalkBegin);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReceiveWalkEnd", _m_ReceiveWalkEnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReceiveSetPos", _m_ReceiveSetPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnMoveDirChange", _g_get_OnMoveDirChange);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnMoveEnd", _g_get_OnMoveEnd);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsMoving", _s_set_IsMoving);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnMoveDirChange", _s_set_OnMoveDirChange);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnMoveEnd", _s_set_OnMoveEnd);
            
			XUtils.EndObjectRegister(typeof(xc.MoveCtrl), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.MoveCtrl), L, __CreateInstance, 6, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "RegisterAllMessage", _m_RegisterAllMessage_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HandleServerData", _m_HandleServerData_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReceiveWalkBegin", _m_ReceiveWalkBegin_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReceiveWalkEnd", _m_ReceiveWalkEnd_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReceiveSetPos", _m_ReceiveSetPos_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MoveCtrl));
			
			
			XUtils.EndClassRegister(typeof(xc.MoveCtrl), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Actor>(L, 2))
				{
					Actor owner = (Actor)translator.GetObject(L, 2, typeof(Actor));
					
					xc.MoveCtrl __cl_gen_ret = new xc.MoveCtrl(owner);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MoveCtrl constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Interrupt(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Interrupt(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryWalkAlong(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 dir;translator.Get(L, 2, out dir);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryWalkAlong( dir );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 dir;translator.Get(L, 2, out dir);
                    bool force_sendmsg = LuaAPI.lua_toboolean(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryWalkAlong( dir, force_sendmsg );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MoveCtrl.TryWalkAlong!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryWalkAlongStop(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryWalkAlongStop(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryWalkToAlong(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<System.Action>(L, 3)) 
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    System.Action reachCallback = translator.GetDelegate<System.Action>(L, 3);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.TryWalkToAlong( pos, reachCallback );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.TryWalkToAlong( pos );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MoveCtrl.TryWalkToAlong!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendWalkEnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SendWalkEnd(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendFly(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    
                    __cl_gen_to_be_invoked.SendFly( pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveDirInAttacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 dir;translator.Get(L, 2, out dir);
                    
                    __cl_gen_to_be_invoked.MoveDirInAttacking( dir );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReceiveWalkBegin(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.PkgNwarMove moves = (Net.PkgNwarMove)translator.GetObject(L, 2, typeof(Net.PkgNwarMove));
                    
                    __cl_gen_to_be_invoked.ReceiveWalkBegin( moves );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReceiveWalkEnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.S2CNwarMoveStop walk = (Net.S2CNwarMoveStop)translator.GetObject(L, 2, typeof(Net.S2CNwarMoveStop));
                    
                    __cl_gen_to_be_invoked.ReceiveWalkEnd( walk );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReceiveSetPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.S2CNwarSetPos pack = (Net.S2CNwarSetPos)translator.GetObject(L, 2, typeof(Net.S2CNwarSetPos));
                    
                    __cl_gen_to_be_invoked.ReceiveSetPos( pack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessage_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.MoveCtrl.RegisterAllMessage(  );
                    
                    
                    
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
                    
                    xc.MoveCtrl.HandleServerData( protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReceiveWalkBegin_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    byte[] data = LuaAPI.lua_tobytes(L, 1);
                    
                    xc.MoveCtrl.ReceiveWalkBegin( data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReceiveWalkEnd_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    byte[] data = LuaAPI.lua_tobytes(L, 1);
                    
                    xc.MoveCtrl.ReceiveWalkEnd( data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReceiveSetPos_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    byte[] data = LuaAPI.lua_tobytes(L, 1);
                    
                    xc.MoveCtrl.ReceiveSetPos( data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnMoveDirChange(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnMoveDirChange);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnMoveEnd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnMoveEnd);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsMoving(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsMoving = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnMoveDirChange(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnMoveDirChange = translator.GetDelegate<xc.MoveCtrl.MoveDirCallback>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnMoveEnd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl __cl_gen_to_be_invoked = (xc.MoveCtrl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnMoveEnd = translator.GetDelegate<xc.MoveCtrl.MoveDirCallback>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
