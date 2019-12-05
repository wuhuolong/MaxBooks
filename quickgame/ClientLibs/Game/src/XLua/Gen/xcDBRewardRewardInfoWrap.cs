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
    public class xcDBRewardRewardInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBReward.RewardInfo), L, translator, 0, 0, 10, 10);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mItemID", _g_get_mItemID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mGID", _g_get_mGID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mFixedNum", _g_get_mFixedNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mNum", _g_get_mNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mVocation", _g_get_mVocation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mEffectByLevel", _g_get_mEffectByLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsBind", _g_get_mIsBind);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mLvLimit", _g_get_mLvLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mOpenSysId", _g_get_mOpenSysId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mShowColorEffect2", _g_get_mShowColorEffect2);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mItemID", _s_set_mItemID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mGID", _s_set_mGID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mFixedNum", _s_set_mFixedNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mNum", _s_set_mNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mVocation", _s_set_mVocation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mEffectByLevel", _s_set_mEffectByLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsBind", _s_set_mIsBind);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mLvLimit", _s_set_mLvLimit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mOpenSysId", _s_set_mOpenSysId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mShowColorEffect2", _s_set_mShowColorEffect2);
            
			XUtils.EndObjectRegister(typeof(xc.DBReward.RewardInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBReward.RewardInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBReward.RewardInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBReward.RewardInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBReward.RewardInfo __cl_gen_ret = new xc.DBReward.RewardInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<xc.DBReward.RewardInfo>(L, 2))
				{
					xc.DBReward.RewardInfo rewardInfo = (xc.DBReward.RewardInfo)translator.GetObject(L, 2, typeof(xc.DBReward.RewardInfo));
					
					xc.DBReward.RewardInfo __cl_gen_ret = new xc.DBReward.RewardInfo(rewardInfo);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBReward.RewardInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mItemID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mItemID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mGID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mGID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mFixedNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.mFixedNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.mNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mVocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mVocation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mEffectByLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mEffectByLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsBind(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mIsBind);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mLvLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mLvLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mOpenSysId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mOpenSysId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mShowColorEffect2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mShowColorEffect2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mItemID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mItemID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mGID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mGID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mFixedNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mFixedNum = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mNum = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mVocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mVocation = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mEffectByLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mEffectByLevel = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsBind(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsBind = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mLvLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mLvLimit = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mOpenSysId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mOpenSysId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mShowColorEffect2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBReward.RewardInfo __cl_gen_to_be_invoked = (xc.DBReward.RewardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mShowColorEffect2 = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
