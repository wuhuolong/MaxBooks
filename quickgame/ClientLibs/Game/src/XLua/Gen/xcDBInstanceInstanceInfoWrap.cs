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
    public class xcDBInstanceInstanceInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBInstance.InstanceInfo), L, translator, 0, 2, 44, 44);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTrigram", _m_GetTrigram);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetShowRewardIds", _m_GetShowRewardIds);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mId", _g_get_mId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMaxTime", _g_get_mMaxTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mNeedGoods", _g_get_mNeedGoods);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mDyNeedGoods", _g_get_mDyNeedGoods);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mNeedLv", _g_get_mNeedLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mLvUpLimit", _g_get_mLvUpLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mRecommendAttrs", _g_get_mRecommendAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSingleEnter", _g_get_mSingleEnter);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMinMemberCount", _g_get_mMinMemberCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMaxMemberCount", _g_get_mMaxMemberCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mName", _g_get_mName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mWarType", _g_get_mWarType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mWarSubType", _g_get_mWarSubType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mDesc", _g_get_mDesc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mStages", _g_get_mStages);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mPKType", _g_get_mPKType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mReviveTimes", _g_get_mReviveTimes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mReadyCountDown", _g_get_mReadyCountDown);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mResultCountDown", _g_get_mResultCountDown);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsShowMark", _g_get_mIsShowMark);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mRewardIds", _g_get_mRewardIds);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mShowRewardIds", _g_get_mShowRewardIds);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsReloadSceneWhenTheSame", _g_get_mIsReloadSceneWhenTheSame);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsAutoFight", _g_get_mIsAutoFight);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCanNotRide", _g_get_mCanNotRide);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMiniMapName", _g_get_mMiniMapName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMiniMapWidth", _g_get_mMiniMapWidth);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMiniMapHeight", _g_get_mMiniMapHeight);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMinPos", _g_get_mMinPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMaxPos", _g_get_mMaxPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsCanOpenMiniMap", _g_get_mIsCanOpenMiniMap);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mNeedTrigram", _g_get_mNeedTrigram);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mNeedTaskId", _g_get_mNeedTaskId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mPlanesInstanceId", _g_get_mPlanesInstanceId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mStartTimeline", _g_get_mStartTimeline);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mGuardedNpcId", _g_get_mGuardedNpcId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mShowBossAssistant", _g_get_mShowBossAssistant);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mForbidJumpOutAnimationOut", _g_get_mForbidJumpOutAnimationOut);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mForbidWaterWaveEffect", _g_get_mForbidWaterWaveEffect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSweepCosts", _g_get_mSweepCosts);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSweepLimit", _g_get_mSweepLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsCanSendPosition", _g_get_mIsCanSendPosition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMergeLevel", _g_get_mMergeLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMergeConsume", _g_get_mMergeConsume);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mId", _s_set_mId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMaxTime", _s_set_mMaxTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mNeedGoods", _s_set_mNeedGoods);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mDyNeedGoods", _s_set_mDyNeedGoods);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mNeedLv", _s_set_mNeedLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mLvUpLimit", _s_set_mLvUpLimit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mRecommendAttrs", _s_set_mRecommendAttrs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSingleEnter", _s_set_mSingleEnter);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMinMemberCount", _s_set_mMinMemberCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMaxMemberCount", _s_set_mMaxMemberCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mName", _s_set_mName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mWarType", _s_set_mWarType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mWarSubType", _s_set_mWarSubType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mDesc", _s_set_mDesc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mStages", _s_set_mStages);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mPKType", _s_set_mPKType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mReviveTimes", _s_set_mReviveTimes);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mReadyCountDown", _s_set_mReadyCountDown);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mResultCountDown", _s_set_mResultCountDown);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsShowMark", _s_set_mIsShowMark);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mRewardIds", _s_set_mRewardIds);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mShowRewardIds", _s_set_mShowRewardIds);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsReloadSceneWhenTheSame", _s_set_mIsReloadSceneWhenTheSame);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsAutoFight", _s_set_mIsAutoFight);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mCanNotRide", _s_set_mCanNotRide);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMiniMapName", _s_set_mMiniMapName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMiniMapWidth", _s_set_mMiniMapWidth);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMiniMapHeight", _s_set_mMiniMapHeight);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMinPos", _s_set_mMinPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMaxPos", _s_set_mMaxPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsCanOpenMiniMap", _s_set_mIsCanOpenMiniMap);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mNeedTrigram", _s_set_mNeedTrigram);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mNeedTaskId", _s_set_mNeedTaskId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mPlanesInstanceId", _s_set_mPlanesInstanceId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mStartTimeline", _s_set_mStartTimeline);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mGuardedNpcId", _s_set_mGuardedNpcId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mShowBossAssistant", _s_set_mShowBossAssistant);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mForbidJumpOutAnimationOut", _s_set_mForbidJumpOutAnimationOut);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mForbidWaterWaveEffect", _s_set_mForbidWaterWaveEffect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSweepCosts", _s_set_mSweepCosts);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSweepLimit", _s_set_mSweepLimit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsCanSendPosition", _s_set_mIsCanSendPosition);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMergeLevel", _s_set_mMergeLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMergeConsume", _s_set_mMergeConsume);
            
			XUtils.EndObjectRegister(typeof(xc.DBInstance.InstanceInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBInstance.InstanceInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBInstance.InstanceInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBInstance.InstanceInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBInstance.InstanceInfo __cl_gen_ret = new xc.DBInstance.InstanceInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBInstance.InstanceInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTrigram(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint vocation = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetTrigram( vocation );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetShowRewardIds(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = __cl_gen_to_be_invoked.GetShowRewardIds(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMaxTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mMaxTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mNeedGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mNeedGoods);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mDyNeedGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mDyNeedGoods);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mNeedLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mNeedLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mLvUpLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mLvUpLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mRecommendAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mRecommendAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSingleEnter(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mSingleEnter);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMinMemberCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mMinMemberCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMaxMemberCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mMaxMemberCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mWarType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mWarType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mWarSubType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mWarSubType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mStages(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mStages);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mPKType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mPKType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mReviveTimes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mReviveTimes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mReadyCountDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mReadyCountDown);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mResultCountDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mResultCountDown);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsShowMark(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsShowMark);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mRewardIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mRewardIds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mShowRewardIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mShowRewardIds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsReloadSceneWhenTheSame(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsReloadSceneWhenTheSame);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsAutoFight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsAutoFight);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCanNotRide(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mCanNotRide);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMiniMapName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mMiniMapName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMiniMapWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.mMiniMapWidth);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMiniMapHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.mMiniMapHeight);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMinPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.mMinPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMaxPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.mMaxPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsCanOpenMiniMap(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsCanOpenMiniMap);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mNeedTrigram(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mNeedTrigram);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mNeedTaskId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mNeedTaskId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mPlanesInstanceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mPlanesInstanceId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mStartTimeline(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mStartTimeline);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mGuardedNpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mGuardedNpcId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mShowBossAssistant(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mShowBossAssistant);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mForbidJumpOutAnimationOut(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mForbidJumpOutAnimationOut);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mForbidWaterWaveEffect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mForbidWaterWaveEffect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSweepCosts(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mSweepCosts);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSweepLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.mSweepLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsCanSendPosition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsCanSendPosition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMergeLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mMergeLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMergeConsume(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mMergeConsume);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMaxTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMaxTime = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mNeedGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mNeedGoods = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mDyNeedGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mDyNeedGoods = (System.Collections.Generic.List<System.Collections.Generic.List<uint>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.List<uint>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mNeedLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mNeedLv = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mLvUpLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mLvUpLimit = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mRecommendAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mRecommendAttrs = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSingleEnter(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSingleEnter = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMinMemberCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMinMemberCount = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMaxMemberCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMaxMemberCount = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mWarType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mWarType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mWarSubType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mWarSubType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mDesc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mStages(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mStages = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mPKType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mPKType = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mReviveTimes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mReviveTimes = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mReadyCountDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mReadyCountDown = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mResultCountDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mResultCountDown = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsShowMark(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsShowMark = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mRewardIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mRewardIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mShowRewardIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mShowRewardIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsReloadSceneWhenTheSame(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsReloadSceneWhenTheSame = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsAutoFight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsAutoFight = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mCanNotRide(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mCanNotRide = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMiniMapName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMiniMapName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMiniMapWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMiniMapWidth = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMiniMapHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMiniMapHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMinPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.mMinPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMaxPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.mMaxPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsCanOpenMiniMap(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsCanOpenMiniMap = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mNeedTrigram(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mNeedTrigram = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mNeedTaskId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mNeedTaskId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mPlanesInstanceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mPlanesInstanceId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mStartTimeline(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mStartTimeline = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mGuardedNpcId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mGuardedNpcId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mShowBossAssistant(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mShowBossAssistant = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mForbidJumpOutAnimationOut(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mForbidJumpOutAnimationOut = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mForbidWaterWaveEffect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mForbidWaterWaveEffect = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSweepCosts(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSweepCosts = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSweepLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.mSweepLimit = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsCanSendPosition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsCanSendPosition = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMergeLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMergeLevel = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMergeConsume(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstance.InstanceInfo __cl_gen_to_be_invoked = (xc.DBInstance.InstanceInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMergeConsume = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
