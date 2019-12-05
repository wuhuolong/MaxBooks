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
    public class xcDBGrowSkinDBGrowSkinItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGrowSkin.DBGrowSkinItem), L, translator, 0, 0, 26, 26);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GrowType", _g_get_GrowType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Desc", _g_get_Desc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnlockType", _g_get_UnlockType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnlockGrowLevel", _g_get_UnlockGrowLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnLockGoodsConditionArray", _g_get_UnLockGoodsConditionArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnlockDesc", _g_get_UnlockDesc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Quality", _g_get_Quality);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SortId", _g_get_SortId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActorId", _g_get_ActorId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalPos", _g_get_ModelLocalPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalScale", _g_get_ModelLocalScale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalScaleGoods", _g_get_ModelLocalScaleGoods);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalAngles", _g_get_ModelLocalAngles);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelParentDefaultAngles", _g_get_ModelParentDefaultAngles);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelParentLocalPos", _g_get_ModelParentLocalPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelCameraOffset", _g_get_ModelCameraOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelDefaultAngle", _g_get_ModelDefaultAngle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelSceneOffset", _g_get_ModelSceneOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SurfaceOffset", _g_get_SurfaceOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GetOffset", _g_get_GetOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttrArray", _g_get_AttrArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IdleActionWhenRiding", _g_get_IdleActionWhenRiding);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RunActionWhenRiding", _g_get_RunActionWhenRiding);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SceneModelOffset", _g_get_SceneModelOffset);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GrowType", _s_set_GrowType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Desc", _s_set_Desc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UnlockType", _s_set_UnlockType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UnlockGrowLevel", _s_set_UnlockGrowLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UnLockGoodsConditionArray", _s_set_UnLockGoodsConditionArray);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UnlockDesc", _s_set_UnlockDesc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Quality", _s_set_Quality);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SortId", _s_set_SortId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ActorId", _s_set_ActorId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalPos", _s_set_ModelLocalPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalScale", _s_set_ModelLocalScale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalScaleGoods", _s_set_ModelLocalScaleGoods);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalAngles", _s_set_ModelLocalAngles);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelParentDefaultAngles", _s_set_ModelParentDefaultAngles);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelParentLocalPos", _s_set_ModelParentLocalPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelCameraOffset", _s_set_ModelCameraOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelDefaultAngle", _s_set_ModelDefaultAngle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelSceneOffset", _s_set_ModelSceneOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SurfaceOffset", _s_set_SurfaceOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GetOffset", _s_set_GetOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttrArray", _s_set_AttrArray);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IdleActionWhenRiding", _s_set_IdleActionWhenRiding);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RunActionWhenRiding", _s_set_RunActionWhenRiding);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SceneModelOffset", _s_set_SceneModelOffset);
            
			XUtils.EndObjectRegister(typeof(xc.DBGrowSkin.DBGrowSkinItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGrowSkin.DBGrowSkinItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGrowSkin.DBGrowSkinItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGrowSkin.DBGrowSkinItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBGrowSkin.DBGrowSkinItem __cl_gen_ret = new xc.DBGrowSkin.DBGrowSkinItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGrowSkin.DBGrowSkinItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GrowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GrowType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Desc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnlockType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushxcDBGrowSkinSkinUnLockType(L, __cl_gen_to_be_invoked.UnlockType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnlockGrowLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.UnlockGrowLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnLockGoodsConditionArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UnLockGoodsConditionArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnlockDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UnlockDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Quality);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SortId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActorId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ActorId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalScaleGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalScaleGoods);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalAngles);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelParentDefaultAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelParentDefaultAngles);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelParentLocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelParentLocalPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelCameraOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelCameraOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelDefaultAngle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelDefaultAngle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelSceneOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelSceneOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SurfaceOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.SurfaceOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GetOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.GetOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttrArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AttrArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IdleActionWhenRiding(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.IdleActionWhenRiding);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RunActionWhenRiding(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RunActionWhenRiding);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SceneModelOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.SceneModelOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GrowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GrowType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Desc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnlockType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                xc.DBGrowSkin.SkinUnLockType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.UnlockType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnlockGrowLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UnlockGrowLevel = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnLockGoodsConditionArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UnLockGoodsConditionArray = (System.Collections.Generic.List<xc.DBPet.UnLockGoodsCondition>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBPet.UnLockGoodsCondition>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnlockDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UnlockDesc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Quality = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SortId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ActorId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ActorId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalScale = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalScaleGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalScaleGoods = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalAngles = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelParentDefaultAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelParentDefaultAngles = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelParentLocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelParentLocalPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelCameraOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelCameraOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelDefaultAngle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelDefaultAngle = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelSceneOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelSceneOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SurfaceOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.SurfaceOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GetOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.GetOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttrArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttrArray = (System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IdleActionWhenRiding(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IdleActionWhenRiding = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RunActionWhenRiding(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RunActionWhenRiding = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SceneModelOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGrowSkin.DBGrowSkinItem __cl_gen_to_be_invoked = (xc.DBGrowSkin.DBGrowSkinItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.SceneModelOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
