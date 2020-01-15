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
    public class xcAvatarCtrlWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.AvatarCtrl), L, translator, 0, 37, 9, 6);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetModel", _m_GetModel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetModelParent", _m_GetModelParent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetVisible", _m_SetVisible);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAvatartProperty", _m_GetAvatartProperty);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAvatartProperty_onlySelf", _m_GetAvatartProperty_onlySelf);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLatestAvatartProperty", _m_GetLatestAvatartProperty);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsLoading", _m_IsLoading);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsModelVisible", _m_IsModelVisible);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetRenderLayer", _m_SetRenderLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLayer", _m_SetLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateModelFromModleList", _m_CreateModelFromModleList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateModelFromPrefab", _m_CreateModelFromPrefab);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadAsync_public", _m_LoadAsync_public);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAvatarProperty", _m_SetAvatarProperty);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CloneAvatar", _m_CloneAvatar);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangeEquipPart", _m_ChangeEquipPart);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangeFacade", _m_ChangeFacade);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangeFashionPart", _m_ChangeFashionPart);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsLocalPlayerModel", _m_IsLocalPlayerModel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetSuitPos", _m_ResetSuitPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetFootprintEulerAngles", _m_SetFootprintEulerAngles);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveSuitEffect", _m_RemoveSuitEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShapeShift", _m_ShapeShift);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShapeShiftImpl", _m_ShapeShiftImpl);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnShapeShifeImpl", _m_UnShapeShifeImpl);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateVisibleState", _m_UpdateVisibleState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnloadModel", _m_UnloadModel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReloadModel", _m_ReloadModel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetParent", _m_SetParent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetElfinObject", _m_ResetElfinObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetElfinPos", _m_SetElfinPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetElfinEulerAngles", _m_SetElfinEulerAngles);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetMagicalPetObject", _m_ResetMagicalPetObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetMagicalPetPos", _m_SetMagicalPetPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetMagicalPetEulerAngles", _m_SetMagicalPetEulerAngles);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShapeProcessing", _g_get_IsShapeProcessing);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelIsLoading", _g_get_ModelIsLoading);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelIsLoaded", _g_get_ModelIsLoaded);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShapeShift", _g_get_IsShapeShift);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShiftState", _g_get_ShiftState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsProcessingModel", _g_get_IsProcessingModel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelScale", _g_get_ModelScale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mNoShowParts", _g_get_mNoShowParts);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedShowBackAttachment", _g_get_NeedShowBackAttachment);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelIsLoading", _s_set_ModelIsLoading);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelIsLoaded", _s_set_ModelIsLoaded);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelPrefab", _s_set_ModelPrefab);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelScale", _s_set_ModelScale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mNoShowParts", _s_set_mNoShowParts);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NeedShowBackAttachment", _s_set_NeedShowBackAttachment);
            
			XUtils.EndObjectRegister(typeof(xc.AvatarCtrl), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.AvatarCtrl), L, __CreateInstance, 11, 0, 0);
			
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ROOT_NODE", xc.AvatarCtrl.ROOT_NODE);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BODY_NAME", xc.AvatarCtrl.BODY_NAME);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WEAPON_NAME", xc.AvatarCtrl.WEAPON_NAME);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MOUNT_POINT_WING", xc.AvatarCtrl.MOUNT_POINT_WING);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MOUNT_POINT_NAME", xc.AvatarCtrl.MOUNT_POINT_NAME);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BOSS_CHIP_HAND_NAME", xc.AvatarCtrl.BOSS_CHIP_HAND_NAME);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SPIRIT_LINK_NAME", xc.AvatarCtrl.SPIRIT_LINK_NAME);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MAGICAL_PET_LINK_NAME", xc.AvatarCtrl.MAGICAL_PET_LINK_NAME);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AVATAR_PATH_PREFIX", xc.AvatarCtrl.AVATAR_PATH_PREFIX);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BACK_ATTACHMENT_LINK", xc.AvatarCtrl.BACK_ATTACHMENT_LINK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.AvatarCtrl));
			
			
			XUtils.EndClassRegister(typeof(xc.AvatarCtrl), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Actor>(L, 2))
				{
					Actor owner = (Actor)translator.GetObject(L, 2, typeof(Actor));
					
					xc.AvatarCtrl __cl_gen_ret = new xc.AvatarCtrl(owner);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AvatarCtrl constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetModel(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetModelParent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetModelParent(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVisible(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool visible = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetVisible( visible );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAvatartProperty(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.AvatarProperty __cl_gen_ret = __cl_gen_to_be_invoked.GetAvatartProperty(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAvatartProperty_onlySelf(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.AvatarProperty __cl_gen_ret = __cl_gen_to_be_invoked.GetAvatartProperty_onlySelf(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLatestAvatartProperty(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.AvatarProperty __cl_gen_ret = __cl_gen_to_be_invoked.GetLatestAvatartProperty(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLoading(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool considerNotInited = LuaAPI.lua_toboolean(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLoading( considerNotInited );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsModelVisible(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsModelVisible(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRenderLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.GameObject layer_obj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    int layer = LuaAPI.xlua_tointeger(L, 3);
                    bool isIgnoreMatReplace = LuaAPI.lua_toboolean(L, 4);
                    bool castShadow = LuaAPI.lua_toboolean(L, 5);
                    
                    __cl_gen_to_be_invoked.SetRenderLayer( layer_obj, layer, isIgnoreMatReplace, castShadow );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.GameObject layer_obj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    int layer = LuaAPI.xlua_tointeger(L, 3);
                    bool isIgnoreMatReplace = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.SetRenderLayer( layer_obj, layer, isIgnoreMatReplace );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AvatarCtrl.SetRenderLayer!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int layer = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SetLayer( layer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateModelFromModleList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    UnityEngine.Quaternion rot;translator.Get(L, 3, out rot);
                    UnityEngine.Vector3 scale;translator.Get(L, 4, out scale);
                    System.Collections.Generic.List<uint> modleList = (System.Collections.Generic.List<uint>)translator.GetObject(L, 5, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 6, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effects = (System.Collections.Generic.List<uint>)translator.GetObject(L, 7, typeof(System.Collections.Generic.List<uint>));
                    Actor.EVocationType vocation;translator.Get(L, 8, out vocation);
                    System.Action<Actor> cbResLoaded = translator.GetDelegate<System.Action<Actor>>(L, 9);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.CreateModelFromModleList( pos, rot, scale, modleList, fashions, suit_effects, vocation, cbResLoaded );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateModelFromPrefab(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string prefab = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 pos;translator.Get(L, 3, out pos);
                    UnityEngine.Quaternion rot;translator.Get(L, 4, out rot);
                    UnityEngine.Vector3 scale;translator.Get(L, 5, out scale);
                    System.Action<Actor> cbResLoaded = translator.GetDelegate<System.Action<Actor>>(L, 6);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.CreateModelFromPrefab( prefab, pos, rot, scale, cbResLoaded );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAsync_public(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.LoadAsync_public(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAvatarProperty(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& translator.Assignable<xc.AvatarProperty>(L, 2)&& translator.Assignable<Actor.EVocationType>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    xc.AvatarProperty ap = (xc.AvatarProperty)translator.GetObject(L, 2, typeof(xc.AvatarProperty));
                    Actor.EVocationType vocation;translator.Get(L, 3, out vocation);
                    bool change_rider_first = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.SetAvatarProperty( ap, vocation, change_rider_first );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.AvatarProperty>(L, 2)&& translator.Assignable<Actor.EVocationType>(L, 3)) 
                {
                    xc.AvatarProperty ap = (xc.AvatarProperty)translator.GetObject(L, 2, typeof(xc.AvatarProperty));
                    Actor.EVocationType vocation;translator.Get(L, 3, out vocation);
                    
                    __cl_gen_to_be_invoked.SetAvatarProperty( ap, vocation );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 6&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<Actor.EVocationType>(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    System.Collections.Generic.List<uint> equip_modle_ids = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effect_ids = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    Actor.EVocationType vocation;translator.Get(L, 5, out vocation);
                    bool change_rider_first = LuaAPI.lua_toboolean(L, 6);
                    
                    __cl_gen_to_be_invoked.SetAvatarProperty( equip_modle_ids, fashions, suit_effect_ids, vocation, change_rider_first );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 2)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 4)&& translator.Assignable<Actor.EVocationType>(L, 5)) 
                {
                    System.Collections.Generic.List<uint> equip_modle_ids = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashions = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effect_ids = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    Actor.EVocationType vocation;translator.Get(L, 5, out vocation);
                    
                    __cl_gen_to_be_invoked.SetAvatarProperty( equip_modle_ids, fashions, suit_effect_ids, vocation );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AvatarCtrl.SetAvatarProperty!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloneAvatar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<Actor>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    Actor clonedActor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    bool changeRiderFirst = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.CloneAvatar( clonedActor, changeRiderFirst );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<Actor>(L, 2)) 
                {
                    Actor clonedActor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                    __cl_gen_to_be_invoked.CloneAvatar( clonedActor );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AvatarCtrl.CloneAvatar!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeEquipPart(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBAvatarPart.BODY_PART part;translator.Get(L, 2, out part);
                    uint quip_model_id = LuaAPI.xlua_touint(L, 3);
                    Actor.EVocationType vocation;translator.Get(L, 4, out vocation);
                    
                    __cl_gen_to_be_invoked.ChangeEquipPart( part, quip_model_id, vocation );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeFacade(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.List<uint> equipModleIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> fashionIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    System.Collections.Generic.List<uint> suit_effests = (System.Collections.Generic.List<uint>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<uint>));
                    Actor.EVocationType vocation;translator.Get(L, 5, out vocation);
                    
                    __cl_gen_to_be_invoked.ChangeFacade( equipModleIds, fashionIds, suit_effests, vocation );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeFashionPart(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBAvatarPart.BODY_PART part;translator.Get(L, 2, out part);
                    uint dressId = LuaAPI.xlua_touint(L, 3);
                    Actor.EVocationType vocation;translator.Get(L, 4, out vocation);
                    
                    __cl_gen_to_be_invoked.ChangeFashionPart( part, dressId, vocation );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLocalPlayerModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLocalPlayerModel(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetSuitPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    bool is_wait_one_frame = LuaAPI.lua_toboolean(L, 2);
                    uint delay_frame_count = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.ResetSuitPos( is_wait_one_frame, delay_frame_count );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool is_wait_one_frame = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ResetSuitPos( is_wait_one_frame );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.ResetSuitPos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AvatarCtrl.ResetSuitPos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFootprintEulerAngles(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 angle;translator.Get(L, 2, out angle);
                    
                    __cl_gen_to_be_invoked.SetFootprintEulerAngles( angle );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveSuitEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RemoveSuitEffect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShapeShift(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool shift = LuaAPI.lua_toboolean(L, 2);
                    uint type_id = LuaAPI.xlua_touint(L, 3);
                    byte shift_state = (byte)LuaAPI.lua_tonumber(L, 4);
                    
                    __cl_gen_to_be_invoked.ShapeShift( shift, type_id, shift_state );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShapeShiftImpl(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 2);
                    byte shift_state = (byte)LuaAPI.lua_tonumber(L, 3);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.ShapeShiftImpl( type_id, shift_state );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnShapeShifeImpl(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 2);
                    byte shift_state = (byte)LuaAPI.lua_tonumber(L, 3);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.UnShapeShifeImpl( type_id, shift_state );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_UpdateVisibleState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateVisibleState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnloadModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UnloadModel(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReloadModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ReloadModel(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetParent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    UnityEngine.Vector3 local_scale;translator.Get(L, 3, out local_scale);
                    UnityEngine.Vector3 local_pos;translator.Get(L, 4, out local_pos);
                    UnityEngine.Vector3 local_eulerAngles;translator.Get(L, 5, out local_eulerAngles);
                    
                    __cl_gen_to_be_invoked.SetParent( parent, local_scale, local_pos, local_eulerAngles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetElfinObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetElfinObject(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetElfinPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    
                    __cl_gen_to_be_invoked.SetElfinPos( pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetElfinEulerAngles(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 eulerAngles;translator.Get(L, 2, out eulerAngles);
                    
                    __cl_gen_to_be_invoked.SetElfinEulerAngles( eulerAngles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetMagicalPetObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetMagicalPetObject(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMagicalPetPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    
                    __cl_gen_to_be_invoked.SetMagicalPetPos( pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMagicalPetEulerAngles(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 eulerAngles;translator.Get(L, 2, out eulerAngles);
                    
                    __cl_gen_to_be_invoked.SetMagicalPetEulerAngles( eulerAngles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShapeProcessing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShapeProcessing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelIsLoading(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ModelIsLoading);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelIsLoaded(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ModelIsLoaded);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShapeShift(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShapeShift);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShiftState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ShiftState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsProcessingModel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsProcessingModel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mNoShowParts(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mNoShowParts);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedShowBackAttachment(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NeedShowBackAttachment);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelIsLoading(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ModelIsLoading = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelIsLoaded(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ModelIsLoaded = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelPrefab(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ModelPrefab = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelScale = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mNoShowParts(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mNoShowParts = (System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBAvatarPart.BODY_PART>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NeedShowBackAttachment(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl __cl_gen_to_be_invoked = (xc.AvatarCtrl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NeedShowBackAttachment = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
