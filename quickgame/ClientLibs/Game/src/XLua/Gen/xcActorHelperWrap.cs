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
    public class xcActorHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ActorHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ActorHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ActorHelper), L, __CreateInstance, 47, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetRaceIdByActorId", _m_GetRaceIdByActorId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDisplayBattlePower", _m_GetDisplayBattlePower_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateUnitCacheInfo", _m_CreateUnitCacheInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreatePetUnitCacheInfo", _m_CreatePetUnitCacheInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetActorAttributeToFloat", _m_GetActorAttributeToFloat_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "MakeActorPropertyValueStringByCustom", _m_MakeActorPropertyValueStringByCustom_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "MakeActorPropertyValueString", _m_MakeActorPropertyValueString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSvrRawId", _m_GetSvrRawId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSvrId", _m_GetSvrId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPKColorName", _m_GetPKColorName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetVocationIconName", _m_GetVocationIconName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "RoleIdToTypeId", _m_RoleIdToTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsShemale", _m_IsShemale_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsPlayer", _m_IsPlayer_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsSummon", _m_IsSummon_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsMySummon", _m_IsMySummon_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "RoleIdToCreateTypeId", _m_RoleIdToCreateTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "TypeIdToRoleId", _m_TypeIdToRoleId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetModelFashionList", _m_GetModelFashionList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPartInList", _m_GetPartInList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetActorMono", _m_GetActorMono_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDeadNotify", _m_GetDeadNotify_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSpawnTimeline", _m_GetSpawnTimeline_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDeadTimeline", _m_GetDeadTimeline_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetIsHideShadow", _m_GetIsHideShadow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetIsHideSelectEffect", _m_GetIsHideSelectEffect_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAddProperty", _m_GetAddProperty_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetRecommendAttrByVocation", _m_GetRecommendAttrByVocation_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsMonsterByActorId", _m_IsMonsterByActorId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsWorldBoss", _m_IsWorldBoss_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsEliteMonster", _m_IsEliteMonster_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsBoss", _m_IsBoss_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsHomeBoss", _m_IsHomeBoss_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsSouthLandBoss", _m_IsSouthLandBoss_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsElementAreaBoss", _m_IsElementAreaBoss_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsServerBoss", _m_IsServerBoss_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetActorName", _m_GetActorName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetActorLevel", _m_GetActorLevel_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetColorNameByActorId", _m_GetColorNameByActorId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetColorNameDiff", _m_GetColorNameDiff_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetColorLvDiff", _m_GetColorLvDiff_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetNearestMonsterByActorIds", _m_GetNearestMonsterByActorIds_xlua_st_);
            
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnitConvert", xc.ActorHelper.UnitConvert);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnitConvertInv", xc.ActorHelper.UnitConvertInv);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DisplayUnitConvert", xc.ActorHelper.DisplayUnitConvert);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DisplayPercentUnitConvert", xc.ActorHelper.DisplayPercentUnitConvert);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ActorHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.ActorHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ActorHelper __cl_gen_ret = new xc.ActorHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRaceIdByActorId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint rid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ActorHelper.GetRaceIdByActorId( rid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDisplayBattlePower_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    long orig = LuaAPI.lua_toint64(L, 1);
                    
                        long __cl_gen_ret = xc.ActorHelper.GetDisplayBattlePower( orig );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateUnitCacheInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<Net.PkgPlayerBrief>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    Net.PkgPlayerBrief info = (Net.PkgPlayerBrief)translator.GetObject(L, 1, typeof(Net.PkgPlayerBrief));
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    
                        xc.UnitCacheInfo __cl_gen_ret = xc.ActorHelper.CreateUnitCacheInfo( info, pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<Net.PkgMonBrief>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    Net.PkgMonBrief info = (Net.PkgMonBrief)translator.GetObject(L, 1, typeof(Net.PkgMonBrief));
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    
                        xc.UnitCacheInfo __cl_gen_ret = xc.ActorHelper.CreateUnitCacheInfo( info, pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorHelper.CreateUnitCacheInfo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePetUnitCacheInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint pet_uid = LuaAPI.xlua_touint(L, 1);
                    uint pet_id = LuaAPI.xlua_touint(L, 2);
                    uint actor_id = LuaAPI.xlua_touint(L, 3);
                    UnityEngine.Vector3 pos;translator.Get(L, 4, out pos);
                    UnityEngine.Quaternion rot;translator.Get(L, 5, out rot);
                    Actor parent = (Actor)translator.GetObject(L, 6, typeof(Actor));
                    
                        xc.UnitCacheInfo __cl_gen_ret = xc.ActorHelper.CreatePetUnitCacheInfo( pet_uid, pet_id, actor_id, pos, rot, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActorAttributeToFloat_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint value = LuaAPI.xlua_touint(L, 1);
                    
                        float __cl_gen_ret = xc.ActorHelper.GetActorAttributeToFloat( value );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeActorPropertyValueStringByCustom_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    uint value = LuaAPI.xlua_touint(L, 2);
                    string str = LuaAPI.lua_tostring(L, 3);
                    
                        string __cl_gen_ret = xc.ActorHelper.MakeActorPropertyValueStringByCustom( id, value, str );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeActorPropertyValueString_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    uint value = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.ActorHelper.MakeActorPropertyValueString( id, value );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSvrRawId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ActorHelper.GetSvrRawId( id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSvrId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ActorHelper.GetSvrId( uuid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPKColorName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint nameColor = LuaAPI.xlua_touint(L, 1);
                    string name = LuaAPI.lua_tostring(L, 2);
                    bool isLocalPlayer = LuaAPI.lua_toboolean(L, 3);
                    
                    xc.ActorHelper.GetPKColorName( nameColor, ref name, isLocalPlayer );
                    LuaAPI.lua_pushstring(L, name);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVocationIconName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint vocation = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.ActorHelper.GetVocationIconName( vocation );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RoleIdToTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint rid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ActorHelper.RoleIdToTypeId( rid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsShemale_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsShemale( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPlayer_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsPlayer( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSummon_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsSummon( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMySummon_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsMySummon( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RoleIdToCreateTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint rid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ActorHelper.RoleIdToCreateTypeId( rid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TypeIdToRoleId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ActorHelper.TypeIdToRoleId( type_id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetModelFashionList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<uint> all_model_list = (System.Collections.Generic.List<uint>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> model_list = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashion_list = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    
                    xc.ActorHelper.GetModelFashionList( all_model_list, model_list, fashion_list );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPartInList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 1)&& translator.Assignable<xc.DBAvatarPart.BODY_PART>(L, 2)) 
                {
                    System.Collections.Generic.List<uint> fashionList = (System.Collections.Generic.List<uint>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<uint>));
                    xc.DBAvatarPart.BODY_PART part;translator.Get(L, 2, out part);
                    
                        uint __cl_gen_ret = xc.ActorHelper.GetPartInList( fashionList, part );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TTABLE)&& translator.Assignable<xc.DBAvatarPart.BODY_PART>(L, 2)) 
                {
                    XLua.LuaTable fashionListLua = (XLua.LuaTable)translator.GetObject(L, 1, typeof(XLua.LuaTable));
                    xc.DBAvatarPart.BODY_PART part;translator.Get(L, 2, out part);
                    
                        uint __cl_gen_ret = xc.ActorHelper.GetPartInList( fashionListLua, part );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorHelper.GetPartInList!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActorMono_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.GameObject>(L, 1)) 
                {
                    UnityEngine.GameObject collider_obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                        xc.ActorMono __cl_gen_ret = xc.ActorHelper.GetActorMono( collider_obj );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Transform>(L, 1)) 
                {
                    UnityEngine.Transform collider_trans = (UnityEngine.Transform)translator.GetObject(L, 1, typeof(UnityEngine.Transform));
                    
                        xc.ActorMono __cl_gen_ret = xc.ActorHelper.GetActorMono( collider_trans );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorHelper.GetActorMono!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDeadNotify_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.ActorHelper.GetDeadNotify( actorId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSpawnTimeline_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ActorHelper.GetSpawnTimeline( actorId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDeadTimeline_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ActorHelper.GetDeadTimeline( actorId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIsHideShadow_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.GetIsHideShadow( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIsHideSelectEffect_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.GetIsHideSelectEffect( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAddProperty_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.Dictionary<uint, float> __cl_gen_ret = xc.ActorHelper.GetAddProperty( key );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRecommendAttrByVocation_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint vocation = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<System.Collections.Generic.Dictionary<uint, float>> __cl_gen_ret = xc.ActorHelper.GetRecommendAttrByVocation( vocation );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMonsterByActorId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsMonsterByActorId( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWorldBoss_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsWorldBoss( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEliteMonster_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsEliteMonster( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBoss_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsBoss( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHomeBoss_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsHomeBoss( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSouthLandBoss_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsSouthLandBoss( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsElementAreaBoss_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsElementAreaBoss( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsServerBoss_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    bool isLocal = LuaAPI.lua_toboolean(L, 2);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsServerBoss( actorId, isLocal );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.ActorHelper.IsServerBoss( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorHelper.IsServerBoss!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActorName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.ActorHelper.GetActorName( actorId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActorLevel_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.ActorHelper.GetActorLevel( actorId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetColorNameByActorId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.ActorHelper.GetColorNameByActorId( actorId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetColorNameDiff_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    uint bk_type = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.ActorHelper.GetColorNameDiff( actorId, bk_type );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetColorLvDiff_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    uint bk_type = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.ActorHelper.GetColorLvDiff( actorId, bk_type );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestMonsterByActorIds_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    XLua.LuaTable actorIds = (XLua.LuaTable)translator.GetObject(L, 1, typeof(XLua.LuaTable));
                    float range = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        Actor __cl_gen_ret = xc.ActorHelper.GetNearestMonsterByActorIds( actorIds, range );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
