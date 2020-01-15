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
    public class xcDialogManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DialogManager), L, translator, 0, 7, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TriggerDialogBox", _m_TriggerDialogBox);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TriggerBubble", _m_TriggerBubble);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TriggerDialog", _m_TriggerDialog);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoNextDialog", _m_GotoNextDialog);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SkipDialog", _m_SkipDialog);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FinishDialog", _m_FinishDialog);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CutsceneSequencerName", _g_get_CutsceneSequencerName);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CutsceneSequencerName", _s_set_CutsceneSequencerName);
            
			XUtils.EndObjectRegister(typeof(xc.DialogManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DialogManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DialogManager));
			
			
			XUtils.EndClassRegister(typeof(xc.DialogManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DialogManager __cl_gen_ret = new xc.DialogManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DialogManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DialogManager __cl_gen_to_be_invoked = (xc.DialogManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TriggerDialogBox(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DialogManager __cl_gen_to_be_invoked = (xc.DialogManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.DBDialog.DialogInfo>(L, 2)) 
                {
                    xc.DBDialog.DialogInfo dialogInfo = (xc.DBDialog.DialogInfo)translator.GetObject(L, 2, typeof(xc.DBDialog.DialogInfo));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialogBox( dialogInfo );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& translator.Assignable<xc.DBDialog.DialogInfo>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Actor>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    xc.DBDialog.DialogInfo dialogInfo = (xc.DBDialog.DialogInfo)translator.GetObject(L, 2, typeof(xc.DBDialog.DialogInfo));
                    string customName = LuaAPI.lua_tostring(L, 3);
                    Actor otherPlayer = (Actor)translator.GetObject(L, 4, typeof(Actor));
                    uint actorId = LuaAPI.xlua_touint(L, 5);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialogBox( dialogInfo, customName, otherPlayer, actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<xc.DBDialog.DialogInfo>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Actor>(L, 4)) 
                {
                    xc.DBDialog.DialogInfo dialogInfo = (xc.DBDialog.DialogInfo)translator.GetObject(L, 2, typeof(xc.DBDialog.DialogInfo));
                    string customName = LuaAPI.lua_tostring(L, 3);
                    Actor otherPlayer = (Actor)translator.GetObject(L, 4, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialogBox( dialogInfo, customName, otherPlayer );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 8&& translator.Assignable<xc.DBDialog.DialogInfo>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Actor>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<System.Action>(L, 6)&& translator.Assignable<System.Action>(L, 7)&& translator.Assignable<xc.Task>(L, 8)) 
                {
                    xc.DBDialog.DialogInfo dialogInfo = (xc.DBDialog.DialogInfo)translator.GetObject(L, 2, typeof(xc.DBDialog.DialogInfo));
                    string customName = LuaAPI.lua_tostring(L, 3);
                    Actor otherPlayer = (Actor)translator.GetObject(L, 4, typeof(Actor));
                    uint actorId = LuaAPI.xlua_touint(L, 5);
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 6);
                    System.Action skipedCallback = translator.GetDelegate<System.Action>(L, 7);
                    xc.Task relatedTask = (xc.Task)translator.GetObject(L, 8, typeof(xc.Task));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialogBox( dialogInfo, customName, otherPlayer, actorId, finishedCallback, skipedCallback, relatedTask );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DialogManager.TriggerDialogBox!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TriggerBubble(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DialogManager __cl_gen_to_be_invoked = (xc.DialogManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.DBDialog.DialogInfo>(L, 2)) 
                {
                    xc.DBDialog.DialogInfo dialogInfo = (xc.DBDialog.DialogInfo)translator.GetObject(L, 2, typeof(xc.DBDialog.DialogInfo));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerBubble( dialogInfo );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.DBDialog.DialogInfo>(L, 2)&& translator.Assignable<System.Action>(L, 3)) 
                {
                    xc.DBDialog.DialogInfo dialogInfo = (xc.DBDialog.DialogInfo)translator.GetObject(L, 2, typeof(xc.DBDialog.DialogInfo));
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerBubble( dialogInfo, finishedCallback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DialogManager.TriggerBubble!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TriggerDialog(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DialogManager __cl_gen_to_be_invoked = (xc.DialogManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint dialogId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialog( dialogId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Action>(L, 3)) 
                {
                    uint dialogId = LuaAPI.xlua_touint(L, 2);
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialog( dialogId, finishedCallback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Action>(L, 4)) 
                {
                    uint dialogId = LuaAPI.xlua_touint(L, 2);
                    uint actorId = LuaAPI.xlua_touint(L, 3);
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 4);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialog( dialogId, actorId, finishedCallback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Action>(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)) 
                {
                    uint dialogId = LuaAPI.xlua_touint(L, 2);
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 3);
                    UnityEngine.Transform source = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialog( dialogId, finishedCallback, source );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<System.Action>(L, 5)) 
                {
                    uint dialogId = LuaAPI.xlua_touint(L, 2);
                    string customName = LuaAPI.lua_tostring(L, 3);
                    uint actorId = LuaAPI.xlua_touint(L, 4);
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 5);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialog( dialogId, customName, actorId, finishedCallback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Actor>(L, 4)&& translator.Assignable<System.Action>(L, 5)) 
                {
                    uint dialogId = LuaAPI.xlua_touint(L, 2);
                    string customName = LuaAPI.lua_tostring(L, 3);
                    Actor otherPlayer = (Actor)translator.GetObject(L, 4, typeof(Actor));
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 5);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialog( dialogId, customName, otherPlayer, finishedCallback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Actor>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<System.Action>(L, 6)) 
                {
                    uint dialogId = LuaAPI.xlua_touint(L, 2);
                    string customName = LuaAPI.lua_tostring(L, 3);
                    Actor otherPlayer = (Actor)translator.GetObject(L, 4, typeof(Actor));
                    uint actorId = LuaAPI.xlua_touint(L, 5);
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 6);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialog( dialogId, customName, otherPlayer, actorId, finishedCallback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Actor>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<System.Action>(L, 6)&& translator.Assignable<System.Action>(L, 7)) 
                {
                    uint dialogId = LuaAPI.xlua_touint(L, 2);
                    string customName = LuaAPI.lua_tostring(L, 3);
                    Actor otherPlayer = (Actor)translator.GetObject(L, 4, typeof(Actor));
                    uint actorId = LuaAPI.xlua_touint(L, 5);
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 6);
                    System.Action skipedCallback = translator.GetDelegate<System.Action>(L, 7);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialog( dialogId, customName, otherPlayer, actorId, finishedCallback, skipedCallback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Actor>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<System.Action>(L, 6)&& translator.Assignable<System.Action>(L, 7)&& translator.Assignable<xc.Task>(L, 8)) 
                {
                    uint dialogId = LuaAPI.xlua_touint(L, 2);
                    string customName = LuaAPI.lua_tostring(L, 3);
                    Actor otherPlayer = (Actor)translator.GetObject(L, 4, typeof(Actor));
                    uint actorId = LuaAPI.xlua_touint(L, 5);
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 6);
                    System.Action skipedCallback = translator.GetDelegate<System.Action>(L, 7);
                    xc.Task relatedTask = (xc.Task)translator.GetObject(L, 8, typeof(xc.Task));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TriggerDialog( dialogId, customName, otherPlayer, actorId, finishedCallback, skipedCallback, relatedTask );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DialogManager.TriggerDialog!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoNextDialog(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DialogManager __cl_gen_to_be_invoked = (xc.DialogManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.GotoNextDialog(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SkipDialog(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DialogManager __cl_gen_to_be_invoked = (xc.DialogManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SkipDialog(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinishDialog(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DialogManager __cl_gen_to_be_invoked = (xc.DialogManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FinishDialog(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CutsceneSequencerName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DialogManager __cl_gen_to_be_invoked = (xc.DialogManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CutsceneSequencerName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CutsceneSequencerName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DialogManager __cl_gen_to_be_invoked = (xc.DialogManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CutsceneSequencerName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
