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
    
    public class xcGameEGameModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.Game.EGameMode), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.Game.EGameMode), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.Game.EGameMode), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GM_Debug", xc.Game.EGameMode.GM_Debug);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GM_Net", xc.Game.EGameMode.GM_Net);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Game.EGameMode));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.Game.EGameMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcGameEGameMode(L, (xc.Game.EGameMode)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "GM_Debug"))
                {
                    translator.PushxcGameEGameMode(L, xc.Game.EGameMode.GM_Debug);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GM_Net"))
                {
                    translator.PushxcGameEGameMode(L, xc.Game.EGameMode.GM_Net);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.Game.EGameMode!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.Game.EGameMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineRectTransformAxisWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.RectTransform.Axis), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.RectTransform.Axis), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.RectTransform.Axis), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Horizontal", UnityEngine.RectTransform.Axis.Horizontal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Vertical", UnityEngine.RectTransform.Axis.Vertical);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.RectTransform.Axis));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.RectTransform.Axis), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineRectTransformAxis(L, (UnityEngine.RectTransform.Axis)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushUnityEngineRectTransformAxis(L, UnityEngine.RectTransform.Axis.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushUnityEngineRectTransformAxis(L, UnityEngine.RectTransform.Axis.Vertical);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.RectTransform.Axis!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.RectTransform.Axis! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineRectTransformEdgeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.RectTransform.Edge), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.RectTransform.Edge), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.RectTransform.Edge), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Left", UnityEngine.RectTransform.Edge.Left);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Right", UnityEngine.RectTransform.Edge.Right);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Top", UnityEngine.RectTransform.Edge.Top);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Bottom", UnityEngine.RectTransform.Edge.Bottom);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.RectTransform.Edge));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.RectTransform.Edge), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineRectTransformEdge(L, (UnityEngine.RectTransform.Edge)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineRectTransformEdge(L, UnityEngine.RectTransform.Edge.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineRectTransformEdge(L, UnityEngine.RectTransform.Edge.Right);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushUnityEngineRectTransformEdge(L, UnityEngine.RectTransform.Edge.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushUnityEngineRectTransformEdge(L, UnityEngine.RectTransform.Edge.Bottom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.RectTransform.Edge!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.RectTransform.Edge! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineRuntimePlatformWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.RuntimePlatform), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.RuntimePlatform), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.RuntimePlatform), L, null, 36, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "OSXEditor", UnityEngine.RuntimePlatform.OSXEditor);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "OSXPlayer", UnityEngine.RuntimePlatform.OSXPlayer);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WindowsPlayer", UnityEngine.RuntimePlatform.WindowsPlayer);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WindowsEditor", UnityEngine.RuntimePlatform.WindowsEditor);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "IPhonePlayer", UnityEngine.RuntimePlatform.IPhonePlayer);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Android", UnityEngine.RuntimePlatform.Android);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LinuxPlayer", UnityEngine.RuntimePlatform.LinuxPlayer);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LinuxEditor", UnityEngine.RuntimePlatform.LinuxEditor);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WebGLPlayer", UnityEngine.RuntimePlatform.WebGLPlayer);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WSAPlayerX86", UnityEngine.RuntimePlatform.WSAPlayerX86);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WSAPlayerX64", UnityEngine.RuntimePlatform.WSAPlayerX64);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WSAPlayerARM", UnityEngine.RuntimePlatform.WSAPlayerARM);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TizenPlayer", UnityEngine.RuntimePlatform.TizenPlayer);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PSP2", UnityEngine.RuntimePlatform.PSP2);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PS4", UnityEngine.RuntimePlatform.PS4);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PSM", UnityEngine.RuntimePlatform.PSM);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "XboxOne", UnityEngine.RuntimePlatform.XboxOne);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WiiU", UnityEngine.RuntimePlatform.WiiU);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "tvOS", UnityEngine.RuntimePlatform.tvOS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Switch", UnityEngine.RuntimePlatform.Switch);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.RuntimePlatform));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.RuntimePlatform), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineRuntimePlatform(L, (UnityEngine.RuntimePlatform)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "OSXEditor"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.OSXEditor);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OSXPlayer"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.OSXPlayer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WindowsPlayer"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.WindowsPlayer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WindowsEditor"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.WindowsEditor);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPhonePlayer"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.IPhonePlayer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Android"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.Android);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LinuxPlayer"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.LinuxPlayer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LinuxEditor"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.LinuxEditor);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WebGLPlayer"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.WebGLPlayer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WSAPlayerX86"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.WSAPlayerX86);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WSAPlayerX64"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.WSAPlayerX64);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WSAPlayerARM"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.WSAPlayerARM);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TizenPlayer"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.TizenPlayer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PSP2"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.PSP2);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PS4"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.PS4);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PSM"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.PSM);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "XboxOne"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.XboxOne);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WiiU"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.WiiU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "tvOS"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.tvOS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Switch"))
                {
                    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.RuntimePlatform.Switch);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.RuntimePlatform!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.RuntimePlatform! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineAnimatorCullingModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.AnimatorCullingMode), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.AnimatorCullingMode), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.AnimatorCullingMode), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AlwaysAnimate", UnityEngine.AnimatorCullingMode.AlwaysAnimate);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CullUpdateTransforms", UnityEngine.AnimatorCullingMode.CullUpdateTransforms);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CullCompletely", UnityEngine.AnimatorCullingMode.CullCompletely);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.AnimatorCullingMode));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.AnimatorCullingMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineAnimatorCullingMode(L, (UnityEngine.AnimatorCullingMode)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "AlwaysAnimate"))
                {
                    translator.PushUnityEngineAnimatorCullingMode(L, UnityEngine.AnimatorCullingMode.AlwaysAnimate);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CullUpdateTransforms"))
                {
                    translator.PushUnityEngineAnimatorCullingMode(L, UnityEngine.AnimatorCullingMode.CullUpdateTransforms);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CullCompletely"))
                {
                    translator.PushUnityEngineAnimatorCullingMode(L, UnityEngine.AnimatorCullingMode.CullCompletely);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.AnimatorCullingMode!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.AnimatorCullingMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineTexture2DEXRFlagsWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.Texture2D.EXRFlags), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.Texture2D.EXRFlags), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.Texture2D.EXRFlags), L, null, 7, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", UnityEngine.Texture2D.EXRFlags.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "OutputAsFloat", UnityEngine.Texture2D.EXRFlags.OutputAsFloat);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CompressZIP", UnityEngine.Texture2D.EXRFlags.CompressZIP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CompressRLE", UnityEngine.Texture2D.EXRFlags.CompressRLE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CompressPIZ", UnityEngine.Texture2D.EXRFlags.CompressPIZ);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.Texture2D.EXRFlags));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.Texture2D.EXRFlags), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineTexture2DEXRFlags(L, (UnityEngine.Texture2D.EXRFlags)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OutputAsFloat"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.OutputAsFloat);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CompressZIP"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.CompressZIP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CompressRLE"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.CompressRLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CompressPIZ"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.CompressPIZ);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.Texture2D.EXRFlags!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.Texture2D.EXRFlags! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class NetNetClientENetStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Net.NetClient.ENetState), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Net.NetClient.ENetState), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Net.NetClient.ENetState), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ES_UnInit", Net.NetClient.ENetState.ES_UnInit);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ES_Connecting", Net.NetClient.ENetState.ES_Connecting);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ES_Connected", Net.NetClient.ENetState.ES_Connected);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ES_Disconnect", Net.NetClient.ENetState.ES_Disconnect);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Net.NetClient.ENetState));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Net.NetClient.ENetState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushNetNetClientENetState(L, (Net.NetClient.ENetState)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "ES_UnInit"))
                {
                    translator.PushNetNetClientENetState(L, Net.NetClient.ENetState.ES_UnInit);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ES_Connecting"))
                {
                    translator.PushNetNetClientENetState(L, Net.NetClient.ENetState.ES_Connecting);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ES_Connected"))
                {
                    translator.PushNetNetClientENetState(L, Net.NetClient.ENetState.ES_Connected);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ES_Disconnect"))
                {
                    translator.PushNetNetClientENetState(L, Net.NetClient.ENetState.ES_Disconnect);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Net.NetClient.ENetState!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Net.NetClient.ENetState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcObjCachePoolTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ObjCachePoolType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ObjCachePoolType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ObjCachePoolType), L, null, 13, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TEXT_ASSET", xc.ObjCachePoolType.TEXT_ASSET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "JSON", xc.ObjCachePoolType.JSON);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AI", xc.ObjCachePoolType.AI);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ACTOR", xc.ObjCachePoolType.ACTOR);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SMALL_PREFAB", xc.ObjCachePoolType.SMALL_PREFAB);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SFX", xc.ObjCachePoolType.SFX);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AIJSON", xc.ObjCachePoolType.AIJSON);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MACHINE", xc.ObjCachePoolType.MACHINE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "STATE", xc.ObjCachePoolType.STATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UI_PREFAB", xc.ObjCachePoolType.UI_PREFAB);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DROP_PREFAB", xc.ObjCachePoolType.DROP_PREFAB);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ObjCachePoolType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ObjCachePoolType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcObjCachePoolType(L, (xc.ObjCachePoolType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "TEXT_ASSET"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.TEXT_ASSET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "JSON"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.JSON);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AI"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.AI);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ACTOR"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.ACTOR);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SMALL_PREFAB"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.SMALL_PREFAB);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SFX"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.SFX);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AIJSON"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.AIJSON);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MACHINE"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.MACHINE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "STATE"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.STATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UI_PREFAB"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.UI_PREFAB);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DROP_PREFAB"))
                {
                    translator.PushxcObjCachePoolType(L, xc.ObjCachePoolType.DROP_PREFAB);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ObjCachePoolType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ObjCachePoolType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcPlayerFollowRecordSceneIdWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.PlayerFollowRecordSceneId), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.PlayerFollowRecordSceneId), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.PlayerFollowRecordSceneId), L, null, 43, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DeviceInitStart", xc.PlayerFollowRecordSceneId.DeviceInitStart);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DeviceInitEnd", xc.PlayerFollowRecordSceneId.DeviceInitEnd);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DeviceInitFail", xc.PlayerFollowRecordSceneId.DeviceInitFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CopyResStart", xc.PlayerFollowRecordSceneId.CopyResStart);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CopyResEnd", xc.PlayerFollowRecordSceneId.CopyResEnd);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CopyResFail", xc.PlayerFollowRecordSceneId.CopyResFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AppUpdateCheckStart", xc.PlayerFollowRecordSceneId.AppUpdateCheckStart);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AppUpdateCheckEnd", xc.PlayerFollowRecordSceneId.AppUpdateCheckEnd);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AppUpdateCheckFail", xc.PlayerFollowRecordSceneId.AppUpdateCheckFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res1And2UpdateCheckStart", xc.PlayerFollowRecordSceneId.Res1And2UpdateCheckStart);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res1And2UpdateCheckEnd", xc.PlayerFollowRecordSceneId.Res1And2UpdateCheckEnd);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res1And2UpdateCheckFail", xc.PlayerFollowRecordSceneId.Res1And2UpdateCheckFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res2iOSUpdateCheckStart", xc.PlayerFollowRecordSceneId.Res2iOSUpdateCheckStart);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res2iOSUpdateCheckEnd", xc.PlayerFollowRecordSceneId.Res2iOSUpdateCheckEnd);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res2iOSUpdateCheckFail", xc.PlayerFollowRecordSceneId.Res2iOSUpdateCheckFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res2iOSUpdateStart", xc.PlayerFollowRecordSceneId.Res2iOSUpdateStart);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res2iOSUpdateEnd", xc.PlayerFollowRecordSceneId.Res2iOSUpdateEnd);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res2iOSUpdateFail", xc.PlayerFollowRecordSceneId.Res2iOSUpdateFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res4UpdateCheckStart", xc.PlayerFollowRecordSceneId.Res4UpdateCheckStart);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res4UpdateCheckEnd", xc.PlayerFollowRecordSceneId.Res4UpdateCheckEnd);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res4UpdateCheckFail", xc.PlayerFollowRecordSceneId.Res4UpdateCheckFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res4UpdateStart", xc.PlayerFollowRecordSceneId.Res4UpdateStart);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res4UpdateEnd", xc.PlayerFollowRecordSceneId.Res4UpdateEnd);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Res4UpdateFail", xc.PlayerFollowRecordSceneId.Res4UpdateFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PreloadResStart", xc.PlayerFollowRecordSceneId.PreloadResStart);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PreloadResEnd", xc.PlayerFollowRecordSceneId.PreloadResEnd);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SDKInit", xc.PlayerFollowRecordSceneId.SDKInit);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SDKRegister", xc.PlayerFollowRecordSceneId.SDKRegister);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SDKLogin", xc.PlayerFollowRecordSceneId.SDKLogin);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GetServerList", xc.PlayerFollowRecordSceneId.GetServerList);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ClickLoginButton", xc.PlayerFollowRecordSceneId.ClickLoginButton);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LoginServerSuccess", xc.PlayerFollowRecordSceneId.LoginServerSuccess);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EnterCreateActorScene", xc.PlayerFollowRecordSceneId.EnterCreateActorScene);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ClickCreateActorButton", xc.PlayerFollowRecordSceneId.ClickCreateActorButton);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EnterSelectActorScene", xc.PlayerFollowRecordSceneId.EnterSelectActorScene);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ClickSelectActorButton", xc.PlayerFollowRecordSceneId.ClickSelectActorButton);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EnterFirstScene", xc.PlayerFollowRecordSceneId.EnterFirstScene);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "StartLogout", xc.PlayerFollowRecordSceneId.StartLogout);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FinishedLogout", xc.PlayerFollowRecordSceneId.FinishedLogout);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ResDownloadFail", xc.PlayerFollowRecordSceneId.ResDownloadFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ResLoadFail", xc.PlayerFollowRecordSceneId.ResLoadFail);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.PlayerFollowRecordSceneId));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.PlayerFollowRecordSceneId), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcPlayerFollowRecordSceneId(L, (xc.PlayerFollowRecordSceneId)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "DeviceInitStart"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.DeviceInitStart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DeviceInitEnd"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.DeviceInitEnd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DeviceInitFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.DeviceInitFail);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CopyResStart"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.CopyResStart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CopyResEnd"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.CopyResEnd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CopyResFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.CopyResFail);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AppUpdateCheckStart"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.AppUpdateCheckStart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AppUpdateCheckEnd"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.AppUpdateCheckEnd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AppUpdateCheckFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.AppUpdateCheckFail);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res1And2UpdateCheckStart"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res1And2UpdateCheckStart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res1And2UpdateCheckEnd"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res1And2UpdateCheckEnd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res1And2UpdateCheckFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res1And2UpdateCheckFail);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res2iOSUpdateCheckStart"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res2iOSUpdateCheckStart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res2iOSUpdateCheckEnd"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res2iOSUpdateCheckEnd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res2iOSUpdateCheckFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res2iOSUpdateCheckFail);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res2iOSUpdateStart"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res2iOSUpdateStart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res2iOSUpdateEnd"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res2iOSUpdateEnd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res2iOSUpdateFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res2iOSUpdateFail);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res4UpdateCheckStart"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res4UpdateCheckStart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res4UpdateCheckEnd"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res4UpdateCheckEnd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res4UpdateCheckFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res4UpdateCheckFail);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res4UpdateStart"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res4UpdateStart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res4UpdateEnd"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res4UpdateEnd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Res4UpdateFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.Res4UpdateFail);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PreloadResStart"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.PreloadResStart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PreloadResEnd"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.PreloadResEnd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SDKInit"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.SDKInit);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SDKRegister"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.SDKRegister);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SDKLogin"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.SDKLogin);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GetServerList"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.GetServerList);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ClickLoginButton"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.ClickLoginButton);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LoginServerSuccess"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.LoginServerSuccess);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EnterCreateActorScene"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.EnterCreateActorScene);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ClickCreateActorButton"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.ClickCreateActorButton);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EnterSelectActorScene"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.EnterSelectActorScene);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ClickSelectActorButton"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.ClickSelectActorButton);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EnterFirstScene"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.EnterFirstScene);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "StartLogout"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.StartLogout);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FinishedLogout"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.FinishedLogout);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ResDownloadFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.ResDownloadFail);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ResLoadFail"))
                {
                    translator.PushxcPlayerFollowRecordSceneId(L, xc.PlayerFollowRecordSceneId.ResLoadFail);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.PlayerFollowRecordSceneId!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.PlayerFollowRecordSceneId! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcClientEventWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ClientEvent), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ClientEvent), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ClientEvent), L, null, 497, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_Normal", xc.ClientEvent.CE_Normal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SDK_LOGINED", xc.ClientEvent.CE_SDK_LOGINED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SDK_INITED", xc.ClientEvent.CE_SDK_INITED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SDK_LOGINSUCC", xc.ClientEvent.CE_SDK_LOGINSUCC);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SDK_BIND_MOBILE_SUC", xc.ClientEvent.CE_SDK_BIND_MOBILE_SUC);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_RANDNAME_UPDATE", xc.ClientEvent.CE_RANDNAME_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DATA_HOTUP", xc.ClientEvent.CE_DATA_HOTUP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SELECT_SERVER", xc.ClientEvent.CE_SELECT_SERVER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_START_GET_SERVER_INFOS", xc.ClientEvent.CE_START_GET_SERVER_INFOS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SDK_SEND_VERIFY_CODE_RET", xc.ClientEvent.CE_SDK_SEND_VERIFY_CODE_RET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SDK_BIND_PHONE_RET", xc.ClientEvent.CE_SDK_BIND_PHONE_RET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SDK_FACEBOOK_SHARE_SUCCESS", xc.ClientEvent.CE_SDK_FACEBOOK_SHARE_SUCCESS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SDK_FACEBOOK_SHARE_FAILED", xc.ClientEvent.CE_SDK_FACEBOOK_SHARE_FAILED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NET_MAIN_CONNECTED", xc.ClientEvent.CE_NET_MAIN_CONNECTED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NET_CROSS_CONNECTED", xc.ClientEvent.CE_NET_CROSS_CONNECTED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NET_MAIN_DISCONNECT", xc.ClientEvent.CE_NET_MAIN_DISCONNECT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NET_CROSS_DISCONNECT", xc.ClientEvent.CE_NET_CROSS_DISCONNECT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NET_RECONNECT", xc.ClientEvent.CE_NET_RECONNECT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NETWORK_CHANGE", xc.ClientEvent.CE_NETWORK_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHARGEINFO_UPDATE", xc.ClientEvent.CE_CHARGEINFO_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FIRST_PAY_TIPS_SHOW", xc.ClientEvent.CE_FIRST_PAY_TIPS_SHOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SERVER_TIME_CHANGED", xc.ClientEvent.CE_SERVER_TIME_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHECK_MINIPACK", xc.ClientEvent.CE_CHECK_MINIPACK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_QUIT_GAME", xc.ClientEvent.CE_QUIT_GAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ENTER_GAME", xc.ClientEvent.CE_ENTER_GAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GAME_INITED", xc.ClientEvent.CE_GAME_INITED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ALL_SYSTEM_INITED", xc.ClientEvent.CE_ALL_SYSTEM_INITED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_ERROR", xc.ClientEvent.CE_SYS_ERROR);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_APPLICATION_PAUSE", xc.ClientEvent.CE_APPLICATION_PAUSE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PLAYER_DAILY_RESET", xc.ClientEvent.CE_PLAYER_DAILY_RESET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SPAN_SERVER_OPEN", xc.ClientEvent.CE_SPAN_SERVER_OPEN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SPAN_SERVER_CLOSE", xc.ClientEvent.CE_SPAN_SERVER_CLOSE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SETTING_AUTOADJUST", xc.ClientEvent.CE_SETTING_AUTOADJUST);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SETTING_CHANGED", xc.ClientEvent.CE_SETTING_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SETTING_HOOK_CHANGED", xc.ClientEvent.CE_SETTING_HOOK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SETTING_OFFLINE_REWARD", xc.ClientEvent.CE_SETTING_OFFLINE_REWARD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SETTING_QUALITY_CHANGED", xc.ClientEvent.CE_SETTING_QUALITY_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SETTING_LOW_FPS", xc.ClientEvent.CE_SETTING_LOW_FPS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCALPLAYER_CREATED", xc.ClientEvent.CE_LOCALPLAYER_CREATED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCALPLAYER_MODEL_CHANGE", xc.ClientEvent.CE_LOCALPLAYER_MODEL_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_REMOTEPLAYER_CREATED", xc.ClientEvent.CE_REMOTEPLAYER_CREATED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ACTOR_BASEINFO_UPDATE", xc.ClientEvent.CE_ACTOR_BASEINFO_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ACTOR_LEVEL_UPDATE", xc.ClientEvent.CE_ACTOR_LEVEL_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WORLD_LEVEL_UPDATE", xc.ClientEvent.CE_WORLD_LEVEL_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCALPLAYER_EXP_ADDED", xc.ClientEvent.CE_LOCALPLAYER_EXP_ADDED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCALPLAYER_BATTLE_POWER_CHANGED", xc.ClientEvent.CE_LOCALPLAYER_BATTLE_POWER_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MONSTER_DEAD", xc.ClientEvent.CE_MONSTER_DEAD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MONSTERDEAD", xc.ClientEvent.CE_MONSTERDEAD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MONSTERCREATEED", xc.ClientEvent.CE_MONSTERCREATEED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCALMONSTERCREATEED", xc.ClientEvent.CE_LOCALMONSTERCREATEED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_REMOTEMONSTERCREATEED", xc.ClientEvent.CE_REMOTEMONSTERCREATEED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PLAYERDEAD", xc.ClientEvent.CE_PLAYERDEAD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NPCDEAD", xc.ClientEvent.CE_NPCDEAD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NPCCLICKED", xc.ClientEvent.CE_NPCCLICKED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NPCLEAVED", xc.ClientEvent.CE_NPCLEAVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ACTOR_RES_LOADED", xc.ClientEvent.CE_ACTOR_RES_LOADED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ACTOR_FRIEND_MARCK_CHANGED", xc.ClientEvent.CE_ACTOR_FRIEND_MARCK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCAL_PLAYER_NWAR_CHANGED", xc.ClientEvent.CE_LOCAL_PLAYER_NWAR_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ACTOR_SET_CHAOS_MODE", xc.ClientEvent.CE_ACTOR_SET_CHAOS_MODE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ACTOR_PATH_POINTS_CHANGED", xc.ClientEvent.CE_ACTOR_PATH_POINTS_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCAL_PLAYER_ADD_ENEMY", xc.ClientEvent.CE_LOCAL_PLAYER_ADD_ENEMY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCAL_PLAYER_EXCHANGE_PVP_STATE", xc.ClientEvent.CE_LOCAL_PLAYER_EXCHANGE_PVP_STATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCAL_PLAYER_NWAR_DEAD", xc.ClientEvent.CE_LOCAL_PLAYER_NWAR_DEAD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCAL_PLAYER_NWAR_REVIVE", xc.ClientEvent.CE_LOCAL_PLAYER_NWAR_REVIVE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_STATUS_TRANSFER_EXIT", xc.ClientEvent.CE_STATUS_TRANSFER_EXIT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DISABLE_CLICKEFFECT", xc.ClientEvent.CE_DISABLE_CLICKEFFECT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PLAYER_DEAD", xc.ClientEvent.PLAYER_DEAD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PLAYER_BE_ATTACKED", xc.ClientEvent.PLAYER_BE_ATTACKED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PLAYER_EXIT_IDLE", xc.ClientEvent.PLAYER_EXIT_IDLE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EC_PLAYER_LV_POINT_UPDATE", xc.ClientEvent.EC_PLAYER_LV_POINT_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EC_PLAYER_ATTRS_UPDATE", xc.ClientEvent.EC_PLAYER_ATTRS_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EC_ACTOR_HP_CHANGE", xc.ClientEvent.EC_ACTOR_HP_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_ATTRS_UPDATE_WINDOW", xc.ClientEvent.CE_SHOW_ATTRS_UPDATE_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EC_ACTOR_MP_CHANGE", xc.ClientEvent.EC_ACTOR_MP_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EC_ACTOR_UNDER_ATTACK_CHANGE", xc.ClientEvent.EC_ACTOR_UNDER_ATTACK_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EC_ACTOR_ADD_UNDER_ATTACK", xc.ClientEvent.EC_ACTOR_ADD_UNDER_ATTACK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUARDED_NPC_HP_CHANGE", xc.ClientEvent.CE_GUARDED_NPC_HP_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CUSTOM_DATA_UPDATE", xc.ClientEvent.CE_CUSTOM_DATA_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FIRST_ENTER_SCENE", xc.ClientEvent.CE_FIRST_ENTER_SCENE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_START_SWITCHSCENE", xc.ClientEvent.CE_START_SWITCHSCENE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FINISH_LOAD_LEVEL", xc.ClientEvent.CE_FINISH_LOAD_LEVEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FINISH_SWITCHSCENE", xc.ClientEvent.CE_FINISH_SWITCHSCENE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FINISH_LOAD_SCENE", xc.ClientEvent.CE_FINISH_LOAD_SCENE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SWITCHINSTANCE", xc.ClientEvent.CE_SWITCHINSTANCE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_START_SWITCH_PLANE_INSTANCE", xc.ClientEvent.CE_START_SWITCH_PLANE_INSTANCE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SCENE_DESTROY_ALL_INTER_OBJECT", xc.ClientEvent.CE_SCENE_DESTROY_ALL_INTER_OBJECT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICKPLAYER", xc.ClientEvent.CE_CLICKPLAYER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICKPLAYER_INFO", xc.ClientEvent.CE_CLICKPLAYER_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICKNPC", xc.ClientEvent.CE_CLICKNPC);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICKCHEST", xc.ClientEvent.CE_CLICKCHEST);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICKMONSTER", xc.ClientEvent.CE_CLICKMONSTER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICKCOLLISION", xc.ClientEvent.CE_CLICKCOLLISION);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICKCOLLISION_INFO", xc.ClientEvent.CE_CLICKCOLLISION_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICKINTEROBJECTLAYER", xc.ClientEvent.CE_CLICKINTEROBJECTLAYER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_COVER_STATE_CHANGE", xc.ClientEvent.CE_COVER_STATE_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICKPLAY_DISPLAY_INFO", xc.ClientEvent.CE_CLICKPLAY_DISPLAY_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PLAYERCONTROLED", xc.ClientEvent.CE_PLAYERCONTROLED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PLAYER_IN_PORTAL", xc.ClientEvent.CE_PLAYER_IN_PORTAL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRANSFER", xc.ClientEvent.CE_TRANSFER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAINMAP_STATE_CHANGED", xc.ClientEvent.CE_MAINMAP_STATE_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAINMAP_ANIMATION_PLAY_END", xc.ClientEvent.CE_MAINMAP_ANIMATION_PLAY_END);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAINMAP_SWITCH_ANIMATION", xc.ClientEvent.CE_MAINMAP_SWITCH_ANIMATION);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAINMAP_SWTICH_TR_SYSBTN", xc.ClientEvent.CE_MAINMAP_SWTICH_TR_SYSBTN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TOUCH_NOT_UI", xc.ClientEvent.CE_TOUCH_NOT_UI);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAINMAP_OPEN", xc.ClientEvent.CE_MAINMAP_OPEN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAIN_MAP_CHECK_MARK", xc.ClientEvent.CE_MAIN_MAP_CHECK_MARK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_UPDATE_SYS_MARK", xc.ClientEvent.CE_UPDATE_SYS_MARK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAINMAP_CLICK_BL_PACKUP_BTN", xc.ClientEvent.CE_MAINMAP_CLICK_BL_PACKUP_BTN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAINMAP_CHANGE_BOSSHP_VISIBLE", xc.ClientEvent.CE_MAINMAP_CHANGE_BOSSHP_VISIBLE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LINE_CD_TIME", xc.ClientEvent.CE_CHANGE_LINE_CD_TIME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LINE", xc.ClientEvent.CE_CHANGE_LINE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LINE_INFO", xc.ClientEvent.CE_LINE_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUIDESTART", xc.ClientEvent.CE_GUIDESTART);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUIDEEND", xc.ClientEvent.CE_GUIDEEND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUIDE_STORY_END", xc.ClientEvent.CE_GUIDE_STORY_END);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUIDE_UNFOLD_SYS_BTN", xc.ClientEvent.CE_GUIDE_UNFOLD_SYS_BTN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_CONFIG_INIT", xc.ClientEvent.CE_SYS_CONFIG_INIT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NEW_WAITING_SYS", xc.ClientEvent.CE_NEW_WAITING_SYS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_RE_OPEN_SYS", xc.ClientEvent.CE_RE_OPEN_SYS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_RED_SPOT_CHANGE", xc.ClientEvent.CE_SYS_RED_SPOT_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_OPEN", xc.ClientEvent.CE_SYS_OPEN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_OPEN_POST", xc.ClientEvent.CE_SYS_OPEN_POST);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_OPEN_NOTIFY", xc.ClientEvent.CE_SYS_OPEN_NOTIFY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_CLOSE", xc.ClientEvent.CE_SYS_CLOSE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_BTN_CLOSE", xc.ClientEvent.CE_SYS_BTN_CLOSE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_OPEN_ANIM_START", xc.ClientEvent.CE_SYS_OPEN_ANIM_START);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_OPEN_ANIM_END", xc.ClientEvent.CE_SYS_OPEN_ANIM_END);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_HSYSBTN_CHANGE", xc.ClientEvent.CE_HSYSBTN_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_WAIT_OPEN_SWITCH_ANIMATION", xc.ClientEvent.CE_SYS_WAIT_OPEN_SWITCH_ANIMATION);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_SPECIAL", xc.ClientEvent.CE_SYS_SPECIAL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_POST_SHOW_TREASURE_OPEN", xc.ClientEvent.CE_POST_SHOW_TREASURE_OPEN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_POST_OPEN_TREASURE_PREVIEW", xc.ClientEvent.CE_POST_OPEN_TREASURE_PREVIEW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_TREASURE_OPEN", xc.ClientEvent.CE_SHOW_TREASURE_OPEN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_PREVIEW_REWARDED_LISTS", xc.ClientEvent.CE_SYS_PREVIEW_REWARDED_LISTS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SYS_PREVIEW_REWARD", xc.ClientEvent.CE_SYS_PREVIEW_REWARD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NEW_REDPOINT_SHOW", xc.ClientEvent.CE_NEW_REDPOINT_SHOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NEW_REDPOINT_DISAPPEAR", xc.ClientEvent.CE_NEW_REDPOINT_DISAPPEAR);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NEW_REDPOINT_BIND", xc.ClientEvent.CE_NEW_REDPOINT_BIND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NEW_REDPOINT_UNBIND", xc.ClientEvent.CE_NEW_REDPOINT_UNBIND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCK_ICON_BIND", xc.ClientEvent.CE_LOCK_ICON_BIND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCK_ICON_UNBIND", xc.ClientEvent.CE_LOCK_ICON_UNBIND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NEW_MARKER_BIND", xc.ClientEvent.CE_NEW_MARKER_BIND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_NEW_MARKER_UNBIND", xc.ClientEvent.CE_NEW_MARKER_UNBIND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_ROLLING_NOTICE", xc.ClientEvent.CE_SHOW_ROLLING_NOTICE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_ROLLING_NOTICE_END", xc.ClientEvent.CE_SHOW_ROLLING_NOTICE_END);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_COMMON_TIPS_WARNNING", xc.ClientEvent.CE_SHOW_COMMON_TIPS_WARNNING);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_DANMAKU", xc.ClientEvent.CE_SHOW_DANMAKU);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLEAR_DANMAKU", xc.ClientEvent.CE_CLEAR_DANMAKU);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_BOTTOM_MESSAGE", xc.ClientEvent.CE_SHOW_BOTTOM_MESSAGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_COMMON_TEXT_TIPS", xc.ClientEvent.CE_SHOW_COMMON_TEXT_TIPS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_BIG_COMMON_TEXT_TIPS", xc.ClientEvent.CE_SHOW_BIG_COMMON_TEXT_TIPS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NEW_MINIMAP_SELECT_MONSTER_MINIMAPINFO", xc.ClientEvent.NEW_MINIMAP_SELECT_MONSTER_MINIMAPINFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MINI_MAP_COM_POS", xc.ClientEvent.CE_MINI_MAP_COM_POS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_START", xc.ClientEvent.CE_INSTANCE_START);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCALPLAYER_CREATE", xc.ClientEvent.CE_LOCALPLAYER_CREATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_REMOTEPLAYER_CREATE", xc.ClientEvent.CE_REMOTEPLAYER_CREATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_EXITINSTANCE", xc.ClientEvent.CE_EXITINSTANCE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_POLL_INFO_CHANGED", xc.ClientEvent.CE_INSTANCE_POLL_INFO_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_PHASE_CHANGED", xc.ClientEvent.CE_INSTANCE_PHASE_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_PHASE_PROGRESS_CHANGED", xc.ClientEvent.CE_INSTANCE_PHASE_PROGRESS_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_MARK_CHANGED", xc.ClientEvent.CE_INSTANCE_MARK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_KUNGFUGOD_CHANGED", xc.ClientEvent.CE_INSTANCE_KUNGFUGOD_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_DEAD_SPACE_LV_CHANGED", xc.ClientEvent.CE_INSTANCE_DEAD_SPACE_LV_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_DEAD_SPACE_SCORE_CHANGED", xc.ClientEvent.CE_INSTANCE_DEAD_SPACE_SCORE_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_DEAD_SPACE_EXP_CHANGED", xc.ClientEvent.CE_INSTANCE_DEAD_SPACE_EXP_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_FAIRY_VALLEY_INFO_CHANGED", xc.ClientEvent.CE_INSTANCE_FAIRY_VALLEY_INFO_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_FAIRY_VALLEY_INSPIRE_NUM_CHANGED", xc.ClientEvent.CE_INSTANCE_FAIRY_VALLEY_INSPIRE_NUM_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WILD_HUMAN_COUNT_CHANGED", xc.ClientEvent.CE_WILD_HUMAN_COUNT_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTANCE_SHOW_EXIT_INSTANCE_TIME_LABEL", xc.ClientEvent.CE_INSTANCE_SHOW_EXIT_INSTANCE_TIME_LABEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LEAVEAOI", xc.ClientEvent.CE_LEAVEAOI);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLEAR_UNITCACHE", xc.ClientEvent.CE_CLEAR_UNITCACHE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UPDATE_AUTO_BATTLE_UI", xc.ClientEvent.UPDATE_AUTO_BATTLE_UI);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHOW_AUTO_BATTLE_GET_EXP", xc.ClientEvent.SHOW_AUTO_BATTLE_GET_EXP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHOW_SKILL_PANEL", xc.ClientEvent.SHOW_SKILL_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PICK_DROP", xc.ClientEvent.CE_PICK_DROP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DESTROY_DROP", xc.ClientEvent.CE_DESTROY_DROP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DROP_DISAPPEAR", xc.ClientEvent.CE_DROP_DISAPPEAR);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHOW_PICK_DROP_FLOAT_TIPS", xc.ClientEvent.CE_SHOW_PICK_DROP_FLOAT_TIPS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PICK_DROP_SHOW_BOSS_CHIP", xc.ClientEvent.CE_PICK_DROP_SHOW_BOSS_CHIP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PICK_DROP_DISAPPEAR_BOSS_CHIP", xc.ClientEvent.CE_PICK_DROP_DISAPPEAR_BOSS_CHIP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PICK_DROP_BREAK_PICK_UP", xc.ClientEvent.CE_PICK_DROP_BREAK_PICK_UP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PICK_DROP_START_PICK_UP_LOCALPLAYER", xc.ClientEvent.CE_PICK_DROP_START_PICK_UP_LOCALPLAYER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PICK_DROP_CONTROL_SLIDER", xc.ClientEvent.CE_PICK_DROP_CONTROL_SLIDER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LOCAL_PLAYER_EXIT_INTERACTION", xc.ClientEvent.CE_LOCAL_PLAYER_EXIT_INTERACTION);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAIL_UPDATE", xc.ClientEvent.CE_MAIL_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAIL_DETAIL", xc.ClientEvent.CE_MAIL_DETAIL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAIL_NEW", xc.ClientEvent.CE_MAIL_NEW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAIL_READ", xc.ClientEvent.CE_MAIL_READ);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAIL_GET", xc.ClientEvent.CE_MAIL_GET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAIL_DEL", xc.ClientEvent.CE_MAIL_DEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NEW_MAIL_RECEIVED", xc.ClientEvent.NEW_MAIL_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_UPDATE", xc.ClientEvent.CE_BAG_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_UPDATE_SLOT", xc.ClientEvent.CE_BAG_UPDATE_SLOT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_UPDATE_SLOT_DEL", xc.ClientEvent.CE_BAG_UPDATE_SLOT_DEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_UPDATE_SLOT_INSTALL", xc.ClientEvent.CE_BAG_UPDATE_SLOT_INSTALL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_UPDATE_SLOT_EXTEND", xc.ClientEvent.CE_BAG_UPDATE_SLOT_EXTEND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WARE_UPDATE_SLOT", xc.ClientEvent.CE_WARE_UPDATE_SLOT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WARE_UPDATE_SLOT_INSTALL", xc.ClientEvent.CE_WARE_UPDATE_SLOT_INSTALL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WARE_UPDATE_SLOT_EXTEND", xc.ClientEvent.CE_WARE_UPDATE_SLOT_EXTEND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_ADD", xc.ClientEvent.CE_BAG_ADD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_DEL", xc.ClientEvent.CE_BAG_DEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_GOODS_ADD_NUM", xc.ClientEvent.CE_BAG_GOODS_ADD_NUM);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_GOODS_ADD_NUM_OPERATE_NONE", xc.ClientEvent.CE_BAG_GOODS_ADD_NUM_OPERATE_NONE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAG_PAGE_UPDATE", xc.ClientEvent.CE_BAG_PAGE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WAREHOUSE_UPDATE", xc.ClientEvent.CE_WAREHOUSE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WAREHOUSE_PAGE_UPDATE", xc.ClientEvent.CE_WAREHOUSE_PAGE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTALL_1_UPDATE", xc.ClientEvent.CE_INSTALL_1_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SOUL_UPDATE", xc.ClientEvent.CE_SOUL_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SOUL_PAGE_UPDATE", xc.ClientEvent.CE_SOUL_PAGE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTALL_2_UPDATE", xc.ClientEvent.CE_INSTALL_2_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTALL_2_PAGE_UPDATE", xc.ClientEvent.CE_INSTALL_2_PAGE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GOODS_CD_UPDATE", xc.ClientEvent.CE_GOODS_CD_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MONEY_UPDATE", xc.ClientEvent.CE_MONEY_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OFFLINE_HANGE_TIME_UPDATE", xc.ClientEvent.CE_OFFLINE_HANGE_TIME_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GOODS_ADD_TIP", xc.ClientEvent.CE_GOODS_ADD_TIP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ONE_BAGTYPE_SIZE_UPDATE", xc.ClientEvent.CE_ONE_BAGTYPE_SIZE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTALL_1_EFLIN_UPDATE", xc.ClientEvent.CE_INSTALL_1_EFLIN_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GOODS_UPDATE_EXPIRE_TIME", xc.ClientEvent.CE_GOODS_UPDATE_EXPIRE_TIME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GOODS_USE_TIMES_UPDATE", xc.ClientEvent.CE_GOODS_USE_TIMES_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTALL_3_UPDATE", xc.ClientEvent.CE_INSTALL_3_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DECORATE_BAG_SIZE_UPDATE", xc.ClientEvent.CE_DECORATE_BAG_SIZE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DECORATE_BAG_UPDATE", xc.ClientEvent.CE_DECORATE_BAG_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TREASURE_HUNT_UPDATE", xc.ClientEvent.CE_TREASURE_HUNT_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ID_TREASURE_BAG_UPDATE", xc.ClientEvent.CE_ID_TREASURE_BAG_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_HANDBOOK_BAG_SIZE_UPDATE", xc.ClientEvent.CE_HANDBOOK_BAG_SIZE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_HANDBOOK_UPDATE", xc.ClientEvent.CE_HANDBOOK_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WEARING_MAGIC_EQUIP_UPDATE", xc.ClientEvent.CE_WEARING_MAGIC_EQUIP_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAGIC_EQUIP_BAG_UPDATE", xc.ClientEvent.CE_MAGIC_EQUIP_BAG_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MAGIC_EQUIP_BAG_SIZE_UPDATE", xc.ClientEvent.CE_MAGIC_EQUIP_BAG_SIZE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GOD_EQUIP_UPDATE", xc.ClientEvent.CE_GOD_EQUIP_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GOD_EQUIP_BAG_SIZE_UPDATE", xc.ClientEvent.CE_GOD_EQUIP_BAG_SIZE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GOD_EQUIP_BAG_UPDATE", xc.ClientEvent.CE_GOD_EQUIP_BAG_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ELEMENT_EQUIP_UPDATE", xc.ClientEvent.CE_ELEMENT_EQUIP_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ELEMENT_EQUIP_BAG_UPDATE", xc.ClientEvent.CE_ELEMENT_EQUIP_BAG_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_EQUIP_UPDATE", xc.ClientEvent.CE_MOUNT_EQUIP_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_EQUIP_BAG_UPDATE", xc.ClientEvent.CE_MOUNT_EQUIP_BAG_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_EQUIP_BAG_SIZE_UPDATE", xc.ClientEvent.CE_MOUNT_EQUIP_BAG_SIZE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LIGHT_WEAPON_SOUL_UPDATE_INSTALLED", xc.ClientEvent.CE_LIGHT_WEAPON_SOUL_UPDATE_INSTALLED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LIGHT_WEAPON_SOUL_BAG_UPDATE", xc.ClientEvent.CE_LIGHT_WEAPON_SOUL_BAG_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_LIGHT_WEAPON_SOUL_BAG_SIZE_UPDATE", xc.ClientEvent.CE_LIGHT_WEAPON_SOUL_BAG_SIZE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GOODS_LIST_UPDATE", xc.ClientEvent.CE_GOODS_LIST_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_SPIRIT_RUNES_WINDOW", xc.ClientEvent.CE_OPEN_SPIRIT_RUNES_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SOUL_OPEN_UPDATE", xc.ClientEvent.CE_SOUL_OPEN_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TEAM_INFO_CHANGED", xc.ClientEvent.CE_TEAM_INFO_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TEAM_APPLY_INFO_CHANGED", xc.ClientEvent.CE_TEAM_APPLY_INFO_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TEAM_BE_INVITED", xc.ClientEvent.CE_TEAM_BE_INVITED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TEAM_TARGET_CHANGED", xc.ClientEvent.CE_TEAM_TARGET_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TEAM_AUTO_MATCHING_STATE_CHANGED", xc.ClientEvent.CE_TEAM_AUTO_MATCHING_STATE_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TEAM_INVITE_ALL_CD_CHANGED", xc.ClientEvent.CE_TEAM_INVITE_ALL_CD_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TEAM_SYSTEM_MESSAGE_SHOW", xc.ClientEvent.CE_TEAM_SYSTEM_MESSAGE_SHOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TEAM_CLICK_CLOSE_WINDOW_BTN", xc.ClientEvent.CE_TEAM_CLICK_CLOSE_WINDOW_BTN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TEAM_HIDE_WINDOW", xc.ClientEvent.CE_TEAM_HIDE_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTALLED_EQUIP_CHANGED", xc.ClientEvent.CE_INSTALLED_EQUIP_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_EQUIP_INFO_CHANGED", xc.ClientEvent.CE_EQUIP_INFO_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_INSTALLED_EQUIP_INFO_CHANGED", xc.ClientEvent.CE_INSTALLED_EQUIP_INFO_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_STRENGTH_RESULT", xc.ClientEvent.CE_STRENGTH_RESULT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_STRENGTH_UP_LV", xc.ClientEvent.CE_STRENGTH_UP_LV);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_STRENGTH_EQUIP_CHANGED", xc.ClientEvent.CE_STRENGTH_EQUIP_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAPTIZE_EQUIP_CHANGED", xc.ClientEvent.CE_BAPTIZE_EQUIP_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BAPTIZE_EQUIP_RESULT", xc.ClientEvent.CE_BAPTIZE_EQUIP_RESULT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SUIT_EQUIP_CHANGED", xc.ClientEvent.CE_SUIT_EQUIP_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SUIT_REFINE_CHANGED", xc.ClientEvent.CE_SUIT_REFINE_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_EQUIP_GEM_CHANGED", xc.ClientEvent.CE_EQUIP_GEM_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_EQUIP_STRENGTH_WINDOW", xc.ClientEvent.CE_OPEN_EQUIP_STRENGTH_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_EQUIP_FASHION_CHANGED", xc.ClientEvent.CE_EQUIP_FASHION_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DECORATE_STRENGTH_RESULT", xc.ClientEvent.CE_DECORATE_STRENGTH_RESULT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DECORATE_BREAK_RESULT", xc.ClientEvent.CE_DECORATE_BREAK_RESULT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DECORATE_POS_INFO_UPDATE", xc.ClientEvent.CE_DECORATE_POS_INFO_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LOCKTARGET", xc.ClientEvent.CE_CHANGE_LOCKTARGET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRIGGER_SKILL_CLICK_BUTTON", xc.ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRIGGER_SKILL_PRESS_BUTTON", xc.ClientEvent.CE_TRIGGER_SKILL_PRESS_BUTTON);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRIGGER_SKILL_RELEASE_BUTTON", xc.ClientEvent.CE_TRIGGER_SKILL_RELEASE_BUTTON);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRIGGER_SKILL", xc.ClientEvent.CE_TRIGGER_SKILL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ATTACK_SUCC", xc.ClientEvent.CE_ATTACK_SUCC);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SELECTACTOR_CHANGE", xc.ClientEvent.CE_SELECTACTOR_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SELECTACTOR_WHEN_CAST_SKILL", xc.ClientEvent.CE_SELECTACTOR_WHEN_CAST_SKILL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BATTLESTATUS_CHANGE", xc.ClientEvent.CE_BATTLESTATUS_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHAPE_SHIFT_BEGIN", xc.ClientEvent.CE_SHAPE_SHIFT_BEGIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHAPE_SHIFT_END", xc.ClientEvent.CE_SHAPE_SHIFT_END);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LOCALPLAYER_CASTINGREADY_STATGE", xc.ClientEvent.CE_CHANGE_LOCALPLAYER_CASTINGREADY_STATGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LOCALPLAYER_PKMODE", xc.ClientEvent.CE_CHANGE_LOCALPLAYER_PKMODE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LOCALPLAYER_PKVALUE", xc.ClientEvent.CE_CHANGE_LOCALPLAYER_PKVALUE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LOCALPLAYER_IN_SAFE_AREA", xc.ClientEvent.CE_CHANGE_LOCALPLAYER_IN_SAFE_AREA);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LOCALPLAYER_IN_PK_AREA", xc.ClientEvent.CE_CHANGE_LOCALPLAYER_IN_PK_AREA);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BUFF_LIST_CHANGE", xc.ClientEvent.CE_BUFF_LIST_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LOCALPLAYER_RADIUS", xc.ClientEvent.CE_CHANGE_LOCALPLAYER_RADIUS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHANGE_LOCALPLAYER_SKILL_SLOT_LIST", xc.ClientEvent.CE_CHANGE_LOCALPLAYER_SKILL_SLOT_LIST);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_AUTO_FIGHT_STATE_CHANGED", xc.ClientEvent.CE_AUTO_FIGHT_STATE_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BUFF_UPDATE", xc.ClientEvent.CE_BUFF_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CLICK_MATE_SKILL", xc.ClientEvent.CE_CLICK_MATE_SKILL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MATE_SKILL_ACTION", xc.ClientEvent.CE_MATE_SKILL_ACTION);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FIVE_ATTR_NOENOUGH", xc.ClientEvent.CE_FIVE_ATTR_NOENOUGH);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SKILL_LIST_RECEIVED", xc.ClientEvent.SKILL_LIST_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SKILL_UPGRADED", xc.ClientEvent.SKILL_UPGRADED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SKILL_KEY_POS_SET", xc.ClientEvent.SKILL_KEY_POS_SET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SKILL_KEY_CONFIG_CHOOSED", xc.ClientEvent.SKILL_KEY_CONFIG_CHOOSED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "INBORN_INFO_RECEIVED", xc.ClientEvent.INBORN_INFO_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SKILL_OPENNEW", xc.ClientEvent.CE_SKILL_OPENNEW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FURYSKILL_CANUSE", xc.ClientEvent.CE_FURYSKILL_CANUSE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SKILL_MATE_UPDATE", xc.ClientEvent.SKILL_MATE_UPDATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SKILL_MATE_USE_SUCCESS", xc.ClientEvent.SKILL_MATE_USE_SUCCESS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FRIENDS_ONLINE_CHANGE", xc.ClientEvent.CE_FRIENDS_ONLINE_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FRIENDS_CHANGE", xc.ClientEvent.CE_FRIENDS_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FRIENDS_ENEMY_POS", xc.ClientEvent.CE_FRIENDS_ENEMY_POS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FRIENDS_SEARCH_RESULT", xc.ClientEvent.CE_FRIENDS_SEARCH_RESULT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FRIENDS_RECOMMEND", xc.ClientEvent.CE_FRIENDS_RECOMMEND);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FRIENDS_RECOMMEND_CD", xc.ClientEvent.CE_FRIENDS_RECOMMEND_CD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FRIENDS_APPLICANTS_CHANGE", xc.ClientEvent.CE_FRIENDS_APPLICANTS_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FRIENDS_INTIMACY_CHANGE", xc.ClientEvent.CE_FRIENDS_INTIMACY_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_FRIENDS_ADD_BOTH_SIDES", xc.ClientEvent.CE_FRIENDS_ADD_BOTH_SIDES);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_RECEIVE_FLOWER", xc.ClientEvent.CE_RECEIVE_FLOWER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SEND_FLOWER_KISS", xc.ClientEvent.CE_SEND_FLOWER_KISS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_UNREAD_MESSAGE_CHANGED", xc.ClientEvent.CE_CHAT_UNREAD_MESSAGE_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_PLAY_NOTICE_MESSAGE", xc.ClientEvent.CE_CHAT_PLAY_NOTICE_MESSAGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CC_CHAT_PLAY_VOICE_MESSAGE", xc.ClientEvent.CC_CHAT_PLAY_VOICE_MESSAGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_VOICE_CLICK_MESSAGE", xc.ClientEvent.CE_CHAT_VOICE_CLICK_MESSAGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_VOICE_START_MESSAGE", xc.ClientEvent.CE_CHAT_VOICE_START_MESSAGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_VOICE_END_MESSAGE", xc.ClientEvent.CE_CHAT_VOICE_END_MESSAGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_TOOLKIT_SEND_TEXT_TO_INPUTFIELD", xc.ClientEvent.CE_CHAT_TOOLKIT_SEND_TEXT_TO_INPUTFIELD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_HISTORY_TO_INPUTFIELD", xc.ClientEvent.CE_CHAT_HISTORY_TO_INPUTFIELD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_TRUMPET_CONTENT", xc.ClientEvent.CE_CHAT_TRUMPET_CONTENT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WORLD_MESSAGE_RECEIVED", xc.ClientEvent.WORLD_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SOCIETY_MESSAGE_RECEIVED", xc.ClientEvent.SOCIETY_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PRIVATE_MESSAGE_RECEIVED", xc.ClientEvent.PRIVATE_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TEAMENLIST_MESSAGE_RECEIVED", xc.ClientEvent.TEAMENLIST_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "INVITE_MESSAGE_RECEIVED", xc.ClientEvent.INVITE_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TEAM_MESSAGE_RECEIVED", xc.ClientEvent.TEAM_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WILD_MESSAGE_RECEIVED", xc.ClientEvent.WILD_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SYSYTEM_MESSAGE_RECEIVED", xc.ClientEvent.SYSYTEM_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SPAN_MESSAGE_RECEIVIED", xc.ClientEvent.SPAN_MESSAGE_RECEIVIED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "INTEGRATE_MESSAGE_RECEIVED", xc.ClientEvent.INTEGRATE_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CHAT_VOICE_RECORDING_CANCELD", xc.ClientEvent.CHAT_VOICE_RECORDING_CANCELD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRUMPET_MESSAGE_RECEIVED", xc.ClientEvent.TRUMPET_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UNION_MESSAGE_RECEIVED", xc.ClientEvent.UNION_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CROSS_SERVER_CAMP_MESSAGE_RECEIVED", xc.ClientEvent.CROSS_SERVER_CAMP_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CROSS_SERVER_PUBLIC_MESSAGE_RECEIVED", xc.ClientEvent.CROSS_SERVER_PUBLIC_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AOI_MESSAGE_RECEIVED", xc.ClientEvent.AOI_MESSAGE_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "VOICE_AUTOPLAY_NOTIFY", xc.ClientEvent.VOICE_AUTOPLAY_NOTIFY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SEND_CHAT_NOTIFY", xc.ClientEvent.SEND_CHAT_NOTIFY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "VOICE_PLAY_NOTIFY", xc.ClientEvent.VOICE_PLAY_NOTIFY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CLOSE_CHAT_WINDOW", xc.ClientEvent.CLOSE_CHAT_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_JUMP_TO_CONST_POSITION", xc.ClientEvent.CE_CHAT_JUMP_TO_CONST_POSITION);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CHAT_CLICK_RECHARGE_RED_PACKET", xc.ClientEvent.CHAT_CLICK_RECHARGE_RED_PACKET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_SET_OPERATE_RECHARGE_RED_PACKET", xc.ClientEvent.CE_CHAT_SET_OPERATE_RECHARGE_RED_PACKET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GVOICE_START_RECORD", xc.ClientEvent.CE_GVOICE_START_RECORD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GVOICE_STOP_RECORD", xc.ClientEvent.CE_GVOICE_STOP_RECORD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GVOICE_SPEECH_TO_TEXT_COMPLETE", xc.ClientEvent.CE_GVOICE_SPEECH_TO_TEXT_COMPLETE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GVOICE_RECORD_PLAY_DONE", xc.ClientEvent.CE_GVOICE_RECORD_PLAY_DONE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_VOICE_CONTROL_POINTER_ENTER", xc.ClientEvent.CE_VOICE_CONTROL_POINTER_ENTER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_VOICE_CONTROL_POINTER_EXIT", xc.ClientEvent.CE_VOICE_CONTROL_POINTER_EXIT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_VOICE_CONTROL_POINTER_CLICK", xc.ClientEvent.CE_VOICE_CONTROL_POINTER_CLICK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SELECT_UI", xc.ClientEvent.SELECT_UI);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "OPEN_SYS_WIN", xc.ClientEvent.OPEN_SYS_WIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CLOSE_SYS_WIN", xc.ClientEvent.CLOSE_SYS_WIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHOW_WIN", xc.ClientEvent.SHOW_WIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CLOSE_WIN", xc.ClientEvent.CLOSE_WIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "KEYBOARD_CHANGE", xc.ClientEvent.KEYBOARD_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CONTROL_COMMON_SLIDER", xc.ClientEvent.CONTROL_COMMON_SLIDER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHOW_INTERACT_BUTTON", xc.ClientEvent.SHOW_INTERACT_BUTTON);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "INTERACT_BUTTON_CLICK_CALLBACK", xc.ClientEvent.INTERACT_BUTTON_CLICK_CALLBACK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TASK_CHANGED", xc.ClientEvent.TASK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TASK_PROGRESS_CHANGED", xc.ClientEvent.TASK_PROGRESS_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TASK_ADDED", xc.ClientEvent.TASK_ADDED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TASK_FINISHED", xc.ClientEvent.TASK_FINISHED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TASK_NEW_ACCEPTED", xc.ClientEvent.TASK_NEW_ACCEPTED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TASK_CAN_SUBMIT", xc.ClientEvent.TASK_CAN_SUBMIT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TASK_NAVIGATION_ACTIVE", xc.ClientEvent.TASK_NAVIGATION_ACTIVE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "INTERACT_TASK_NPC_TOUCHED", xc.ClientEvent.INTERACT_TASK_NPC_TOUCHED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "INTERACT_TASK_NPC_UNTOUCHED", xc.ClientEvent.INTERACT_TASK_NPC_UNTOUCHED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BOUNTY_TASK_CHANGED", xc.ClientEvent.BOUNTY_TASK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NAVIGATING_MAIN_TASK_CHANGED", xc.ClientEvent.NAVIGATING_MAIN_TASK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NAVIGATING_BOUNTY_TASK_CHANGED", xc.ClientEvent.NAVIGATING_BOUNTY_TASK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NAVIGATING_GUILD_TASK_CHANGED", xc.ClientEvent.NAVIGATING_GUILD_TASK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GUILD_TASK_CHANGED", xc.ClientEvent.GUILD_TASK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TITLE_TASK_CHANGED", xc.ClientEvent.TITLE_TASK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ESCORT_TASK_CHANGED", xc.ClientEvent.ESCORT_TASK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "OPEN_TASK_WINDOW", xc.ClientEvent.OPEN_TASK_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRANSFER_TO_TASK_POS", xc.ClientEvent.TRANSFER_TO_TASK_POS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TASK_GUIDE", xc.ClientEvent.TASK_GUIDE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRANSFER_TASK_CHANGED", xc.ClientEvent.TRANSFER_TASK_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SELL_INFO_RECEIVED", xc.ClientEvent.SELL_INFO_RECEIVED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BUY_SUCCESSED", xc.ClientEvent.BUY_SUCCESSED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MALL_RECV_SHOP_GOODS", xc.ClientEvent.CE_MALL_RECV_SHOP_GOODS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_UPDATE_DIALOG_WINDOW_INFO", xc.ClientEvent.CE_UPDATE_DIALOG_WINDOW_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_DIALOG_END", xc.ClientEvent.CE_DIALOG_END);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL", xc.ClientEvent.CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_WORLD_BOSS_CANCEL_NOTICE", xc.ClientEvent.CE_WORLD_BOSS_CANCEL_NOTICE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_UPDATE_PET_INFO", xc.ClientEvent.CE_PET_UPDATE_PET_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_UPDATE_PET_EXP", xc.ClientEvent.CE_PET_UPDATE_PET_EXP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_UPDATE_PET_STEP_EXP", xc.ClientEvent.CE_PET_UPDATE_PET_STEP_EXP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_CHANGE_SKIN", xc.ClientEvent.CE_PET_CHANGE_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_UNLOCK_SKIN", xc.ClientEvent.CE_PET_UNLOCK_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_UI_SELECT_SKIN", xc.ClientEvent.CE_PET_UI_SELECT_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_UI_TRY_SELECT_PRE_SKIN", xc.ClientEvent.CE_PET_UI_TRY_SELECT_PRE_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_UI_TYE_SELECT_NEXT_SKIN", xc.ClientEvent.CE_PET_UI_TYE_SELECT_NEXT_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_UPDATE_ALL_PET_PROP", xc.ClientEvent.CE_PET_UPDATE_ALL_PET_PROP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_CLICK_TRY_OPEN_SKIN", xc.ClientEvent.CE_PET_CLICK_TRY_OPEN_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_OPEN_INFO_PANEL", xc.ClientEvent.CE_PET_OPEN_INFO_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_OPEN_DEGREE_PANEL", xc.ClientEvent.CE_PET_OPEN_DEGREE_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_MAIN_CHANGED_IN_SCENE", xc.ClientEvent.CE_PET_MAIN_CHANGED_IN_SCENE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_SHOW_LEVLE_UP_PANEL", xc.ClientEvent.CE_PET_SHOW_LEVLE_UP_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_PET_WINDOW", xc.ClientEvent.CE_OPEN_PET_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_SHOW_LEVLE_UP_STEP_LV", xc.ClientEvent.CE_PET_SHOW_LEVLE_UP_STEP_LV);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_CREATED", xc.ClientEvent.CE_PET_CREATED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_PET_TRIGGER_SKILL", xc.ClientEvent.CE_PET_TRIGGER_SKILL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_CHANGED_GUILD_ID_IN_SCENE", xc.ClientEvent.CE_GUILD_CHANGED_GUILD_ID_IN_SCENE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_SUCCESS_CREATE_GUILD", xc.ClientEvent.CE_GUILD_SUCCESS_CREATE_GUILD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_SUCCESS_JOIN_GUILD", xc.ClientEvent.CE_GUILD_SUCCESS_JOIN_GUILD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_UPDATE_GUILD_INFO", xc.ClientEvent.CE_GUILD_UPDATE_GUILD_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_SUCCESS_EDIT_NOTICE", xc.ClientEvent.CE_GUILD_SUCCESS_EDIT_NOTICE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_INTRO_LIST", xc.ClientEvent.CE_GUILD_RECV_INTRO_LIST);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_SHOW_MAIN_PANEL", xc.ClientEvent.CE_GUILD_SHOW_MAIN_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_INTRO_EXTRA", xc.ClientEvent.CE_GUILD_RECV_INTRO_EXTRA);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_SHOW_GUILD_LIST_PANEL", xc.ClientEvent.CE_GUILD_SHOW_GUILD_LIST_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_LOCAL_PLAYER_LEAVE_GUILD", xc.ClientEvent.CE_GUILD_LOCAL_PLAYER_LEAVE_GUILD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_OTHER_PLAYER_LEAVE_GUILD", xc.ClientEvent.CE_GUILD_OTHER_PLAYER_LEAVE_GUILD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_MEMBER_LIST", xc.ClientEvent.CE_GUILD_RECV_MEMBER_LIST);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_DUTY_APPOINT", xc.ClientEvent.CE_GUILD_RECV_DUTY_APPOINT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_LOCAL_PLAYER_DUTY_APPOINT", xc.ClientEvent.CE_GUILD_RECV_LOCAL_PLAYER_DUTY_APPOINT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_APPLY_INFO", xc.ClientEvent.CE_GUILD_RECV_APPLY_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_HANDLE_APPLY", xc.ClientEvent.CE_GUILD_RECV_HANDLE_APPLY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_AUTO_APPROVE", xc.ClientEvent.CE_GUILD_RECV_AUTO_APPROVE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_ADD_MEMBER", xc.ClientEvent.CE_GUILD_RECV_ADD_MEMBER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_SKILL_LIST", xc.ClientEvent.CE_GUILD_RECV_SKILL_LIST);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_APPLY_NOTICE", xc.ClientEvent.CE_GUILD_RECV_APPLY_NOTICE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_SHOW_GUILD_SKILL_PANEL", xc.ClientEvent.CE_GUILD_SHOW_GUILD_SKILL_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_GUILD_HAS_BEEN_DELETED", xc.ClientEvent.CE_GUILD_GUILD_HAS_BEEN_DELETED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_CHANGED_ID_IN_SCENE", xc.ClientEvent.CE_GUILD_CHANGED_ID_IN_SCENE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_BOSS_INFO", xc.ClientEvent.CE_GUILD_RECV_BOSS_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_CHANGE_BOSS_LEVEL", xc.ClientEvent.CE_GUILD_RECV_CHANGE_BOSS_LEVEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_SUCCESS_OPEN_BOSS", xc.ClientEvent.CE_GUILD_SUCCESS_OPEN_BOSS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_CLOSE_BOSS", xc.ClientEvent.CE_GUILD_CLOSE_BOSS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_RECV_REWARD_PERDAY", xc.ClientEvent.CE_GUILD_RECV_REWARD_PERDAY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_FUND_CHANGE", xc.ClientEvent.CE_GUILD_FUND_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GUILD_LEAGUE_INFO_CHANGED", xc.ClientEvent.CE_GUILD_LEAGUE_INFO_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_UPDATE_GROW_INFO", xc.ClientEvent.CE_MOUNT_UPDATE_GROW_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_SUCCESS_UPGRADE", xc.ClientEvent.CE_MOUNT_SUCCESS_UPGRADE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_SUCCESS_GET_NEW_SKIN", xc.ClientEvent.CE_MOUNT_SUCCESS_GET_NEW_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_SUCCESS_USE_SKIN", xc.ClientEvent.CE_MOUNT_SUCCESS_USE_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_SUCCESS_CHANGE_CUR_SKIN", xc.ClientEvent.CE_MOUNT_SUCCESS_CHANGE_CUR_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_UI_SELECT_SKIN", xc.ClientEvent.CE_MOUNT_UI_SELECT_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_OPEN_DEGREE_PANEL", xc.ClientEvent.CE_MOUNT_OPEN_DEGREE_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_OPEN_SKIN_PANEL", xc.ClientEvent.CE_MOUNT_OPEN_SKIN_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_OPEN_GET_NEW_MOUNT_PANEL", xc.ClientEvent.CE_MOUNT_OPEN_GET_NEW_MOUNT_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_CLOSE_GET_NEW_MOUNT_PANEL", xc.ClientEvent.CE_MOUNT_CLOSE_GET_NEW_MOUNT_PANEL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_LOCAL_PLAYER_CHANGED_ID_IN_SCENE", xc.ClientEvent.CE_MOUNT_LOCAL_PLAYER_CHANGED_ID_IN_SCENE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_MOUNT_WINDOW", xc.ClientEvent.CE_OPEN_MOUNT_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_MOUNT_EXCHANGE_FIRST_GETING_NEW_MOUNT_ID", xc.ClientEvent.CE_MOUNT_EXCHANGE_FIRST_GETING_NEW_MOUNT_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRIALBOSS_RECV_PASS_INFOS", xc.ClientEvent.CE_TRIALBOSS_RECV_PASS_INFOS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRIALBOSS_RECV_GRADE", xc.ClientEvent.CE_TRIALBOSS_RECV_GRADE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRIALBOSS_RECV_INSPIRE", xc.ClientEvent.CE_TRIALBOSS_RECV_INSPIRE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRIALBOSS_RECV_WIN_DUNGEON_RESULT", xc.ClientEvent.CE_TRIALBOSS_RECV_WIN_DUNGEON_RESULT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_STIGMATA_RECV_INFO", xc.ClientEvent.CE_STIGMATA_RECV_INFO);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_STIGMATA_RECV_SUCCESS_ADD_EXP", xc.ClientEvent.CE_STIGMATA_RECV_SUCCESS_ADD_EXP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_STIGMATA_RECV_SHOW_LEVEL_UP", xc.ClientEvent.CE_STIGMATA_RECV_SHOW_LEVEL_UP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_STIGMATA_UI_SELECT_SKIN", xc.ClientEvent.CE_STIGMATA_UI_SELECT_SKIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TIMELINE_START", xc.ClientEvent.CE_TIMELINE_START);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TIMELINE_FINISH", xc.ClientEvent.CE_TIMELINE_FINISH);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_COLLECTION_OBJECTS_COUNT_CHANGED", xc.ClientEvent.CE_COLLECTION_OBJECTS_COUNT_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SCENE_NOT_DOWNLOAD", xc.ClientEvent.CE_SCENE_NOT_DOWNLOAD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GENERIC_GOTO_SYS_WINDOW", xc.ClientEvent.CE_GENERIC_GOTO_SYS_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_ARENA_WINDOW", xc.ClientEvent.CE_OPEN_ARENA_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_PEAK_ARENA_WINDOW", xc.ClientEvent.CE_OPEN_PEAK_ARENA_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_FORGOTTEN_TOMB_WINDOW", xc.ClientEvent.CE_OPEN_FORGOTTEN_TOMB_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_BATTLE_FIELD_WINDOW", xc.ClientEvent.CE_OPEN_BATTLE_FIELD_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_BROKEN_MIRROR_WINDOW", xc.ClientEvent.CE_OPEN_BROKEN_MIRROR_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_MATERIAL_INSTANCE_WINDOW", xc.ClientEvent.CE_OPEN_MATERIAL_INSTANCE_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_SECRET_DEFEND_WINDOW", xc.ClientEvent.CE_OPEN_SECRET_DEFEND_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_PIRATE_SHIP_WINDOW", xc.ClientEvent.CE_OPEN_PIRATE_SHIP_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_TRIAL_BOSS_WINDOW", xc.ClientEvent.CE_OPEN_TRIAL_BOSS_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_FAIRY_WINDOW", xc.ClientEvent.CE_OPEN_FAIRY_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_FAIRY_WINDOW_AND_USE_GOODS", xc.ClientEvent.CE_OPEN_FAIRY_WINDOW_AND_USE_GOODS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_FAIRY_WINDOW_AND_BUY_VIP", xc.ClientEvent.CE_OPEN_FAIRY_WINDOW_AND_BUY_VIP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_DEED_INHERIT_WINDOW", xc.ClientEvent.CE_OPEN_DEED_INHERIT_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_PURGATORY_WINDOW", xc.ClientEvent.CE_OPEN_PURGATORY_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_PERSONAL_BOSS_WINDOW", xc.ClientEvent.CE_OPEN_PERSONAL_BOSS_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_VIP_GIFT_WINDOW", xc.ClientEvent.CE_OPEN_VIP_GIFT_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPEN_PEAK_BOSS_WINDOW", xc.ClientEvent.CE_OPEN_PEAK_BOSS_WINDOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ACTIVITY_DAILY", xc.ClientEvent.CE_ACTIVITY_DAILY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ACTIVITY_STATE_CHANGED", xc.ClientEvent.CE_ACTIVITY_STATE_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPERATING_ACTIVITY_INIT", xc.ClientEvent.CE_OPERATING_ACTIVITY_INIT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPERATING_ACTIVITY_OPEN", xc.ClientEvent.CE_OPERATING_ACTIVITY_OPEN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_OPERATING_ACTIVITY_CLOSE", xc.ClientEvent.CE_OPERATING_ACTIVITY_CLOSE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_UPDATE_SYS_SHOW_CHANGE", xc.ClientEvent.CE_UPDATE_SYS_SHOW_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_ONLINE_REWARD_INFO_CHANGED", xc.ClientEvent.CE_ONLINE_REWARD_INFO_CHANGED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRANSFER_TASK_FINISH", xc.ClientEvent.CE_TRANSFER_TASK_FINISH);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_TRANSFER_FINISH_SHOW_SUC", xc.ClientEvent.CE_TRANSFER_FINISH_SHOW_SUC);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SHORT_CUT_TIPS_NO_GOODS", xc.ClientEvent.CE_SHORT_CUT_TIPS_NO_GOODS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_GOD_WARE_ANI_FINISH", xc.ClientEvent.CE_GOD_WARE_ANI_FINISH);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CHAT_RESPONSE_CLICK_TEXT_HREF", xc.ClientEvent.CE_CHAT_RESPONSE_CLICK_TEXT_HREF);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_BUNDLE_RES_LOAD_FAILED", xc.ClientEvent.CE_BUNDLE_RES_LOAD_FAILED);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SERVERLIST_TO_CREATEACTOR_BEGIN", xc.ClientEvent.CE_SERVERLIST_TO_CREATEACTOR_BEGIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_SERVERLIST_TO_CREATEACTOR_END", xc.ClientEvent.CE_SERVERLIST_TO_CREATEACTOR_END);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CREATEACTOR_TO_GAMESCENE_BEGIN", xc.ClientEvent.CE_CREATEACTOR_TO_GAMESCENE_BEGIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CE_CREATEACTOR_TO_GAMESCENE_END", xc.ClientEvent.CE_CREATEACTOR_TO_GAMESCENE_END);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ClientEvent));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ClientEvent), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcClientEvent(L, (xc.ClientEvent)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "CE_Normal"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SDK_LOGINED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SDK_LOGINED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SDK_INITED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SDK_INITED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SDK_LOGINSUCC"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SDK_LOGINSUCC);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SDK_BIND_MOBILE_SUC"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SDK_BIND_MOBILE_SUC);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_RANDNAME_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_RANDNAME_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DATA_HOTUP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DATA_HOTUP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SELECT_SERVER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SELECT_SERVER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_START_GET_SERVER_INFOS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_START_GET_SERVER_INFOS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SDK_SEND_VERIFY_CODE_RET"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SDK_SEND_VERIFY_CODE_RET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SDK_BIND_PHONE_RET"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SDK_BIND_PHONE_RET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SDK_FACEBOOK_SHARE_SUCCESS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SDK_FACEBOOK_SHARE_SUCCESS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SDK_FACEBOOK_SHARE_FAILED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SDK_FACEBOOK_SHARE_FAILED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NET_MAIN_CONNECTED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NET_MAIN_CONNECTED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NET_CROSS_CONNECTED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NET_CROSS_CONNECTED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NET_MAIN_DISCONNECT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NET_MAIN_DISCONNECT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NET_CROSS_DISCONNECT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NET_CROSS_DISCONNECT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NET_RECONNECT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NET_RECONNECT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NETWORK_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NETWORK_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHARGEINFO_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHARGEINFO_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FIRST_PAY_TIPS_SHOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FIRST_PAY_TIPS_SHOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SERVER_TIME_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SERVER_TIME_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHECK_MINIPACK"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHECK_MINIPACK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_QUIT_GAME"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_QUIT_GAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ENTER_GAME"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ENTER_GAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GAME_INITED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GAME_INITED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ALL_SYSTEM_INITED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ALL_SYSTEM_INITED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_ERROR"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_ERROR);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_APPLICATION_PAUSE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_APPLICATION_PAUSE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PLAYER_DAILY_RESET"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PLAYER_DAILY_RESET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SPAN_SERVER_OPEN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SPAN_SERVER_OPEN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SPAN_SERVER_CLOSE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SPAN_SERVER_CLOSE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SETTING_AUTOADJUST"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SETTING_AUTOADJUST);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SETTING_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SETTING_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SETTING_HOOK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SETTING_HOOK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SETTING_OFFLINE_REWARD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SETTING_OFFLINE_REWARD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SETTING_QUALITY_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SETTING_QUALITY_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SETTING_LOW_FPS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SETTING_LOW_FPS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCALPLAYER_CREATED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCALPLAYER_CREATED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCALPLAYER_MODEL_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCALPLAYER_MODEL_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_REMOTEPLAYER_CREATED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_REMOTEPLAYER_CREATED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ACTOR_BASEINFO_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ACTOR_BASEINFO_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ACTOR_LEVEL_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ACTOR_LEVEL_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WORLD_LEVEL_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WORLD_LEVEL_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCALPLAYER_EXP_ADDED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCALPLAYER_EXP_ADDED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCALPLAYER_BATTLE_POWER_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCALPLAYER_BATTLE_POWER_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MONSTER_DEAD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MONSTER_DEAD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MONSTERDEAD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MONSTERDEAD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MONSTERCREATEED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MONSTERCREATEED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCALMONSTERCREATEED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCALMONSTERCREATEED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_REMOTEMONSTERCREATEED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_REMOTEMONSTERCREATEED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PLAYERDEAD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PLAYERDEAD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NPCDEAD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NPCDEAD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NPCCLICKED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NPCCLICKED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NPCLEAVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NPCLEAVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ACTOR_RES_LOADED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ACTOR_RES_LOADED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ACTOR_FRIEND_MARCK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ACTOR_FRIEND_MARCK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCAL_PLAYER_NWAR_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCAL_PLAYER_NWAR_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ACTOR_SET_CHAOS_MODE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ACTOR_SET_CHAOS_MODE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ACTOR_PATH_POINTS_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ACTOR_PATH_POINTS_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCAL_PLAYER_ADD_ENEMY"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCAL_PLAYER_ADD_ENEMY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCAL_PLAYER_EXCHANGE_PVP_STATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCAL_PLAYER_EXCHANGE_PVP_STATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCAL_PLAYER_NWAR_DEAD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCAL_PLAYER_NWAR_DEAD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCAL_PLAYER_NWAR_REVIVE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCAL_PLAYER_NWAR_REVIVE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_STATUS_TRANSFER_EXIT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_STATUS_TRANSFER_EXIT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DISABLE_CLICKEFFECT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DISABLE_CLICKEFFECT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PLAYER_DEAD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.PLAYER_DEAD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PLAYER_BE_ATTACKED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.PLAYER_BE_ATTACKED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PLAYER_EXIT_IDLE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.PLAYER_EXIT_IDLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EC_PLAYER_LV_POINT_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.EC_PLAYER_LV_POINT_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EC_PLAYER_ATTRS_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.EC_PLAYER_ATTRS_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EC_ACTOR_HP_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.EC_ACTOR_HP_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_ATTRS_UPDATE_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_ATTRS_UPDATE_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EC_ACTOR_MP_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.EC_ACTOR_MP_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EC_ACTOR_UNDER_ATTACK_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.EC_ACTOR_UNDER_ATTACK_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EC_ACTOR_ADD_UNDER_ATTACK"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.EC_ACTOR_ADD_UNDER_ATTACK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUARDED_NPC_HP_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUARDED_NPC_HP_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CUSTOM_DATA_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CUSTOM_DATA_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FIRST_ENTER_SCENE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FIRST_ENTER_SCENE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_START_SWITCHSCENE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_START_SWITCHSCENE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FINISH_LOAD_LEVEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FINISH_LOAD_LEVEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FINISH_SWITCHSCENE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FINISH_SWITCHSCENE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FINISH_LOAD_SCENE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FINISH_LOAD_SCENE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SWITCHINSTANCE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SWITCHINSTANCE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_START_SWITCH_PLANE_INSTANCE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_START_SWITCH_PLANE_INSTANCE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SCENE_DESTROY_ALL_INTER_OBJECT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SCENE_DESTROY_ALL_INTER_OBJECT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICKPLAYER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICKPLAYER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICKPLAYER_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICKPLAYER_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICKNPC"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICKNPC);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICKCHEST"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICKCHEST);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICKMONSTER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICKMONSTER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICKCOLLISION"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICKCOLLISION);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICKCOLLISION_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICKCOLLISION_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICKINTEROBJECTLAYER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICKINTEROBJECTLAYER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_COVER_STATE_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_COVER_STATE_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICKPLAY_DISPLAY_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICKPLAY_DISPLAY_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PLAYERCONTROLED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PLAYERCONTROLED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PLAYER_IN_PORTAL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PLAYER_IN_PORTAL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRANSFER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRANSFER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAINMAP_STATE_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAINMAP_STATE_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAINMAP_ANIMATION_PLAY_END"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAINMAP_ANIMATION_PLAY_END);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAINMAP_SWITCH_ANIMATION"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAINMAP_SWITCH_ANIMATION);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAINMAP_SWTICH_TR_SYSBTN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAINMAP_SWTICH_TR_SYSBTN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TOUCH_NOT_UI"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TOUCH_NOT_UI);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAINMAP_OPEN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAINMAP_OPEN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAIN_MAP_CHECK_MARK"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAIN_MAP_CHECK_MARK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_UPDATE_SYS_MARK"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_UPDATE_SYS_MARK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAINMAP_CLICK_BL_PACKUP_BTN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAINMAP_CLICK_BL_PACKUP_BTN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAINMAP_CHANGE_BOSSHP_VISIBLE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAINMAP_CHANGE_BOSSHP_VISIBLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LINE_CD_TIME"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LINE_CD_TIME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LINE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LINE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LINE_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LINE_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUIDESTART"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUIDESTART);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUIDEEND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUIDEEND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUIDE_STORY_END"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUIDE_STORY_END);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUIDE_UNFOLD_SYS_BTN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUIDE_UNFOLD_SYS_BTN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_CONFIG_INIT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_CONFIG_INIT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NEW_WAITING_SYS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NEW_WAITING_SYS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_RE_OPEN_SYS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_RE_OPEN_SYS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_RED_SPOT_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_RED_SPOT_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_OPEN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_OPEN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_OPEN_POST"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_OPEN_POST);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_OPEN_NOTIFY"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_OPEN_NOTIFY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_CLOSE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_CLOSE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_BTN_CLOSE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_BTN_CLOSE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_OPEN_ANIM_START"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_OPEN_ANIM_START);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_OPEN_ANIM_END"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_OPEN_ANIM_END);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_HSYSBTN_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_HSYSBTN_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_WAIT_OPEN_SWITCH_ANIMATION"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_WAIT_OPEN_SWITCH_ANIMATION);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_SPECIAL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_SPECIAL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_POST_SHOW_TREASURE_OPEN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_POST_SHOW_TREASURE_OPEN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_POST_OPEN_TREASURE_PREVIEW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_POST_OPEN_TREASURE_PREVIEW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_TREASURE_OPEN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_TREASURE_OPEN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_PREVIEW_REWARDED_LISTS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_PREVIEW_REWARDED_LISTS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SYS_PREVIEW_REWARD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SYS_PREVIEW_REWARD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NEW_REDPOINT_SHOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NEW_REDPOINT_SHOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NEW_REDPOINT_DISAPPEAR"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NEW_REDPOINT_DISAPPEAR);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NEW_REDPOINT_BIND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NEW_REDPOINT_BIND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NEW_REDPOINT_UNBIND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NEW_REDPOINT_UNBIND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCK_ICON_BIND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCK_ICON_BIND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCK_ICON_UNBIND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCK_ICON_UNBIND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NEW_MARKER_BIND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NEW_MARKER_BIND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_NEW_MARKER_UNBIND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_NEW_MARKER_UNBIND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_ROLLING_NOTICE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_ROLLING_NOTICE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_ROLLING_NOTICE_END"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_ROLLING_NOTICE_END);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_COMMON_TIPS_WARNNING"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_COMMON_TIPS_WARNNING);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_DANMAKU"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_DANMAKU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLEAR_DANMAKU"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLEAR_DANMAKU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_BOTTOM_MESSAGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_BOTTOM_MESSAGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_COMMON_TEXT_TIPS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_COMMON_TEXT_TIPS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_BIG_COMMON_TEXT_TIPS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_BIG_COMMON_TEXT_TIPS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NEW_MINIMAP_SELECT_MONSTER_MINIMAPINFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.NEW_MINIMAP_SELECT_MONSTER_MINIMAPINFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MINI_MAP_COM_POS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MINI_MAP_COM_POS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_START"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_START);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCALPLAYER_CREATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCALPLAYER_CREATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_REMOTEPLAYER_CREATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_REMOTEPLAYER_CREATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_EXITINSTANCE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_EXITINSTANCE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_POLL_INFO_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_POLL_INFO_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_PHASE_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_PHASE_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_PHASE_PROGRESS_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_PHASE_PROGRESS_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_MARK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_MARK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_KUNGFUGOD_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_KUNGFUGOD_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_DEAD_SPACE_LV_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_DEAD_SPACE_LV_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_DEAD_SPACE_SCORE_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_DEAD_SPACE_SCORE_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_DEAD_SPACE_EXP_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_DEAD_SPACE_EXP_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_FAIRY_VALLEY_INFO_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_FAIRY_VALLEY_INFO_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_FAIRY_VALLEY_INSPIRE_NUM_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_FAIRY_VALLEY_INSPIRE_NUM_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WILD_HUMAN_COUNT_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WILD_HUMAN_COUNT_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTANCE_SHOW_EXIT_INSTANCE_TIME_LABEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTANCE_SHOW_EXIT_INSTANCE_TIME_LABEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LEAVEAOI"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LEAVEAOI);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLEAR_UNITCACHE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLEAR_UNITCACHE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UPDATE_AUTO_BATTLE_UI"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.UPDATE_AUTO_BATTLE_UI);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHOW_AUTO_BATTLE_GET_EXP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SHOW_AUTO_BATTLE_GET_EXP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHOW_SKILL_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SHOW_SKILL_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PICK_DROP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PICK_DROP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DESTROY_DROP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DESTROY_DROP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DROP_DISAPPEAR"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DROP_DISAPPEAR);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHOW_PICK_DROP_FLOAT_TIPS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHOW_PICK_DROP_FLOAT_TIPS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PICK_DROP_SHOW_BOSS_CHIP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PICK_DROP_SHOW_BOSS_CHIP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PICK_DROP_DISAPPEAR_BOSS_CHIP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PICK_DROP_DISAPPEAR_BOSS_CHIP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PICK_DROP_BREAK_PICK_UP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PICK_DROP_BREAK_PICK_UP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PICK_DROP_START_PICK_UP_LOCALPLAYER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PICK_DROP_START_PICK_UP_LOCALPLAYER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PICK_DROP_CONTROL_SLIDER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PICK_DROP_CONTROL_SLIDER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LOCAL_PLAYER_EXIT_INTERACTION"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LOCAL_PLAYER_EXIT_INTERACTION);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAIL_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAIL_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAIL_DETAIL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAIL_DETAIL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAIL_NEW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAIL_NEW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAIL_READ"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAIL_READ);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAIL_GET"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAIL_GET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAIL_DEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAIL_DEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NEW_MAIL_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.NEW_MAIL_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_UPDATE_SLOT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_UPDATE_SLOT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_UPDATE_SLOT_DEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_UPDATE_SLOT_DEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_UPDATE_SLOT_INSTALL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_UPDATE_SLOT_INSTALL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_UPDATE_SLOT_EXTEND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_UPDATE_SLOT_EXTEND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WARE_UPDATE_SLOT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WARE_UPDATE_SLOT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WARE_UPDATE_SLOT_INSTALL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WARE_UPDATE_SLOT_INSTALL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WARE_UPDATE_SLOT_EXTEND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WARE_UPDATE_SLOT_EXTEND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_ADD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_ADD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_DEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_DEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_GOODS_ADD_NUM"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_GOODS_ADD_NUM);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_GOODS_ADD_NUM_OPERATE_NONE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_GOODS_ADD_NUM_OPERATE_NONE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAG_PAGE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAG_PAGE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WAREHOUSE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WAREHOUSE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WAREHOUSE_PAGE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WAREHOUSE_PAGE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTALL_1_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTALL_1_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SOUL_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SOUL_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SOUL_PAGE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SOUL_PAGE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTALL_2_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTALL_2_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTALL_2_PAGE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTALL_2_PAGE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GOODS_CD_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GOODS_CD_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MONEY_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MONEY_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OFFLINE_HANGE_TIME_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OFFLINE_HANGE_TIME_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GOODS_ADD_TIP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GOODS_ADD_TIP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ONE_BAGTYPE_SIZE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ONE_BAGTYPE_SIZE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTALL_1_EFLIN_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTALL_1_EFLIN_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GOODS_UPDATE_EXPIRE_TIME"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GOODS_UPDATE_EXPIRE_TIME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GOODS_USE_TIMES_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GOODS_USE_TIMES_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTALL_3_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTALL_3_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DECORATE_BAG_SIZE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DECORATE_BAG_SIZE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DECORATE_BAG_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DECORATE_BAG_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TREASURE_HUNT_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TREASURE_HUNT_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ID_TREASURE_BAG_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ID_TREASURE_BAG_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_HANDBOOK_BAG_SIZE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_HANDBOOK_BAG_SIZE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_HANDBOOK_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_HANDBOOK_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WEARING_MAGIC_EQUIP_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WEARING_MAGIC_EQUIP_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAGIC_EQUIP_BAG_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAGIC_EQUIP_BAG_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MAGIC_EQUIP_BAG_SIZE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MAGIC_EQUIP_BAG_SIZE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GOD_EQUIP_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GOD_EQUIP_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GOD_EQUIP_BAG_SIZE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GOD_EQUIP_BAG_SIZE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GOD_EQUIP_BAG_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GOD_EQUIP_BAG_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ELEMENT_EQUIP_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ELEMENT_EQUIP_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ELEMENT_EQUIP_BAG_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ELEMENT_EQUIP_BAG_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_EQUIP_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_EQUIP_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_EQUIP_BAG_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_EQUIP_BAG_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_EQUIP_BAG_SIZE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_EQUIP_BAG_SIZE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LIGHT_WEAPON_SOUL_UPDATE_INSTALLED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LIGHT_WEAPON_SOUL_UPDATE_INSTALLED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LIGHT_WEAPON_SOUL_BAG_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LIGHT_WEAPON_SOUL_BAG_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_LIGHT_WEAPON_SOUL_BAG_SIZE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_LIGHT_WEAPON_SOUL_BAG_SIZE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GOODS_LIST_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GOODS_LIST_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_SPIRIT_RUNES_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_SPIRIT_RUNES_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SOUL_OPEN_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SOUL_OPEN_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TEAM_INFO_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TEAM_INFO_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TEAM_APPLY_INFO_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TEAM_APPLY_INFO_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TEAM_BE_INVITED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TEAM_BE_INVITED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TEAM_TARGET_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TEAM_TARGET_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TEAM_AUTO_MATCHING_STATE_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TEAM_AUTO_MATCHING_STATE_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TEAM_INVITE_ALL_CD_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TEAM_INVITE_ALL_CD_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TEAM_SYSTEM_MESSAGE_SHOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TEAM_SYSTEM_MESSAGE_SHOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TEAM_CLICK_CLOSE_WINDOW_BTN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TEAM_CLICK_CLOSE_WINDOW_BTN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TEAM_HIDE_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TEAM_HIDE_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTALLED_EQUIP_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTALLED_EQUIP_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_EQUIP_INFO_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_EQUIP_INFO_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_INSTALLED_EQUIP_INFO_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_INSTALLED_EQUIP_INFO_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_STRENGTH_RESULT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_STRENGTH_RESULT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_STRENGTH_UP_LV"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_STRENGTH_UP_LV);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_STRENGTH_EQUIP_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_STRENGTH_EQUIP_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAPTIZE_EQUIP_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAPTIZE_EQUIP_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BAPTIZE_EQUIP_RESULT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BAPTIZE_EQUIP_RESULT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SUIT_EQUIP_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SUIT_EQUIP_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SUIT_REFINE_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SUIT_REFINE_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_EQUIP_GEM_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_EQUIP_GEM_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_EQUIP_STRENGTH_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_EQUIP_STRENGTH_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_EQUIP_FASHION_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_EQUIP_FASHION_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DECORATE_STRENGTH_RESULT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DECORATE_STRENGTH_RESULT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DECORATE_BREAK_RESULT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DECORATE_BREAK_RESULT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DECORATE_POS_INFO_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DECORATE_POS_INFO_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LOCKTARGET"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LOCKTARGET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRIGGER_SKILL_CLICK_BUTTON"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRIGGER_SKILL_PRESS_BUTTON"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRIGGER_SKILL_PRESS_BUTTON);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRIGGER_SKILL_RELEASE_BUTTON"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRIGGER_SKILL_RELEASE_BUTTON);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRIGGER_SKILL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRIGGER_SKILL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ATTACK_SUCC"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ATTACK_SUCC);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SELECTACTOR_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SELECTACTOR_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SELECTACTOR_WHEN_CAST_SKILL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SELECTACTOR_WHEN_CAST_SKILL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BATTLESTATUS_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BATTLESTATUS_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHAPE_SHIFT_BEGIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHAPE_SHIFT_BEGIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHAPE_SHIFT_END"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHAPE_SHIFT_END);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LOCALPLAYER_CASTINGREADY_STATGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LOCALPLAYER_CASTINGREADY_STATGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LOCALPLAYER_PKMODE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LOCALPLAYER_PKMODE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LOCALPLAYER_PKVALUE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LOCALPLAYER_PKVALUE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LOCALPLAYER_IN_SAFE_AREA"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LOCALPLAYER_IN_SAFE_AREA);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LOCALPLAYER_IN_PK_AREA"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LOCALPLAYER_IN_PK_AREA);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BUFF_LIST_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BUFF_LIST_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LOCALPLAYER_RADIUS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LOCALPLAYER_RADIUS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHANGE_LOCALPLAYER_SKILL_SLOT_LIST"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHANGE_LOCALPLAYER_SKILL_SLOT_LIST);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_AUTO_FIGHT_STATE_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_AUTO_FIGHT_STATE_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BUFF_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BUFF_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CLICK_MATE_SKILL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CLICK_MATE_SKILL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MATE_SKILL_ACTION"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MATE_SKILL_ACTION);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FIVE_ATTR_NOENOUGH"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FIVE_ATTR_NOENOUGH);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SKILL_LIST_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SKILL_LIST_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SKILL_UPGRADED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SKILL_UPGRADED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SKILL_KEY_POS_SET"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SKILL_KEY_POS_SET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SKILL_KEY_CONFIG_CHOOSED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SKILL_KEY_CONFIG_CHOOSED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "INBORN_INFO_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.INBORN_INFO_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SKILL_OPENNEW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SKILL_OPENNEW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FURYSKILL_CANUSE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FURYSKILL_CANUSE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SKILL_MATE_UPDATE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SKILL_MATE_UPDATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SKILL_MATE_USE_SUCCESS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SKILL_MATE_USE_SUCCESS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FRIENDS_ONLINE_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FRIENDS_ONLINE_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FRIENDS_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FRIENDS_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FRIENDS_ENEMY_POS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FRIENDS_ENEMY_POS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FRIENDS_SEARCH_RESULT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FRIENDS_SEARCH_RESULT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FRIENDS_RECOMMEND"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FRIENDS_RECOMMEND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FRIENDS_RECOMMEND_CD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FRIENDS_RECOMMEND_CD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FRIENDS_APPLICANTS_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FRIENDS_APPLICANTS_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FRIENDS_INTIMACY_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FRIENDS_INTIMACY_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_FRIENDS_ADD_BOTH_SIDES"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_FRIENDS_ADD_BOTH_SIDES);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_RECEIVE_FLOWER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_RECEIVE_FLOWER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SEND_FLOWER_KISS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SEND_FLOWER_KISS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_UNREAD_MESSAGE_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_UNREAD_MESSAGE_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_PLAY_NOTICE_MESSAGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_PLAY_NOTICE_MESSAGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CC_CHAT_PLAY_VOICE_MESSAGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CC_CHAT_PLAY_VOICE_MESSAGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_VOICE_CLICK_MESSAGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_VOICE_CLICK_MESSAGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_VOICE_START_MESSAGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_VOICE_START_MESSAGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_VOICE_END_MESSAGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_VOICE_END_MESSAGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_TOOLKIT_SEND_TEXT_TO_INPUTFIELD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_TOOLKIT_SEND_TEXT_TO_INPUTFIELD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_HISTORY_TO_INPUTFIELD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_HISTORY_TO_INPUTFIELD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_TRUMPET_CONTENT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_TRUMPET_CONTENT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WORLD_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.WORLD_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SOCIETY_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SOCIETY_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PRIVATE_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.PRIVATE_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TEAMENLIST_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TEAMENLIST_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "INVITE_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.INVITE_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TEAM_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TEAM_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WILD_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.WILD_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SYSYTEM_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SYSYTEM_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SPAN_MESSAGE_RECEIVIED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SPAN_MESSAGE_RECEIVIED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "INTEGRATE_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.INTEGRATE_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CHAT_VOICE_RECORDING_CANCELD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CHAT_VOICE_RECORDING_CANCELD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRUMPET_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TRUMPET_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UNION_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.UNION_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CROSS_SERVER_CAMP_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CROSS_SERVER_CAMP_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CROSS_SERVER_PUBLIC_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CROSS_SERVER_PUBLIC_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AOI_MESSAGE_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.AOI_MESSAGE_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "VOICE_AUTOPLAY_NOTIFY"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.VOICE_AUTOPLAY_NOTIFY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SEND_CHAT_NOTIFY"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SEND_CHAT_NOTIFY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "VOICE_PLAY_NOTIFY"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.VOICE_PLAY_NOTIFY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CLOSE_CHAT_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CLOSE_CHAT_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_JUMP_TO_CONST_POSITION"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_JUMP_TO_CONST_POSITION);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CHAT_CLICK_RECHARGE_RED_PACKET"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CHAT_CLICK_RECHARGE_RED_PACKET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_SET_OPERATE_RECHARGE_RED_PACKET"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_SET_OPERATE_RECHARGE_RED_PACKET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GVOICE_START_RECORD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GVOICE_START_RECORD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GVOICE_STOP_RECORD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GVOICE_STOP_RECORD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GVOICE_SPEECH_TO_TEXT_COMPLETE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GVOICE_SPEECH_TO_TEXT_COMPLETE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GVOICE_RECORD_PLAY_DONE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GVOICE_RECORD_PLAY_DONE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_VOICE_CONTROL_POINTER_ENTER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_VOICE_CONTROL_POINTER_ENTER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_VOICE_CONTROL_POINTER_EXIT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_VOICE_CONTROL_POINTER_EXIT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_VOICE_CONTROL_POINTER_CLICK"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_VOICE_CONTROL_POINTER_CLICK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SELECT_UI"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SELECT_UI);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OPEN_SYS_WIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.OPEN_SYS_WIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CLOSE_SYS_WIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CLOSE_SYS_WIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHOW_WIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SHOW_WIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CLOSE_WIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CLOSE_WIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "KEYBOARD_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.KEYBOARD_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CONTROL_COMMON_SLIDER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CONTROL_COMMON_SLIDER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHOW_INTERACT_BUTTON"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SHOW_INTERACT_BUTTON);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "INTERACT_BUTTON_CLICK_CALLBACK"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.INTERACT_BUTTON_CLICK_CALLBACK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TASK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TASK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TASK_PROGRESS_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TASK_PROGRESS_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TASK_ADDED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TASK_ADDED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TASK_FINISHED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TASK_FINISHED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TASK_NEW_ACCEPTED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TASK_NEW_ACCEPTED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TASK_CAN_SUBMIT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TASK_CAN_SUBMIT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TASK_NAVIGATION_ACTIVE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TASK_NAVIGATION_ACTIVE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "INTERACT_TASK_NPC_TOUCHED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.INTERACT_TASK_NPC_TOUCHED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "INTERACT_TASK_NPC_UNTOUCHED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.INTERACT_TASK_NPC_UNTOUCHED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BOUNTY_TASK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.BOUNTY_TASK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NAVIGATING_MAIN_TASK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.NAVIGATING_MAIN_TASK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NAVIGATING_BOUNTY_TASK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.NAVIGATING_BOUNTY_TASK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NAVIGATING_GUILD_TASK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.NAVIGATING_GUILD_TASK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GUILD_TASK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.GUILD_TASK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TITLE_TASK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TITLE_TASK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ESCORT_TASK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.ESCORT_TASK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OPEN_TASK_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.OPEN_TASK_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRANSFER_TO_TASK_POS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TRANSFER_TO_TASK_POS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TASK_GUIDE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TASK_GUIDE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRANSFER_TASK_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.TRANSFER_TASK_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SELL_INFO_RECEIVED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.SELL_INFO_RECEIVED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BUY_SUCCESSED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.BUY_SUCCESSED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MALL_RECV_SHOP_GOODS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MALL_RECV_SHOP_GOODS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_UPDATE_DIALOG_WINDOW_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_UPDATE_DIALOG_WINDOW_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_DIALOG_END"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_DIALOG_END);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_WORLD_BOSS_CANCEL_NOTICE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_WORLD_BOSS_CANCEL_NOTICE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_UPDATE_PET_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_UPDATE_PET_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_UPDATE_PET_EXP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_UPDATE_PET_EXP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_UPDATE_PET_STEP_EXP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_UPDATE_PET_STEP_EXP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_CHANGE_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_CHANGE_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_UNLOCK_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_UNLOCK_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_UI_SELECT_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_UI_SELECT_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_UI_TRY_SELECT_PRE_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_UI_TRY_SELECT_PRE_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_UI_TYE_SELECT_NEXT_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_UI_TYE_SELECT_NEXT_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_UPDATE_ALL_PET_PROP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_UPDATE_ALL_PET_PROP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_CLICK_TRY_OPEN_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_CLICK_TRY_OPEN_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_OPEN_INFO_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_OPEN_INFO_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_OPEN_DEGREE_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_OPEN_DEGREE_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_MAIN_CHANGED_IN_SCENE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_MAIN_CHANGED_IN_SCENE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_SHOW_LEVLE_UP_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_SHOW_LEVLE_UP_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_PET_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_PET_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_SHOW_LEVLE_UP_STEP_LV"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_SHOW_LEVLE_UP_STEP_LV);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_CREATED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_CREATED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_PET_TRIGGER_SKILL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_PET_TRIGGER_SKILL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_CHANGED_GUILD_ID_IN_SCENE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_CHANGED_GUILD_ID_IN_SCENE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_SUCCESS_CREATE_GUILD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_SUCCESS_CREATE_GUILD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_SUCCESS_JOIN_GUILD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_SUCCESS_JOIN_GUILD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_UPDATE_GUILD_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_UPDATE_GUILD_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_SUCCESS_EDIT_NOTICE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_SUCCESS_EDIT_NOTICE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_INTRO_LIST"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_INTRO_LIST);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_SHOW_MAIN_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_SHOW_MAIN_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_INTRO_EXTRA"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_INTRO_EXTRA);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_SHOW_GUILD_LIST_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_SHOW_GUILD_LIST_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_LOCAL_PLAYER_LEAVE_GUILD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_LOCAL_PLAYER_LEAVE_GUILD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_OTHER_PLAYER_LEAVE_GUILD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_OTHER_PLAYER_LEAVE_GUILD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_MEMBER_LIST"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_MEMBER_LIST);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_DUTY_APPOINT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_DUTY_APPOINT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_LOCAL_PLAYER_DUTY_APPOINT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_LOCAL_PLAYER_DUTY_APPOINT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_APPLY_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_APPLY_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_HANDLE_APPLY"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_HANDLE_APPLY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_AUTO_APPROVE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_AUTO_APPROVE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_ADD_MEMBER"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_ADD_MEMBER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_SKILL_LIST"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_SKILL_LIST);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_APPLY_NOTICE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_APPLY_NOTICE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_SHOW_GUILD_SKILL_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_SHOW_GUILD_SKILL_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_GUILD_HAS_BEEN_DELETED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_GUILD_HAS_BEEN_DELETED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_CHANGED_ID_IN_SCENE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_CHANGED_ID_IN_SCENE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_BOSS_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_BOSS_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_CHANGE_BOSS_LEVEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_CHANGE_BOSS_LEVEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_SUCCESS_OPEN_BOSS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_SUCCESS_OPEN_BOSS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_CLOSE_BOSS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_CLOSE_BOSS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_RECV_REWARD_PERDAY"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_RECV_REWARD_PERDAY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_FUND_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_FUND_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GUILD_LEAGUE_INFO_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GUILD_LEAGUE_INFO_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_UPDATE_GROW_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_UPDATE_GROW_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_SUCCESS_UPGRADE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_SUCCESS_UPGRADE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_SUCCESS_GET_NEW_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_SUCCESS_GET_NEW_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_SUCCESS_USE_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_SUCCESS_USE_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_SUCCESS_CHANGE_CUR_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_SUCCESS_CHANGE_CUR_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_UI_SELECT_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_UI_SELECT_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_OPEN_DEGREE_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_OPEN_DEGREE_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_OPEN_SKIN_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_OPEN_SKIN_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_OPEN_GET_NEW_MOUNT_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_OPEN_GET_NEW_MOUNT_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_CLOSE_GET_NEW_MOUNT_PANEL"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_CLOSE_GET_NEW_MOUNT_PANEL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_LOCAL_PLAYER_CHANGED_ID_IN_SCENE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_LOCAL_PLAYER_CHANGED_ID_IN_SCENE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_MOUNT_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_MOUNT_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_MOUNT_EXCHANGE_FIRST_GETING_NEW_MOUNT_ID"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_MOUNT_EXCHANGE_FIRST_GETING_NEW_MOUNT_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRIALBOSS_RECV_PASS_INFOS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRIALBOSS_RECV_PASS_INFOS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRIALBOSS_RECV_GRADE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRIALBOSS_RECV_GRADE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRIALBOSS_RECV_INSPIRE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRIALBOSS_RECV_INSPIRE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRIALBOSS_RECV_WIN_DUNGEON_RESULT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRIALBOSS_RECV_WIN_DUNGEON_RESULT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_STIGMATA_RECV_INFO"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_STIGMATA_RECV_INFO);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_STIGMATA_RECV_SUCCESS_ADD_EXP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_STIGMATA_RECV_SUCCESS_ADD_EXP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_STIGMATA_RECV_SHOW_LEVEL_UP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_STIGMATA_RECV_SHOW_LEVEL_UP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_STIGMATA_UI_SELECT_SKIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_STIGMATA_UI_SELECT_SKIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TIMELINE_START"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TIMELINE_START);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TIMELINE_FINISH"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TIMELINE_FINISH);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_COLLECTION_OBJECTS_COUNT_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_COLLECTION_OBJECTS_COUNT_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SCENE_NOT_DOWNLOAD"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SCENE_NOT_DOWNLOAD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GENERIC_GOTO_SYS_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GENERIC_GOTO_SYS_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_ARENA_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_ARENA_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_PEAK_ARENA_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_PEAK_ARENA_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_FORGOTTEN_TOMB_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_FORGOTTEN_TOMB_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_BATTLE_FIELD_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_BATTLE_FIELD_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_BROKEN_MIRROR_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_BROKEN_MIRROR_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_MATERIAL_INSTANCE_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_MATERIAL_INSTANCE_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_SECRET_DEFEND_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_SECRET_DEFEND_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_PIRATE_SHIP_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_PIRATE_SHIP_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_TRIAL_BOSS_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_TRIAL_BOSS_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_FAIRY_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_FAIRY_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_FAIRY_WINDOW_AND_USE_GOODS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_FAIRY_WINDOW_AND_USE_GOODS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_FAIRY_WINDOW_AND_BUY_VIP"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_FAIRY_WINDOW_AND_BUY_VIP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_DEED_INHERIT_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_DEED_INHERIT_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_PURGATORY_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_PURGATORY_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_PERSONAL_BOSS_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_PERSONAL_BOSS_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_VIP_GIFT_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_VIP_GIFT_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPEN_PEAK_BOSS_WINDOW"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPEN_PEAK_BOSS_WINDOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ACTIVITY_DAILY"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ACTIVITY_DAILY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ACTIVITY_STATE_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ACTIVITY_STATE_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPERATING_ACTIVITY_INIT"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPERATING_ACTIVITY_INIT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPERATING_ACTIVITY_OPEN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPERATING_ACTIVITY_OPEN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_OPERATING_ACTIVITY_CLOSE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_OPERATING_ACTIVITY_CLOSE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_UPDATE_SYS_SHOW_CHANGE"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_UPDATE_SYS_SHOW_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_ONLINE_REWARD_INFO_CHANGED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_ONLINE_REWARD_INFO_CHANGED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRANSFER_TASK_FINISH"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRANSFER_TASK_FINISH);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_TRANSFER_FINISH_SHOW_SUC"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_TRANSFER_FINISH_SHOW_SUC);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SHORT_CUT_TIPS_NO_GOODS"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SHORT_CUT_TIPS_NO_GOODS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_GOD_WARE_ANI_FINISH"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_GOD_WARE_ANI_FINISH);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CHAT_RESPONSE_CLICK_TEXT_HREF"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CHAT_RESPONSE_CLICK_TEXT_HREF);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_BUNDLE_RES_LOAD_FAILED"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_BUNDLE_RES_LOAD_FAILED);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SERVERLIST_TO_CREATEACTOR_BEGIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SERVERLIST_TO_CREATEACTOR_BEGIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_SERVERLIST_TO_CREATEACTOR_END"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_SERVERLIST_TO_CREATEACTOR_END);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CREATEACTOR_TO_GAMESCENE_BEGIN"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CREATEACTOR_TO_GAMESCENE_BEGIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CE_CREATEACTOR_TO_GAMESCENE_END"))
                {
                    translator.PushxcClientEvent(L, xc.ClientEvent.CE_CREATEACTOR_TO_GAMESCENE_END);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ClientEvent!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ClientEvent! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class CameraControlEModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(CameraControl.EMode), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(CameraControl.EMode), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(CameraControl.EMode), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CM_FOLLOW", CameraControl.EMode.CM_FOLLOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CM_FOLLOW_FORCE_FOCUS", CameraControl.EMode.CM_FOLLOW_FORCE_FOCUS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CM_STATIC", CameraControl.EMode.CM_STATIC);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(CameraControl.EMode));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(CameraControl.EMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushCameraControlEMode(L, (CameraControl.EMode)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "CM_FOLLOW"))
                {
                    translator.PushCameraControlEMode(L, CameraControl.EMode.CM_FOLLOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CM_FOLLOW_FORCE_FOCUS"))
                {
                    translator.PushCameraControlEMode(L, CameraControl.EMode.CM_FOLLOW_FORCE_FOCUS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CM_STATIC"))
                {
                    translator.PushCameraControlEMode(L, CameraControl.EMode.CM_STATIC);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for CameraControl.EMode!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for CameraControl.EMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBManagerCommandTagWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBManager.CommandTag), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBManager.CommandTag), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBManager.CommandTag), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TAG_2", xc.DBManager.CommandTag.TAG_2);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TAG_3", xc.DBManager.CommandTag.TAG_3);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBManager.CommandTag));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBManager.CommandTag), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBManagerCommandTag(L, (xc.DBManager.CommandTag)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "TAG_2"))
                {
                    translator.PushxcDBManagerCommandTag(L, xc.DBManager.CommandTag.TAG_2);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TAG_3"))
                {
                    translator.PushxcDBManagerCommandTag(L, xc.DBManager.CommandTag.TAG_3);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBManager.CommandTag!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBManager.CommandTag! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBNoticeEFillTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBNotice.EFillType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBNotice.EFillType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBNotice.EFillType), L, null, 35, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ORDINARY", xc.DBNotice.EFillType.ORDINARY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PLAYER_NAME", xc.DBNotice.EFillType.PLAYER_NAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PLAYER_ID", xc.DBNotice.EFillType.PLAYER_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GOODS_NAME", xc.DBNotice.EFillType.GOODS_NAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GOODS_GID", xc.DBNotice.EFillType.GOODS_GID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MONSTER_NAME", xc.DBNotice.EFillType.MONSTER_NAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "INSTANCE_NAME", xc.DBNotice.EFillType.INSTANCE_NAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ACTIVITY_SCENE_NAME", xc.DBNotice.EFillType.ACTIVITY_SCENE_NAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "COLOR_TYPE", xc.DBNotice.EFillType.COLOR_TYPE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CHAT_GOODS_TYPELINK", xc.DBNotice.EFillType.CHAT_GOODS_TYPELINK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CLIENT_GOODS_TYPELINK", xc.DBNotice.EFillType.CLIENT_GOODS_TYPELINK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "HIDE_PLAYER_ID", xc.DBNotice.EFillType.HIDE_PLAYER_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GOODS_GID_NEW", xc.DBNotice.EFillType.GOODS_GID_NEW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PET_ID", xc.DBNotice.EFillType.PET_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TITLE_ID", xc.DBNotice.EFillType.TITLE_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "QUAL_WORD", xc.DBNotice.EFillType.QUAL_WORD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRANSFER_LV", xc.DBNotice.EFillType.TRANSFER_LV);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "InitVocation", xc.DBNotice.EFillType.InitVocation);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHOW_TYPE_TO_NAME", xc.DBNotice.EFillType.SHOW_TYPE_TO_NAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHOW_TYPE_TO_PARAM", xc.DBNotice.EFillType.SHOW_TYPE_TO_PARAM);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHOW_TYPE_TO_FACADE_ID", xc.DBNotice.EFillType.SHOW_TYPE_TO_FACADE_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHOW_TYPE_TO_SYS_ID", xc.DBNotice.EFillType.SHOW_TYPE_TO_SYS_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FASHION_NAME", xc.DBNotice.EFillType.FASHION_NAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MALL_NAME", xc.DBNotice.EFillType.MALL_NAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ESCORT_TASK_ID", xc.DBNotice.EFillType.ESCORT_TASK_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "INSTANCE_ID", xc.DBNotice.EFillType.INSTANCE_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GODWARE_ID", xc.DBNotice.EFillType.GODWARE_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TIMEFORMAT", xc.DBNotice.EFillType.TIMEFORMAT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BIG_PACKET", xc.DBNotice.EFillType.BIG_PACKET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SMALL_PACKET", xc.DBNotice.EFillType.SMALL_PACKET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MARKET_ID", xc.DBNotice.EFillType.MARKET_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CONTROL_ID", xc.DBNotice.EFillType.CONTROL_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CHANNEL_ID", xc.DBNotice.EFillType.CHANNEL_ID);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBNotice.EFillType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBNotice.EFillType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBNoticeEFillType(L, (xc.DBNotice.EFillType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "ORDINARY"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.ORDINARY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PLAYER_NAME"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.PLAYER_NAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PLAYER_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.PLAYER_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GOODS_NAME"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.GOODS_NAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GOODS_GID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.GOODS_GID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MONSTER_NAME"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.MONSTER_NAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "INSTANCE_NAME"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.INSTANCE_NAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ACTIVITY_SCENE_NAME"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.ACTIVITY_SCENE_NAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "COLOR_TYPE"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.COLOR_TYPE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CHAT_GOODS_TYPELINK"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.CHAT_GOODS_TYPELINK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CLIENT_GOODS_TYPELINK"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.CLIENT_GOODS_TYPELINK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HIDE_PLAYER_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.HIDE_PLAYER_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GOODS_GID_NEW"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.GOODS_GID_NEW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PET_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.PET_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TITLE_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.TITLE_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QUAL_WORD"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.QUAL_WORD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRANSFER_LV"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.TRANSFER_LV);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "InitVocation"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.InitVocation);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHOW_TYPE_TO_NAME"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.SHOW_TYPE_TO_NAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHOW_TYPE_TO_PARAM"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.SHOW_TYPE_TO_PARAM);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHOW_TYPE_TO_FACADE_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.SHOW_TYPE_TO_FACADE_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHOW_TYPE_TO_SYS_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.SHOW_TYPE_TO_SYS_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FASHION_NAME"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.FASHION_NAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MALL_NAME"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.MALL_NAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ESCORT_TASK_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.ESCORT_TASK_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "INSTANCE_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.INSTANCE_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GODWARE_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.GODWARE_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TIMEFORMAT"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.TIMEFORMAT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BIG_PACKET"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.BIG_PACKET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SMALL_PACKET"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.SMALL_PACKET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MARKET_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.MARKET_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CONTROL_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.CONTROL_ID);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CHANNEL_ID"))
                {
                    translator.PushxcDBNoticeEFillType(L, xc.DBNotice.EFillType.CHANNEL_ID);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBNotice.EFillType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBNotice.EFillType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBDataAllSkillSET_SLOT_TYPEWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBDataAllSkill.SET_SLOT_TYPE), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBDataAllSkill.SET_SLOT_TYPE), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBDataAllSkill.SET_SLOT_TYPE), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", xc.DBDataAllSkill.SET_SLOT_TYPE.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BasicSkill", xc.DBDataAllSkill.SET_SLOT_TYPE.BasicSkill);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FurySkill", xc.DBDataAllSkill.SET_SLOT_TYPE.FurySkill);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MateSKill", xc.DBDataAllSkill.SET_SLOT_TYPE.MateSKill);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBDataAllSkill.SET_SLOT_TYPE));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBDataAllSkill.SET_SLOT_TYPE), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBDataAllSkillSET_SLOT_TYPE(L, (xc.DBDataAllSkill.SET_SLOT_TYPE)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushxcDBDataAllSkillSET_SLOT_TYPE(L, xc.DBDataAllSkill.SET_SLOT_TYPE.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BasicSkill"))
                {
                    translator.PushxcDBDataAllSkillSET_SLOT_TYPE(L, xc.DBDataAllSkill.SET_SLOT_TYPE.BasicSkill);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FurySkill"))
                {
                    translator.PushxcDBDataAllSkillSET_SLOT_TYPE(L, xc.DBDataAllSkill.SET_SLOT_TYPE.FurySkill);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MateSKill"))
                {
                    translator.PushxcDBDataAllSkillSET_SLOT_TYPE(L, xc.DBDataAllSkill.SET_SLOT_TYPE.MateSKill);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBDataAllSkill.SET_SLOT_TYPE!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBDataAllSkill.SET_SLOT_TYPE! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBDataAllSkillSKILL_TYPEWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBDataAllSkill.SKILL_TYPE), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBDataAllSkill.SKILL_TYPE), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBDataAllSkill.SKILL_TYPE), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", xc.DBDataAllSkill.SKILL_TYPE.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Active", xc.DBDataAllSkill.SKILL_TYPE.Active);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Passive", xc.DBDataAllSkill.SKILL_TYPE.Passive);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBDataAllSkill.SKILL_TYPE));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBDataAllSkill.SKILL_TYPE), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBDataAllSkillSKILL_TYPE(L, (xc.DBDataAllSkill.SKILL_TYPE)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushxcDBDataAllSkillSKILL_TYPE(L, xc.DBDataAllSkill.SKILL_TYPE.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Active"))
                {
                    translator.PushxcDBDataAllSkillSKILL_TYPE(L, xc.DBDataAllSkill.SKILL_TYPE.Active);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Passive"))
                {
                    translator.PushxcDBDataAllSkillSKILL_TYPE(L, xc.DBDataAllSkill.SKILL_TYPE.Passive);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBDataAllSkill.SKILL_TYPE!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBDataAllSkill.SKILL_TYPE! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DBBuffSevBindPosWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(DBBuffSev.BindPos), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(DBBuffSev.BindPos), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(DBBuffSev.BindPos), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BP_Body", DBBuffSev.BindPos.BP_Body);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BP_Head", DBBuffSev.BindPos.BP_Head);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BP_Foot", DBBuffSev.BindPos.BP_Foot);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(DBBuffSev.BindPos));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(DBBuffSev.BindPos), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDBBuffSevBindPos(L, (DBBuffSev.BindPos)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "BP_Body"))
                {
                    translator.PushDBBuffSevBindPos(L, DBBuffSev.BindPos.BP_Body);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BP_Head"))
                {
                    translator.PushDBBuffSevBindPos(L, DBBuffSev.BindPos.BP_Head);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BP_Foot"))
                {
                    translator.PushDBBuffSevBindPos(L, DBBuffSev.BindPos.BP_Foot);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DBBuffSev.BindPos!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DBBuffSev.BindPos! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBGrowSkinSkinUnLockTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBGrowSkin.SkinUnLockType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBGrowSkin.SkinUnLockType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBGrowSkin.SkinUnLockType), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", xc.DBGrowSkin.SkinUnLockType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WhenOpenFunc", xc.DBGrowSkin.SkinUnLockType.WhenOpenFunc);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GrowLevel", xc.DBGrowSkin.SkinUnLockType.GrowLevel);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CostGoods", xc.DBGrowSkin.SkinUnLockType.CostGoods);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGrowSkin.SkinUnLockType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBGrowSkin.SkinUnLockType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBGrowSkinSkinUnLockType(L, (xc.DBGrowSkin.SkinUnLockType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushxcDBGrowSkinSkinUnLockType(L, xc.DBGrowSkin.SkinUnLockType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WhenOpenFunc"))
                {
                    translator.PushxcDBGrowSkinSkinUnLockType(L, xc.DBGrowSkin.SkinUnLockType.WhenOpenFunc);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GrowLevel"))
                {
                    translator.PushxcDBGrowSkinSkinUnLockType(L, xc.DBGrowSkin.SkinUnLockType.GrowLevel);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CostGoods"))
                {
                    translator.PushxcDBGrowSkinSkinUnLockType(L, xc.DBGrowSkin.SkinUnLockType.CostGoods);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBGrowSkin.SkinUnLockType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBGrowSkin.SkinUnLockType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBAvatarPartBODY_PARTWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBAvatarPart.BODY_PART), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBAvatarPart.BODY_PART), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBAvatarPart.BODY_PART), L, null, 12, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BODY", xc.DBAvatarPart.BODY_PART.BODY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WEAPON", xc.DBAvatarPart.BODY_PART.WEAPON);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WING", xc.DBAvatarPart.BODY_PART.WING);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ELFIN", xc.DBAvatarPart.BODY_PART.ELFIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MAGICAL_PET", xc.DBAvatarPart.BODY_PART.MAGICAL_PET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FOOTPRINT", xc.DBAvatarPart.BODY_PART.FOOTPRINT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BUBBLE", xc.DBAvatarPart.BODY_PART.BUBBLE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PHOTO_FRAME", xc.DBAvatarPart.BODY_PART.PHOTO_FRAME);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LIGHT_WEAPON", xc.DBAvatarPart.BODY_PART.LIGHT_WEAPON);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BACK_ATTACHMENT", xc.DBAvatarPart.BODY_PART.BACK_ATTACHMENT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBAvatarPart.BODY_PART));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBAvatarPart.BODY_PART), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBAvatarPartBODY_PART(L, (xc.DBAvatarPart.BODY_PART)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "BODY"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.BODY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WEAPON"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.WEAPON);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WING"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.WING);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ELFIN"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.ELFIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MAGICAL_PET"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.MAGICAL_PET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FOOTPRINT"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.FOOTPRINT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BUBBLE"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.BUBBLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PHOTO_FRAME"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.PHOTO_FRAME);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LIGHT_WEAPON"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.LIGHT_WEAPON);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BACK_ATTACHMENT"))
                {
                    translator.PushxcDBAvatarPartBODY_PART(L, xc.DBAvatarPart.BODY_PART.BACK_ATTACHMENT);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBAvatarPart.BODY_PART!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBAvatarPart.BODY_PART! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBPetPetUnLockTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBPet.PetUnLockType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBPet.PetUnLockType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBPet.PetUnLockType), L, null, 7, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", xc.DBPet.PetUnLockType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PlayerLevel", xc.DBPet.PetUnLockType.PlayerLevel);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PrePetDegree", xc.DBPet.PetUnLockType.PrePetDegree);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CostGoods", xc.DBPet.PetUnLockType.CostGoods);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EvolutionReplace", xc.DBPet.PetUnLockType.EvolutionReplace);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBPet.PetUnLockType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBPet.PetUnLockType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBPetPetUnLockType(L, (xc.DBPet.PetUnLockType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushxcDBPetPetUnLockType(L, xc.DBPet.PetUnLockType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PlayerLevel"))
                {
                    translator.PushxcDBPetPetUnLockType(L, xc.DBPet.PetUnLockType.PlayerLevel);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PrePetDegree"))
                {
                    translator.PushxcDBPetPetUnLockType(L, xc.DBPet.PetUnLockType.PrePetDegree);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CostGoods"))
                {
                    translator.PushxcDBPetPetUnLockType(L, xc.DBPet.PetUnLockType.CostGoods);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EvolutionReplace"))
                {
                    translator.PushxcDBPetPetUnLockType(L, xc.DBPet.PetUnLockType.EvolutionReplace);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBPet.PetUnLockType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBPet.PetUnLockType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBSysConfigESysBtnFixTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBSysConfig.ESysBtnFixType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBSysConfig.ESysBtnFixType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBSysConfig.ESysBtnFixType), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NOT_FIX", xc.DBSysConfig.ESysBtnFixType.NOT_FIX);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FIX", xc.DBSysConfig.ESysBtnFixType.FIX);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FIX_WHEN_REDPOINT", xc.DBSysConfig.ESysBtnFixType.FIX_WHEN_REDPOINT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBSysConfig.ESysBtnFixType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBSysConfig.ESysBtnFixType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBSysConfigESysBtnFixType(L, (xc.DBSysConfig.ESysBtnFixType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "NOT_FIX"))
                {
                    translator.PushxcDBSysConfigESysBtnFixType(L, xc.DBSysConfig.ESysBtnFixType.NOT_FIX);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FIX"))
                {
                    translator.PushxcDBSysConfigESysBtnFixType(L, xc.DBSysConfig.ESysBtnFixType.FIX);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FIX_WHEN_REDPOINT"))
                {
                    translator.PushxcDBSysConfigESysBtnFixType(L, xc.DBSysConfig.ESysBtnFixType.FIX_WHEN_REDPOINT);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBSysConfig.ESysBtnFixType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBSysConfig.ESysBtnFixType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBSysConfigESysBtnPosWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBSysConfig.ESysBtnPos), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBSysConfig.ESysBtnPos), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBSysConfig.ESysBtnPos), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NONE", xc.DBSysConfig.ESysBtnPos.NONE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SYS_LBBTN_POS", xc.DBSysConfig.ESysBtnPos.SYS_LBBTN_POS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SYS_TRBTN_POS", xc.DBSysConfig.ESysBtnPos.SYS_TRBTN_POS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SYS_RIGHT_POS", xc.DBSysConfig.ESysBtnPos.SYS_RIGHT_POS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBSysConfig.ESysBtnPos));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBSysConfig.ESysBtnPos), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBSysConfigESysBtnPos(L, (xc.DBSysConfig.ESysBtnPos)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "NONE"))
                {
                    translator.PushxcDBSysConfigESysBtnPos(L, xc.DBSysConfig.ESysBtnPos.NONE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SYS_LBBTN_POS"))
                {
                    translator.PushxcDBSysConfigESysBtnPos(L, xc.DBSysConfig.ESysBtnPos.SYS_LBBTN_POS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SYS_TRBTN_POS"))
                {
                    translator.PushxcDBSysConfigESysBtnPos(L, xc.DBSysConfig.ESysBtnPos.SYS_TRBTN_POS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SYS_RIGHT_POS"))
                {
                    translator.PushxcDBSysConfigESysBtnPos(L, xc.DBSysConfig.ESysBtnPos.SYS_RIGHT_POS);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBSysConfig.ESysBtnPos!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBSysConfig.ESysBtnPos! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBSysConfigESysTaskTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBSysConfig.ESysTaskType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBSysConfig.ESysTaskType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBSysConfig.ESysTaskType), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SYS_TASK_TYPE_NONE", xc.DBSysConfig.ESysTaskType.SYS_TASK_TYPE_NONE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SYS_TASK_TYPE_ACCEPT", xc.DBSysConfig.ESysTaskType.SYS_TASK_TYPE_ACCEPT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SYS_TASK_TYPE_FINISH", xc.DBSysConfig.ESysTaskType.SYS_TASK_TYPE_FINISH);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBSysConfig.ESysTaskType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBSysConfig.ESysTaskType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBSysConfigESysTaskType(L, (xc.DBSysConfig.ESysTaskType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "SYS_TASK_TYPE_NONE"))
                {
                    translator.PushxcDBSysConfigESysTaskType(L, xc.DBSysConfig.ESysTaskType.SYS_TASK_TYPE_NONE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SYS_TASK_TYPE_ACCEPT"))
                {
                    translator.PushxcDBSysConfigESysTaskType(L, xc.DBSysConfig.ESysTaskType.SYS_TASK_TYPE_ACCEPT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SYS_TASK_TYPE_FINISH"))
                {
                    translator.PushxcDBSysConfigESysTaskType(L, xc.DBSysConfig.ESysTaskType.SYS_TASK_TYPE_FINISH);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBSysConfig.ESysTaskType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBSysConfig.ESysTaskType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcDBEquipPosEquipPosTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.DBEquipPos.EquipPosType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.DBEquipPos.EquipPosType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.DBEquipPos.EquipPosType), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", xc.DBEquipPos.EquipPosType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Normal", xc.DBEquipPos.EquipPosType.Normal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Wing", xc.DBEquipPos.EquipPosType.Wing);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBEquipPos.EquipPosType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.DBEquipPos.EquipPosType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcDBEquipPosEquipPosType(L, (xc.DBEquipPos.EquipPosType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushxcDBEquipPosEquipPosType(L, xc.DBEquipPos.EquipPosType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Normal"))
                {
                    translator.PushxcDBEquipPosEquipPosType(L, xc.DBEquipPos.EquipPosType.Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Wing"))
                {
                    translator.PushxcDBEquipPosEquipPosType(L, xc.DBEquipPos.EquipPosType.Wing);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.DBEquipPos.EquipPosType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.DBEquipPos.EquipPosType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcBuffBuffFlagsWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.Buff.BuffFlags), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.Buff.BuffFlags), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.Buff.BuffFlags), L, null, 7, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AF_NONE", xc.Buff.BuffFlags.AF_NONE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AF_USE_TO_CASTER", xc.Buff.BuffFlags.AF_USE_TO_CASTER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AF_USE_TO_TARGET", xc.Buff.BuffFlags.AF_USE_TO_TARGET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AF_MUST_CLEAN_AFTER_USE", xc.Buff.BuffFlags.AF_MUST_CLEAN_AFTER_USE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AF_RECOVERY_AFTER_DIE", xc.Buff.BuffFlags.AF_RECOVERY_AFTER_DIE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Buff.BuffFlags));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.Buff.BuffFlags), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcBuffBuffFlags(L, (xc.Buff.BuffFlags)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "AF_NONE"))
                {
                    translator.PushxcBuffBuffFlags(L, xc.Buff.BuffFlags.AF_NONE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AF_USE_TO_CASTER"))
                {
                    translator.PushxcBuffBuffFlags(L, xc.Buff.BuffFlags.AF_USE_TO_CASTER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AF_USE_TO_TARGET"))
                {
                    translator.PushxcBuffBuffFlags(L, xc.Buff.BuffFlags.AF_USE_TO_TARGET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AF_MUST_CLEAN_AFTER_USE"))
                {
                    translator.PushxcBuffBuffFlags(L, xc.Buff.BuffFlags.AF_MUST_CLEAN_AFTER_USE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AF_RECOVERY_AFTER_DIE"))
                {
                    translator.PushxcBuffBuffFlags(L, xc.Buff.BuffFlags.AF_RECOVERY_AFTER_DIE);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.Buff.BuffFlags!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.Buff.BuffFlags! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcRockCommandSystemClickRockButtonTipsTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.RockCommandSystem.ClickRockButtonTipsType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.RockCommandSystem.ClickRockButtonTipsType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.RockCommandSystem.ClickRockButtonTipsType), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", xc.RockCommandSystem.ClickRockButtonTipsType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "IsInCD", xc.RockCommandSystem.ClickRockButtonTipsType.IsInCD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NotEnoughMp", xc.RockCommandSystem.ClickRockButtonTipsType.NotEnoughMp);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.RockCommandSystem.ClickRockButtonTipsType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.RockCommandSystem.ClickRockButtonTipsType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcRockCommandSystemClickRockButtonTipsType(L, (xc.RockCommandSystem.ClickRockButtonTipsType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushxcRockCommandSystemClickRockButtonTipsType(L, xc.RockCommandSystem.ClickRockButtonTipsType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IsInCD"))
                {
                    translator.PushxcRockCommandSystemClickRockButtonTipsType(L, xc.RockCommandSystem.ClickRockButtonTipsType.IsInCD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NotEnoughMp"))
                {
                    translator.PushxcRockCommandSystemClickRockButtonTipsType(L, xc.RockCommandSystem.ClickRockButtonTipsType.NotEnoughMp);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.RockCommandSystem.ClickRockButtonTipsType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.RockCommandSystem.ClickRockButtonTipsType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class ActorEHeadIconWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Actor.EHeadIcon), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Actor.EHeadIcon), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Actor.EHeadIcon), L, null, 13, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NONE", Actor.EHeadIcon.NONE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TITLE", Actor.EHeadIcon.TITLE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ARENA_GRADE", Actor.EHeadIcon.ARENA_GRADE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MINE", Actor.EHeadIcon.MINE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TEAM", Actor.EHeadIcon.TEAM);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PK", Actor.EHeadIcon.PK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PK2", Actor.EHeadIcon.PK2);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BOSS_BG", Actor.EHeadIcon.BOSS_BG);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BOSS", Actor.EHeadIcon.BOSS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PEAK", Actor.EHeadIcon.PEAK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ALL", Actor.EHeadIcon.ALL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Actor.EHeadIcon));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Actor.EHeadIcon), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushActorEHeadIcon(L, (Actor.EHeadIcon)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "NONE"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.NONE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TITLE"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.TITLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ARENA_GRADE"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.ARENA_GRADE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MINE"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.MINE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TEAM"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.TEAM);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PK"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.PK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PK2"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.PK2);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BOSS_BG"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.BOSS_BG);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BOSS"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.BOSS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PEAK"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.PEAK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ALL"))
                {
                    translator.PushActorEHeadIcon(L, Actor.EHeadIcon.ALL);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Actor.EHeadIcon!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Actor.EHeadIcon! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class ActorEVocationTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Actor.EVocationType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Actor.EVocationType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Actor.EVocationType), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EVT_NONE", Actor.EVocationType.EVT_NONE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ROLE1", Actor.EVocationType.ROLE1);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ROLE2", Actor.EVocationType.ROLE2);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ROLE3", Actor.EVocationType.ROLE3);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Actor.EVocationType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Actor.EVocationType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushActorEVocationType(L, (Actor.EVocationType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "EVT_NONE"))
                {
                    translator.PushActorEVocationType(L, Actor.EVocationType.EVT_NONE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ROLE1"))
                {
                    translator.PushActorEVocationType(L, Actor.EVocationType.ROLE1);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ROLE2"))
                {
                    translator.PushActorEVocationType(L, Actor.EVocationType.ROLE2);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ROLE3"))
                {
                    translator.PushActorEVocationType(L, Actor.EVocationType.ROLE3);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Actor.EVocationType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Actor.EVocationType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class ActorActorEventWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Actor.ActorEvent), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Actor.ActorEvent), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Actor.ActorEvent), L, null, 19, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ENTERIDLE", Actor.ActorEvent.ENTERIDLE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EXITIDLE", Actor.ActorEvent.EXITIDLE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BEATTACK", Actor.ActorEvent.BEATTACK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DEAD", Actor.ActorEvent.DEAD);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "REACH_TARGET", Actor.ActorEvent.REACH_TARGET);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHAPE_SHIFT", Actor.ActorEvent.SHAPE_SHIFT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AVATAR_CHANGE_BEGIN", Actor.ActorEvent.AVATAR_CHANGE_BEGIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AVATAR_CHANGE", Actor.ActorEvent.AVATAR_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AFTER_CREATE", Actor.ActorEvent.AFTER_CREATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MODEL_CHANGE", Actor.ActorEvent.MODEL_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SHADOW_CHANGE", Actor.ActorEvent.SHADOW_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BATTLE_STATE_CHANGE", Actor.ActorEvent.BATTLE_STATE_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "RES_LOADED_CHANGE", Actor.ActorEvent.RES_LOADED_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "HP_CHANGE", Actor.ActorEvent.HP_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MP_CHANGE", Actor.ActorEvent.MP_CHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BEFORE_ACTOR_DESTROY", Actor.ActorEvent.BEFORE_ACTOR_DESTROY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EXIT_JUMPSCENE_STATE", Actor.ActorEvent.EXIT_JUMPSCENE_STATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Actor.ActorEvent));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Actor.ActorEvent), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushActorActorEvent(L, (Actor.ActorEvent)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "ENTERIDLE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.ENTERIDLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EXITIDLE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.EXITIDLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BEATTACK"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.BEATTACK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DEAD"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.DEAD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "REACH_TARGET"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.REACH_TARGET);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHAPE_SHIFT"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.SHAPE_SHIFT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AVATAR_CHANGE_BEGIN"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.AVATAR_CHANGE_BEGIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AVATAR_CHANGE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.AVATAR_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AFTER_CREATE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.AFTER_CREATE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MODEL_CHANGE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.MODEL_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SHADOW_CHANGE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.SHADOW_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BATTLE_STATE_CHANGE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.BATTLE_STATE_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RES_LOADED_CHANGE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.RES_LOADED_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HP_CHANGE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.HP_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MP_CHANGE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.MP_CHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BEFORE_ACTOR_DESTROY"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.BEFORE_ACTOR_DESTROY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EXIT_JUMPSCENE_STATE"))
                {
                    translator.PushActorActorEvent(L, Actor.ActorEvent.EXIT_JUMPSCENE_STATE);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Actor.ActorEvent!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Actor.ActorEvent! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class ActorEAnimationWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Actor.EAnimation), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Actor.EAnimation), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Actor.EAnimation), L, null, 14, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "idle", Actor.EAnimation.idle);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "idle_fight", Actor.EAnimation.idle_fight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "walk", Actor.EAnimation.walk);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "walk_fight", Actor.EAnimation.walk_fight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "beAtk_Backward", Actor.EAnimation.beAtk_Backward);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "floating", Actor.EAnimation.floating);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "falling", Actor.EAnimation.falling);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "falldown", Actor.EAnimation.falldown);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "death", Actor.EAnimation.death);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "rideidle", Actor.EAnimation.rideidle);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "riderun", Actor.EAnimation.riderun);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "count", Actor.EAnimation.count);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Actor.EAnimation));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Actor.EAnimation), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushActorEAnimation(L, (Actor.EAnimation)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "idle"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.idle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "idle_fight"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.idle_fight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "walk"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.walk);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "walk_fight"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.walk_fight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "beAtk_Backward"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.beAtk_Backward);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "floating"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.floating);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "falling"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.falling);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "falldown"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.falldown);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "death"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.death);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "rideidle"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.rideidle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "riderun"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.riderun);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "count"))
                {
                    translator.PushActorEAnimation(L, Actor.EAnimation.count);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Actor.EAnimation!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Actor.EAnimation! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class ActorSlotBoneNameTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Actor.SlotBoneNameType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Actor.SlotBoneNameType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Actor.SlotBoneNameType), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", Actor.SlotBoneNameType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Spine", Actor.SlotBoneNameType.Spine);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Head", Actor.SlotBoneNameType.Head);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Root", Actor.SlotBoneNameType.Root);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Actor.SlotBoneNameType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Actor.SlotBoneNameType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushActorSlotBoneNameType(L, (Actor.SlotBoneNameType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushActorSlotBoneNameType(L, Actor.SlotBoneNameType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Spine"))
                {
                    translator.PushActorSlotBoneNameType(L, Actor.SlotBoneNameType.Spine);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Head"))
                {
                    translator.PushActorSlotBoneNameType(L, Actor.SlotBoneNameType.Head);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Root"))
                {
                    translator.PushActorSlotBoneNameType(L, Actor.SlotBoneNameType.Root);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Actor.SlotBoneNameType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Actor.SlotBoneNameType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class ActorEWildStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Actor.EWildState), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Actor.EWildState), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Actor.EWildState), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Peace", Actor.EWildState.Peace);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Kill", Actor.EWildState.Kill);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Society", Actor.EWildState.Society);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Actor.EWildState));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Actor.EWildState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushActorEWildState(L, (Actor.EWildState)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Peace"))
                {
                    translator.PushActorEWildState(L, Actor.EWildState.Peace);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Kill"))
                {
                    translator.PushActorEWildState(L, Actor.EWildState.Kill);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Society"))
                {
                    translator.PushActorEWildState(L, Actor.EWildState.Society);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Actor.EWildState!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Actor.EWildState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MonsterMonsterSpawnTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Monster.MonsterSpawnType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Monster.MonsterSpawnType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Monster.MonsterSpawnType), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ST_Normal", Monster.MonsterSpawnType.ST_Normal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ST_Random", Monster.MonsterSpawnType.ST_Random);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Monster.MonsterSpawnType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Monster.MonsterSpawnType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMonsterMonsterSpawnType(L, (Monster.MonsterSpawnType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "ST_Normal"))
                {
                    translator.PushMonsterMonsterSpawnType(L, Monster.MonsterSpawnType.ST_Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ST_Random"))
                {
                    translator.PushMonsterMonsterSpawnType(L, Monster.MonsterSpawnType.ST_Random);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Monster.MonsterSpawnType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Monster.MonsterSpawnType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MonsterMonsterTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Monster.MonsterType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Monster.MonsterType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Monster.MonsterType), L, null, 7, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", Monster.MonsterType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LocalMonster", Monster.MonsterType.LocalMonster);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "RemoterMonster", Monster.MonsterType.RemoterMonster);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SummonLocalMonster", Monster.MonsterType.SummonLocalMonster);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SummonRemoteMonster", Monster.MonsterType.SummonRemoteMonster);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Monster.MonsterType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Monster.MonsterType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMonsterMonsterType(L, (Monster.MonsterType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushMonsterMonsterType(L, Monster.MonsterType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LocalMonster"))
                {
                    translator.PushMonsterMonsterType(L, Monster.MonsterType.LocalMonster);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RemoterMonster"))
                {
                    translator.PushMonsterMonsterType(L, Monster.MonsterType.RemoterMonster);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SummonLocalMonster"))
                {
                    translator.PushMonsterMonsterType(L, Monster.MonsterType.SummonLocalMonster);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SummonRemoteMonster"))
                {
                    translator.PushMonsterMonsterType(L, Monster.MonsterType.SummonRemoteMonster);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Monster.MonsterType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Monster.MonsterType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MonsterBeSummonTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Monster.BeSummonType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Monster.BeSummonType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Monster.BeSummonType), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NULL", Monster.BeSummonType.NULL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BE_SUMMON_BY_MONSTER", Monster.BeSummonType.BE_SUMMON_BY_MONSTER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BE_SUMMON_BY_PLAYER", Monster.BeSummonType.BE_SUMMON_BY_PLAYER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BE_SUMMON_BY_ROBOT", Monster.BeSummonType.BE_SUMMON_BY_ROBOT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Monster.BeSummonType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Monster.BeSummonType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMonsterBeSummonType(L, (Monster.BeSummonType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "NULL"))
                {
                    translator.PushMonsterBeSummonType(L, Monster.BeSummonType.NULL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BE_SUMMON_BY_MONSTER"))
                {
                    translator.PushMonsterBeSummonType(L, Monster.BeSummonType.BE_SUMMON_BY_MONSTER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BE_SUMMON_BY_PLAYER"))
                {
                    translator.PushMonsterBeSummonType(L, Monster.BeSummonType.BE_SUMMON_BY_PLAYER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BE_SUMMON_BY_ROBOT"))
                {
                    translator.PushMonsterBeSummonType(L, Monster.BeSummonType.BE_SUMMON_BY_ROBOT);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Monster.BeSummonType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Monster.BeSummonType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MonsterQualityColorWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(Monster.QualityColor), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(Monster.QualityColor), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(Monster.QualityColor), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "COMMON", Monster.QualityColor.COMMON);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ELITE", Monster.QualityColor.ELITE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BOSS", Monster.QualityColor.BOSS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Monster.QualityColor));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(Monster.QualityColor), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMonsterQualityColor(L, (Monster.QualityColor)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "COMMON"))
                {
                    translator.PushMonsterQualityColor(L, Monster.QualityColor.COMMON);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ELITE"))
                {
                    translator.PushMonsterQualityColor(L, Monster.QualityColor.ELITE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BOSS"))
                {
                    translator.PushMonsterQualityColor(L, Monster.QualityColor.BOSS);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Monster.QualityColor!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Monster.QualityColor! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcMoveCtrlEActorStepTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.MoveCtrl.EActorStepType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.MoveCtrl.EActorStepType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.MoveCtrl.EActorStepType), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AT_WALK_BEGIN", xc.MoveCtrl.EActorStepType.AT_WALK_BEGIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AT_WALK_END", xc.MoveCtrl.EActorStepType.AT_WALK_END);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MoveCtrl.EActorStepType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.MoveCtrl.EActorStepType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcMoveCtrlEActorStepType(L, (xc.MoveCtrl.EActorStepType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "AT_WALK_BEGIN"))
                {
                    translator.PushxcMoveCtrlEActorStepType(L, xc.MoveCtrl.EActorStepType.AT_WALK_BEGIN);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AT_WALK_END"))
                {
                    translator.PushxcMoveCtrlEActorStepType(L, xc.MoveCtrl.EActorStepType.AT_WALK_END);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.MoveCtrl.EActorStepType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.MoveCtrl.EActorStepType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcActorMachineEWalkModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ActorMachine.EWalkMode), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ActorMachine.EWalkMode), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ActorMachine.EWalkMode), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EWM_Uninit", xc.ActorMachine.EWalkMode.EWM_Uninit);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EWM_Dst", xc.ActorMachine.EWalkMode.EWM_Dst);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EWM_Dir", xc.ActorMachine.EWalkMode.EWM_Dir);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ActorMachine.EWalkMode));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ActorMachine.EWalkMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcActorMachineEWalkMode(L, (xc.ActorMachine.EWalkMode)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "EWM_Uninit"))
                {
                    translator.PushxcActorMachineEWalkMode(L, xc.ActorMachine.EWalkMode.EWM_Uninit);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EWM_Dst"))
                {
                    translator.PushxcActorMachineEWalkMode(L, xc.ActorMachine.EWalkMode.EWM_Dst);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EWM_Dir"))
                {
                    translator.PushxcActorMachineEWalkMode(L, xc.ActorMachine.EWalkMode.EWM_Dir);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ActorMachine.EWalkMode!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ActorMachine.EWalkMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcActorMachineEFSMEventWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ActorMachine.EFSMEvent), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ActorMachine.EFSMEvent), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ActorMachine.EFSMEvent), L, null, 14, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_Walk", xc.ActorMachine.EFSMEvent.DE_Walk);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_ResetWalk", xc.ActorMachine.EFSMEvent.DE_ResetWalk);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_ReachDst", xc.ActorMachine.EFSMEvent.DE_ReachDst);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_Stop", xc.ActorMachine.EFSMEvent.DE_Stop);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_BeAtkNormal", xc.ActorMachine.EFSMEvent.DS_BeAtkNormal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_BeAtkBackward", xc.ActorMachine.EFSMEvent.DE_BeAtkBackward);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_Death", xc.ActorMachine.EFSMEvent.DE_Death);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_Relive", xc.ActorMachine.EFSMEvent.DE_Relive);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_NormalAttack", xc.ActorMachine.EFSMEvent.DE_NormalAttack);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_Interaction", xc.ActorMachine.EFSMEvent.DE_Interaction);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_JumpScene", xc.ActorMachine.EFSMEvent.DE_JumpScene);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DE_JumpSceneFinish", xc.ActorMachine.EFSMEvent.DE_JumpSceneFinish);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ActorMachine.EFSMEvent));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ActorMachine.EFSMEvent), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcActorMachineEFSMEvent(L, (xc.ActorMachine.EFSMEvent)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "DE_Walk"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_Walk);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_ResetWalk"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_ResetWalk);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_ReachDst"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_ReachDst);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_Stop"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_Stop);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_BeAtkNormal"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DS_BeAtkNormal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_BeAtkBackward"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_BeAtkBackward);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_Death"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_Death);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_Relive"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_Relive);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_NormalAttack"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_NormalAttack);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_Interaction"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_Interaction);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_JumpScene"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_JumpScene);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DE_JumpSceneFinish"))
                {
                    translator.PushxcActorMachineEFSMEvent(L, xc.ActorMachine.EFSMEvent.DE_JumpSceneFinish);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ActorMachine.EFSMEvent!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ActorMachine.EFSMEvent! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcActorMachineEFSMStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ActorMachine.EFSMState), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ActorMachine.EFSMState), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ActorMachine.EFSMState), L, null, 13, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_NULL", xc.ActorMachine.EFSMState.DS_NULL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_Normal", xc.ActorMachine.EFSMState.DS_Normal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_Attacking", xc.ActorMachine.EFSMState.DS_Attacking);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_BeAttacking", xc.ActorMachine.EFSMState.DS_BeAttacking);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_Death", xc.ActorMachine.EFSMState.DS_Death);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_Idle", xc.ActorMachine.EFSMState.DS_Idle);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_Walking", xc.ActorMachine.EFSMState.DS_Walking);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_Interaction", xc.ActorMachine.EFSMState.DS_Interaction);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_JumpScene", xc.ActorMachine.EFSMState.DS_JumpScene);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_BeAtkBackward", xc.ActorMachine.EFSMState.DS_BeAtkBackward);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DS_NormalAttack", xc.ActorMachine.EFSMState.DS_NormalAttack);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ActorMachine.EFSMState));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ActorMachine.EFSMState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcActorMachineEFSMState(L, (xc.ActorMachine.EFSMState)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "DS_NULL"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_NULL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_Normal"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_Attacking"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_Attacking);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_BeAttacking"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_BeAttacking);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_Death"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_Death);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_Idle"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_Idle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_Walking"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_Walking);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_Interaction"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_Interaction);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_JumpScene"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_JumpScene);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_BeAtkBackward"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_BeAtkBackward);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DS_NormalAttack"))
                {
                    translator.PushxcActorMachineEFSMState(L, xc.ActorMachine.EFSMState.DS_NormalAttack);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ActorMachine.EFSMState!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ActorMachine.EFSMState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcNpcDefineEFunctionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.NpcDefine.EFunction), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.NpcDefine.EFunction), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.NpcDefine.EFunction), L, null, 9, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EMPTY", xc.NpcDefine.EFunction.EMPTY);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRANSFER", xc.NpcDefine.EFunction.TRANSFER);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EXCHANGE", xc.NpcDefine.EFunction.EXCHANGE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DIALOG", xc.NpcDefine.EFunction.DIALOG);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EVENT", xc.NpcDefine.EFunction.EVENT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "INTERACTION", xc.NpcDefine.EFunction.INTERACTION);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ESCORT", xc.NpcDefine.EFunction.ESCORT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.NpcDefine.EFunction));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.NpcDefine.EFunction), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcNpcDefineEFunction(L, (xc.NpcDefine.EFunction)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "EMPTY"))
                {
                    translator.PushxcNpcDefineEFunction(L, xc.NpcDefine.EFunction.EMPTY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRANSFER"))
                {
                    translator.PushxcNpcDefineEFunction(L, xc.NpcDefine.EFunction.TRANSFER);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EXCHANGE"))
                {
                    translator.PushxcNpcDefineEFunction(L, xc.NpcDefine.EFunction.EXCHANGE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DIALOG"))
                {
                    translator.PushxcNpcDefineEFunction(L, xc.NpcDefine.EFunction.DIALOG);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EVENT"))
                {
                    translator.PushxcNpcDefineEFunction(L, xc.NpcDefine.EFunction.EVENT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "INTERACTION"))
                {
                    translator.PushxcNpcDefineEFunction(L, xc.NpcDefine.EFunction.INTERACTION);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ESCORT"))
                {
                    translator.PushxcNpcDefineEFunction(L, xc.NpcDefine.EFunction.ESCORT);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.NpcDefine.EFunction!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.NpcDefine.EFunction! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcNpcDefineELightModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.NpcDefine.ELightMode), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.NpcDefine.ELightMode), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.NpcDefine.ELightMode), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ROLE", xc.NpcDefine.ELightMode.ROLE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SCENE", xc.NpcDefine.ELightMode.SCENE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.NpcDefine.ELightMode));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.NpcDefine.ELightMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcNpcDefineELightMode(L, (xc.NpcDefine.ELightMode)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "ROLE"))
                {
                    translator.PushxcNpcDefineELightMode(L, xc.NpcDefine.ELightMode.ROLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SCENE"))
                {
                    translator.PushxcNpcDefineELightMode(L, xc.NpcDefine.ELightMode.SCENE);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.NpcDefine.ELightMode!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.NpcDefine.ELightMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIToggleToggleTransitionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Toggle.ToggleTransition), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Toggle.ToggleTransition), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.Toggle.ToggleTransition), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", UnityEngine.UI.Toggle.ToggleTransition.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Fade", UnityEngine.UI.Toggle.ToggleTransition.Fade);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Toggle.ToggleTransition));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.Toggle.ToggleTransition), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIToggleToggleTransition(L, (UnityEngine.UI.Toggle.ToggleTransition)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineUIToggleToggleTransition(L, UnityEngine.UI.Toggle.ToggleTransition.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Fade"))
                {
                    translator.PushUnityEngineUIToggleToggleTransition(L, UnityEngine.UI.Toggle.ToggleTransition.Fade);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Toggle.ToggleTransition!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Toggle.ToggleTransition! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUISliderDirectionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Slider.Direction), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Slider.Direction), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.Slider.Direction), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LeftToRight", UnityEngine.UI.Slider.Direction.LeftToRight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "RightToLeft", UnityEngine.UI.Slider.Direction.RightToLeft);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BottomToTop", UnityEngine.UI.Slider.Direction.BottomToTop);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TopToBottom", UnityEngine.UI.Slider.Direction.TopToBottom);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Slider.Direction));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.Slider.Direction), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUISliderDirection(L, (UnityEngine.UI.Slider.Direction)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "LeftToRight"))
                {
                    translator.PushUnityEngineUISliderDirection(L, UnityEngine.UI.Slider.Direction.LeftToRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RightToLeft"))
                {
                    translator.PushUnityEngineUISliderDirection(L, UnityEngine.UI.Slider.Direction.RightToLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BottomToTop"))
                {
                    translator.PushUnityEngineUISliderDirection(L, UnityEngine.UI.Slider.Direction.BottomToTop);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopToBottom"))
                {
                    translator.PushUnityEngineUISliderDirection(L, UnityEngine.UI.Slider.Direction.TopToBottom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Slider.Direction!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Slider.Direction! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOrigin360Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Image.Origin360), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Image.Origin360), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.Image.Origin360), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Bottom", UnityEngine.UI.Image.Origin360.Bottom);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Right", UnityEngine.UI.Image.Origin360.Right);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Top", UnityEngine.UI.Image.Origin360.Top);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Left", UnityEngine.UI.Image.Origin360.Left);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Image.Origin360));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.Image.Origin360), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOrigin360(L, (UnityEngine.UI.Image.Origin360)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushUnityEngineUIImageOrigin360(L, UnityEngine.UI.Image.Origin360.Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineUIImageOrigin360(L, UnityEngine.UI.Image.Origin360.Right);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushUnityEngineUIImageOrigin360(L, UnityEngine.UI.Image.Origin360.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineUIImageOrigin360(L, UnityEngine.UI.Image.Origin360.Left);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.Origin360!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.Origin360! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOrigin180Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Image.Origin180), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Image.Origin180), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.Image.Origin180), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Bottom", UnityEngine.UI.Image.Origin180.Bottom);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Left", UnityEngine.UI.Image.Origin180.Left);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Top", UnityEngine.UI.Image.Origin180.Top);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Right", UnityEngine.UI.Image.Origin180.Right);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Image.Origin180));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.Image.Origin180), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOrigin180(L, (UnityEngine.UI.Image.Origin180)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushUnityEngineUIImageOrigin180(L, UnityEngine.UI.Image.Origin180.Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineUIImageOrigin180(L, UnityEngine.UI.Image.Origin180.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushUnityEngineUIImageOrigin180(L, UnityEngine.UI.Image.Origin180.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineUIImageOrigin180(L, UnityEngine.UI.Image.Origin180.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.Origin180!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.Origin180! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOrigin90Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Image.Origin90), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Image.Origin90), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.Image.Origin90), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BottomLeft", UnityEngine.UI.Image.Origin90.BottomLeft);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TopLeft", UnityEngine.UI.Image.Origin90.TopLeft);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TopRight", UnityEngine.UI.Image.Origin90.TopRight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BottomRight", UnityEngine.UI.Image.Origin90.BottomRight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Image.Origin90));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.Image.Origin90), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOrigin90(L, (UnityEngine.UI.Image.Origin90)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "BottomLeft"))
                {
                    translator.PushUnityEngineUIImageOrigin90(L, UnityEngine.UI.Image.Origin90.BottomLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopLeft"))
                {
                    translator.PushUnityEngineUIImageOrigin90(L, UnityEngine.UI.Image.Origin90.TopLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopRight"))
                {
                    translator.PushUnityEngineUIImageOrigin90(L, UnityEngine.UI.Image.Origin90.TopRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BottomRight"))
                {
                    translator.PushUnityEngineUIImageOrigin90(L, UnityEngine.UI.Image.Origin90.BottomRight);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.Origin90!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.Origin90! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOriginVerticalWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Image.OriginVertical), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Image.OriginVertical), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.Image.OriginVertical), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Bottom", UnityEngine.UI.Image.OriginVertical.Bottom);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Top", UnityEngine.UI.Image.OriginVertical.Top);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Image.OriginVertical));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.Image.OriginVertical), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOriginVertical(L, (UnityEngine.UI.Image.OriginVertical)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushUnityEngineUIImageOriginVertical(L, UnityEngine.UI.Image.OriginVertical.Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushUnityEngineUIImageOriginVertical(L, UnityEngine.UI.Image.OriginVertical.Top);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.OriginVertical!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.OriginVertical! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOriginHorizontalWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Image.OriginHorizontal), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Image.OriginHorizontal), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.Image.OriginHorizontal), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Left", UnityEngine.UI.Image.OriginHorizontal.Left);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Right", UnityEngine.UI.Image.OriginHorizontal.Right);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Image.OriginHorizontal));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.Image.OriginHorizontal), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOriginHorizontal(L, (UnityEngine.UI.Image.OriginHorizontal)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineUIImageOriginHorizontal(L, UnityEngine.UI.Image.OriginHorizontal.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineUIImageOriginHorizontal(L, UnityEngine.UI.Image.OriginHorizontal.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.OriginHorizontal!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.OriginHorizontal! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageFillMethodWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Image.FillMethod), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Image.FillMethod), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.Image.FillMethod), L, null, 7, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Horizontal", UnityEngine.UI.Image.FillMethod.Horizontal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Vertical", UnityEngine.UI.Image.FillMethod.Vertical);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Radial90", UnityEngine.UI.Image.FillMethod.Radial90);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Radial180", UnityEngine.UI.Image.FillMethod.Radial180);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Radial360", UnityEngine.UI.Image.FillMethod.Radial360);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Image.FillMethod));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.Image.FillMethod), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageFillMethod(L, (UnityEngine.UI.Image.FillMethod)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Vertical);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radial90"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Radial90);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radial180"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Radial180);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radial360"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Radial360);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.FillMethod!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.FillMethod! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Image.Type), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Image.Type), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.Image.Type), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Simple", UnityEngine.UI.Image.Type.Simple);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Sliced", UnityEngine.UI.Image.Type.Sliced);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Tiled", UnityEngine.UI.Image.Type.Tiled);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Filled", UnityEngine.UI.Image.Type.Filled);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Image.Type));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.Image.Type), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageType(L, (UnityEngine.UI.Image.Type)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Simple"))
                {
                    translator.PushUnityEngineUIImageType(L, UnityEngine.UI.Image.Type.Simple);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Sliced"))
                {
                    translator.PushUnityEngineUIImageType(L, UnityEngine.UI.Image.Type.Sliced);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Tiled"))
                {
                    translator.PushUnityEngineUIImageType(L, UnityEngine.UI.Image.Type.Tiled);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Filled"))
                {
                    translator.PushUnityEngineUIImageType(L, UnityEngine.UI.Image.Type.Filled);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.Type!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.Type! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineTextAnchorWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.TextAnchor), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.TextAnchor), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.TextAnchor), L, null, 11, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UpperLeft", UnityEngine.TextAnchor.UpperLeft);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UpperCenter", UnityEngine.TextAnchor.UpperCenter);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UpperRight", UnityEngine.TextAnchor.UpperRight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MiddleLeft", UnityEngine.TextAnchor.MiddleLeft);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MiddleCenter", UnityEngine.TextAnchor.MiddleCenter);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MiddleRight", UnityEngine.TextAnchor.MiddleRight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LowerLeft", UnityEngine.TextAnchor.LowerLeft);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LowerCenter", UnityEngine.TextAnchor.LowerCenter);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LowerRight", UnityEngine.TextAnchor.LowerRight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.TextAnchor));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.TextAnchor), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineTextAnchor(L, (UnityEngine.TextAnchor)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "UpperLeft"))
                {
                    translator.PushUnityEngineTextAnchor(L, UnityEngine.TextAnchor.UpperLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UpperCenter"))
                {
                    translator.PushUnityEngineTextAnchor(L, UnityEngine.TextAnchor.UpperCenter);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UpperRight"))
                {
                    translator.PushUnityEngineTextAnchor(L, UnityEngine.TextAnchor.UpperRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MiddleLeft"))
                {
                    translator.PushUnityEngineTextAnchor(L, UnityEngine.TextAnchor.MiddleLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MiddleCenter"))
                {
                    translator.PushUnityEngineTextAnchor(L, UnityEngine.TextAnchor.MiddleCenter);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MiddleRight"))
                {
                    translator.PushUnityEngineTextAnchor(L, UnityEngine.TextAnchor.MiddleRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LowerLeft"))
                {
                    translator.PushUnityEngineTextAnchor(L, UnityEngine.TextAnchor.LowerLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LowerCenter"))
                {
                    translator.PushUnityEngineTextAnchor(L, UnityEngine.TextAnchor.LowerCenter);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LowerRight"))
                {
                    translator.PushUnityEngineTextAnchor(L, UnityEngine.TextAnchor.LowerRight);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.TextAnchor!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.TextAnchor! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIInputFieldLineTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.InputField.LineType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.InputField.LineType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.InputField.LineType), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SingleLine", UnityEngine.UI.InputField.LineType.SingleLine);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MultiLineSubmit", UnityEngine.UI.InputField.LineType.MultiLineSubmit);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MultiLineNewline", UnityEngine.UI.InputField.LineType.MultiLineNewline);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.InputField.LineType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.InputField.LineType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIInputFieldLineType(L, (UnityEngine.UI.InputField.LineType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "SingleLine"))
                {
                    translator.PushUnityEngineUIInputFieldLineType(L, UnityEngine.UI.InputField.LineType.SingleLine);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MultiLineSubmit"))
                {
                    translator.PushUnityEngineUIInputFieldLineType(L, UnityEngine.UI.InputField.LineType.MultiLineSubmit);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MultiLineNewline"))
                {
                    translator.PushUnityEngineUIInputFieldLineType(L, UnityEngine.UI.InputField.LineType.MultiLineNewline);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.InputField.LineType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.InputField.LineType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIInputFieldCharacterValidationWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.InputField.CharacterValidation), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.InputField.CharacterValidation), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.InputField.CharacterValidation), L, null, 8, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", UnityEngine.UI.InputField.CharacterValidation.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Integer", UnityEngine.UI.InputField.CharacterValidation.Integer);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Decimal", UnityEngine.UI.InputField.CharacterValidation.Decimal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Alphanumeric", UnityEngine.UI.InputField.CharacterValidation.Alphanumeric);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Name", UnityEngine.UI.InputField.CharacterValidation.Name);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EmailAddress", UnityEngine.UI.InputField.CharacterValidation.EmailAddress);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.InputField.CharacterValidation));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.InputField.CharacterValidation), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIInputFieldCharacterValidation(L, (UnityEngine.UI.InputField.CharacterValidation)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Integer"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.Integer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Decimal"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.Decimal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Alphanumeric"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.Alphanumeric);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Name"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.Name);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EmailAddress"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.EmailAddress);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.InputField.CharacterValidation!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.InputField.CharacterValidation! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIInputFieldInputTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.InputField.InputType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.InputField.InputType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.InputField.InputType), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Standard", UnityEngine.UI.InputField.InputType.Standard);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AutoCorrect", UnityEngine.UI.InputField.InputType.AutoCorrect);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Password", UnityEngine.UI.InputField.InputType.Password);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.InputField.InputType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.InputField.InputType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIInputFieldInputType(L, (UnityEngine.UI.InputField.InputType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Standard"))
                {
                    translator.PushUnityEngineUIInputFieldInputType(L, UnityEngine.UI.InputField.InputType.Standard);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoCorrect"))
                {
                    translator.PushUnityEngineUIInputFieldInputType(L, UnityEngine.UI.InputField.InputType.AutoCorrect);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Password"))
                {
                    translator.PushUnityEngineUIInputFieldInputType(L, UnityEngine.UI.InputField.InputType.Password);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.InputField.InputType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.InputField.InputType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIInputFieldContentTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.InputField.ContentType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.InputField.ContentType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.InputField.ContentType), L, null, 12, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Standard", UnityEngine.UI.InputField.ContentType.Standard);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Autocorrected", UnityEngine.UI.InputField.ContentType.Autocorrected);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "IntegerNumber", UnityEngine.UI.InputField.ContentType.IntegerNumber);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DecimalNumber", UnityEngine.UI.InputField.ContentType.DecimalNumber);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Alphanumeric", UnityEngine.UI.InputField.ContentType.Alphanumeric);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Name", UnityEngine.UI.InputField.ContentType.Name);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EmailAddress", UnityEngine.UI.InputField.ContentType.EmailAddress);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Password", UnityEngine.UI.InputField.ContentType.Password);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Pin", UnityEngine.UI.InputField.ContentType.Pin);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Custom", UnityEngine.UI.InputField.ContentType.Custom);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.InputField.ContentType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.InputField.ContentType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIInputFieldContentType(L, (UnityEngine.UI.InputField.ContentType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Standard"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Standard);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Autocorrected"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Autocorrected);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IntegerNumber"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.IntegerNumber);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DecimalNumber"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.DecimalNumber);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Alphanumeric"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Alphanumeric);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Name"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Name);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EmailAddress"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.EmailAddress);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Password"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Password);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Pin"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Pin);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Custom"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Custom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.InputField.ContentType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.InputField.ContentType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIScrollRectScrollbarVisibilityWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Permanent", UnityEngine.UI.ScrollRect.ScrollbarVisibility.Permanent);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AutoHide", UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHide);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AutoHideAndExpandViewport", UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIScrollRectScrollbarVisibility(L, (UnityEngine.UI.ScrollRect.ScrollbarVisibility)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Permanent"))
                {
                    translator.PushUnityEngineUIScrollRectScrollbarVisibility(L, UnityEngine.UI.ScrollRect.ScrollbarVisibility.Permanent);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoHide"))
                {
                    translator.PushUnityEngineUIScrollRectScrollbarVisibility(L, UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHide);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoHideAndExpandViewport"))
                {
                    translator.PushUnityEngineUIScrollRectScrollbarVisibility(L, UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.ScrollRect.ScrollbarVisibility!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.ScrollRect.ScrollbarVisibility! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIScrollRectMovementTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.ScrollRect.MovementType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.ScrollRect.MovementType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.ScrollRect.MovementType), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Unrestricted", UnityEngine.UI.ScrollRect.MovementType.Unrestricted);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Elastic", UnityEngine.UI.ScrollRect.MovementType.Elastic);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Clamped", UnityEngine.UI.ScrollRect.MovementType.Clamped);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.ScrollRect.MovementType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.ScrollRect.MovementType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIScrollRectMovementType(L, (UnityEngine.UI.ScrollRect.MovementType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Unrestricted"))
                {
                    translator.PushUnityEngineUIScrollRectMovementType(L, UnityEngine.UI.ScrollRect.MovementType.Unrestricted);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Elastic"))
                {
                    translator.PushUnityEngineUIScrollRectMovementType(L, UnityEngine.UI.ScrollRect.MovementType.Elastic);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Clamped"))
                {
                    translator.PushUnityEngineUIScrollRectMovementType(L, UnityEngine.UI.ScrollRect.MovementType.Clamped);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.ScrollRect.MovementType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.ScrollRect.MovementType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIGridLayoutGroupConstraintWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Constraint), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Constraint), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Constraint), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Flexible", UnityEngine.UI.GridLayoutGroup.Constraint.Flexible);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FixedColumnCount", UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FixedRowCount", UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.GridLayoutGroup.Constraint));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Constraint), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIGridLayoutGroupConstraint(L, (UnityEngine.UI.GridLayoutGroup.Constraint)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Flexible"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupConstraint(L, UnityEngine.UI.GridLayoutGroup.Constraint.Flexible);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FixedColumnCount"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupConstraint(L, UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FixedRowCount"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupConstraint(L, UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.GridLayoutGroup.Constraint!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.GridLayoutGroup.Constraint! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIGridLayoutGroupAxisWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Axis), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Axis), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Axis), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Horizontal", UnityEngine.UI.GridLayoutGroup.Axis.Horizontal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Vertical", UnityEngine.UI.GridLayoutGroup.Axis.Vertical);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.GridLayoutGroup.Axis));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Axis), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIGridLayoutGroupAxis(L, (UnityEngine.UI.GridLayoutGroup.Axis)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupAxis(L, UnityEngine.UI.GridLayoutGroup.Axis.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupAxis(L, UnityEngine.UI.GridLayoutGroup.Axis.Vertical);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.GridLayoutGroup.Axis!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.GridLayoutGroup.Axis! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIGridLayoutGroupCornerWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Corner), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Corner), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Corner), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UpperLeft", UnityEngine.UI.GridLayoutGroup.Corner.UpperLeft);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UpperRight", UnityEngine.UI.GridLayoutGroup.Corner.UpperRight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LowerLeft", UnityEngine.UI.GridLayoutGroup.Corner.LowerLeft);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LowerRight", UnityEngine.UI.GridLayoutGroup.Corner.LowerRight);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.GridLayoutGroup.Corner));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Corner), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIGridLayoutGroupCorner(L, (UnityEngine.UI.GridLayoutGroup.Corner)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "UpperLeft"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupCorner(L, UnityEngine.UI.GridLayoutGroup.Corner.UpperLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UpperRight"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupCorner(L, UnityEngine.UI.GridLayoutGroup.Corner.UpperRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LowerLeft"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupCorner(L, UnityEngine.UI.GridLayoutGroup.Corner.LowerLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LowerRight"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupCorner(L, UnityEngine.UI.GridLayoutGroup.Corner.LowerRight);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.GridLayoutGroup.Corner!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.GridLayoutGroup.Corner! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIContentSizeFitterFitModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.UI.ContentSizeFitter.FitMode), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.ContentSizeFitter.FitMode), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.UI.ContentSizeFitter.FitMode), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Unconstrained", UnityEngine.UI.ContentSizeFitter.FitMode.Unconstrained);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MinSize", UnityEngine.UI.ContentSizeFitter.FitMode.MinSize);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PreferredSize", UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.ContentSizeFitter.FitMode));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.UI.ContentSizeFitter.FitMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIContentSizeFitterFitMode(L, (UnityEngine.UI.ContentSizeFitter.FitMode)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Unconstrained"))
                {
                    translator.PushUnityEngineUIContentSizeFitterFitMode(L, UnityEngine.UI.ContentSizeFitter.FitMode.Unconstrained);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MinSize"))
                {
                    translator.PushUnityEngineUIContentSizeFitterFitMode(L, UnityEngine.UI.ContentSizeFitter.FitMode.MinSize);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PreferredSize"))
                {
                    translator.PushUnityEngineUIContentSizeFitterFitMode(L, UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.ContentSizeFitter.FitMode!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.ContentSizeFitter.FitMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineEventSystemsEventTriggerTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(UnityEngine.EventSystems.EventTriggerType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(UnityEngine.EventSystems.EventTriggerType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(UnityEngine.EventSystems.EventTriggerType), L, null, 19, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PointerEnter", UnityEngine.EventSystems.EventTriggerType.PointerEnter);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PointerExit", UnityEngine.EventSystems.EventTriggerType.PointerExit);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PointerDown", UnityEngine.EventSystems.EventTriggerType.PointerDown);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PointerUp", UnityEngine.EventSystems.EventTriggerType.PointerUp);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PointerClick", UnityEngine.EventSystems.EventTriggerType.PointerClick);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Drag", UnityEngine.EventSystems.EventTriggerType.Drag);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Drop", UnityEngine.EventSystems.EventTriggerType.Drop);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Scroll", UnityEngine.EventSystems.EventTriggerType.Scroll);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UpdateSelected", UnityEngine.EventSystems.EventTriggerType.UpdateSelected);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Select", UnityEngine.EventSystems.EventTriggerType.Select);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Deselect", UnityEngine.EventSystems.EventTriggerType.Deselect);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Move", UnityEngine.EventSystems.EventTriggerType.Move);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "InitializePotentialDrag", UnityEngine.EventSystems.EventTriggerType.InitializePotentialDrag);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BeginDrag", UnityEngine.EventSystems.EventTriggerType.BeginDrag);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EndDrag", UnityEngine.EventSystems.EventTriggerType.EndDrag);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Submit", UnityEngine.EventSystems.EventTriggerType.Submit);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Cancel", UnityEngine.EventSystems.EventTriggerType.Cancel);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.EventSystems.EventTriggerType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(UnityEngine.EventSystems.EventTriggerType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineEventSystemsEventTriggerType(L, (UnityEngine.EventSystems.EventTriggerType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "PointerEnter"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.PointerEnter);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PointerExit"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.PointerExit);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PointerDown"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.PointerDown);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PointerUp"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.PointerUp);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PointerClick"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.PointerClick);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Drag"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.Drag);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Drop"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.Drop);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Scroll"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.Scroll);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UpdateSelected"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.UpdateSelected);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Select"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.Select);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Deselect"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.Deselect);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Move"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.Move);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "InitializePotentialDrag"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.InitializePotentialDrag);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BeginDrag"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.BeginDrag);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EndDrag"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.EndDrag);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Submit"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.Submit);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Cancel"))
                {
                    translator.PushUnityEngineEventSystemsEventTriggerType(L, UnityEngine.EventSystems.EventTriggerType.Cancel);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.EventSystems.EventTriggerType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.EventSystems.EventTriggerType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class AutoScaleScaleModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(AutoScale.ScaleMode), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(AutoScale.ScaleMode), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(AutoScale.ScaleMode), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BASE_WIDTH", AutoScale.ScaleMode.BASE_WIDTH);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "BASE_HEIGHT", AutoScale.ScaleMode.BASE_HEIGHT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "STRETCH", AutoScale.ScaleMode.STRETCH);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(AutoScale.ScaleMode));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(AutoScale.ScaleMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushAutoScaleScaleMode(L, (AutoScale.ScaleMode)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "BASE_WIDTH"))
                {
                    translator.PushAutoScaleScaleMode(L, AutoScale.ScaleMode.BASE_WIDTH);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BASE_HEIGHT"))
                {
                    translator.PushAutoScaleScaleMode(L, AutoScale.ScaleMode.BASE_HEIGHT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "STRETCH"))
                {
                    translator.PushAutoScaleScaleMode(L, AutoScale.ScaleMode.STRETCH);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for AutoScale.ScaleMode!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for AutoScale.ScaleMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class EmojiTextEmojiMaterialTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(EmojiText.EmojiMaterialType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(EmojiText.EmojiMaterialType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(EmojiText.EmojiMaterialType), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", EmojiText.EmojiMaterialType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Default", EmojiText.EmojiMaterialType.Default);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EquipTips", EmojiText.EmojiMaterialType.EquipTips);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(EmojiText.EmojiMaterialType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(EmojiText.EmojiMaterialType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushEmojiTextEmojiMaterialType(L, (EmojiText.EmojiMaterialType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushEmojiTextEmojiMaterialType(L, EmojiText.EmojiMaterialType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Default"))
                {
                    translator.PushEmojiTextEmojiMaterialType(L, EmojiText.EmojiMaterialType.Default);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EquipTips"))
                {
                    translator.PushEmojiTextEmojiMaterialType(L, EmojiText.EmojiMaterialType.EquipTips);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for EmojiText.EmojiMaterialType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for EmojiText.EmojiMaterialType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcuiLockIconStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ui.LockIcon.State), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ui.LockIcon.State), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ui.LockIcon.State), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "USE_COLOR", xc.ui.LockIcon.State.USE_COLOR);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "USE_GREY_COMPONENT", xc.ui.LockIcon.State.USE_GREY_COMPONENT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.LockIcon.State));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ui.LockIcon.State), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcuiLockIconState(L, (xc.ui.LockIcon.State)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "USE_COLOR"))
                {
                    translator.PushxcuiLockIconState(L, xc.ui.LockIcon.State.USE_COLOR);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "USE_GREY_COMPONENT"))
                {
                    translator.PushxcuiLockIconState(L, xc.ui.LockIcon.State.USE_GREY_COMPONENT);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ui.LockIcon.State!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ui.LockIcon.State! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcuiuguiUIManagerRefreshOrderWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UIManager.RefreshOrder), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UIManager.RefreshOrder), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ui.ugui.UIManager.RefreshOrder), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "All", xc.ui.ugui.UIManager.RefreshOrder.All);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Normal", xc.ui.ugui.UIManager.RefreshOrder.Normal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Pop", xc.ui.ugui.UIManager.RefreshOrder.Pop);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UIManager.RefreshOrder));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ui.ugui.UIManager.RefreshOrder), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcuiuguiUIManagerRefreshOrder(L, (xc.ui.ugui.UIManager.RefreshOrder)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "All"))
                {
                    translator.PushxcuiuguiUIManagerRefreshOrder(L, xc.ui.ugui.UIManager.RefreshOrder.All);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Normal"))
                {
                    translator.PushxcuiuguiUIManagerRefreshOrder(L, xc.ui.ugui.UIManager.RefreshOrder.Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Pop"))
                {
                    translator.PushxcuiuguiUIManagerRefreshOrder(L, xc.ui.ugui.UIManager.RefreshOrder.Pop);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ui.ugui.UIManager.RefreshOrder!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ui.ugui.UIManager.RefreshOrder! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcuiuguiUIBaseWindowCloseWinsTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", xc.ui.ugui.UIBaseWindow.CloseWinsType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GoodsAndEquipTips", xc.ui.ugui.UIBaseWindow.CloseWinsType.GoodsAndEquipTips);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ui.ugui.UIBaseWindow.CloseWinsType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcuiuguiUIBaseWindowCloseWinsType(L, (xc.ui.ugui.UIBaseWindow.CloseWinsType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushxcuiuguiUIBaseWindowCloseWinsType(L, xc.ui.ugui.UIBaseWindow.CloseWinsType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GoodsAndEquipTips"))
                {
                    translator.PushxcuiuguiUIBaseWindowCloseWinsType(L, xc.ui.ugui.UIBaseWindow.CloseWinsType.GoodsAndEquipTips);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ui.ugui.UIBaseWindow.CloseWinsType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ui.ugui.UIBaseWindow.CloseWinsType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcuiuguiUITypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UIType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UIType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ui.ugui.UIType), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Normal", xc.ui.ugui.UIType.Normal);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Hud", xc.ui.ugui.UIType.Hud);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Loading", xc.ui.ugui.UIType.Loading);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Pop", xc.ui.ugui.UIType.Pop);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UIType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ui.ugui.UIType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcuiuguiUIType(L, (xc.ui.ugui.UIType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Normal"))
                {
                    translator.PushxcuiuguiUIType(L, xc.ui.ugui.UIType.Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Hud"))
                {
                    translator.PushxcuiuguiUIType(L, xc.ui.ugui.UIType.Hud);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Loading"))
                {
                    translator.PushxcuiuguiUIType(L, xc.ui.ugui.UIType.Loading);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Pop"))
                {
                    translator.PushxcuiuguiUIType(L, xc.ui.ugui.UIType.Pop);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ui.ugui.UIType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ui.ugui.UIType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcuiUIWidgetHelpDragDropGroupWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ui.UIWidgetHelp.DragDropGroup), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ui.UIWidgetHelp.DragDropGroup), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ui.UIWidgetHelp.DragDropGroup), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Player", xc.ui.UIWidgetHelp.DragDropGroup.Player);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Bag", xc.ui.UIWidgetHelp.DragDropGroup.Bag);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WareHouse", xc.ui.UIWidgetHelp.DragDropGroup.WareHouse);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TempBag", xc.ui.UIWidgetHelp.DragDropGroup.TempBag);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.UIWidgetHelp.DragDropGroup));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ui.UIWidgetHelp.DragDropGroup), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcuiUIWidgetHelpDragDropGroup(L, (xc.ui.UIWidgetHelp.DragDropGroup)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Player"))
                {
                    translator.PushxcuiUIWidgetHelpDragDropGroup(L, xc.ui.UIWidgetHelp.DragDropGroup.Player);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bag"))
                {
                    translator.PushxcuiUIWidgetHelpDragDropGroup(L, xc.ui.UIWidgetHelp.DragDropGroup.Bag);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WareHouse"))
                {
                    translator.PushxcuiUIWidgetHelpDragDropGroup(L, xc.ui.UIWidgetHelp.DragDropGroup.WareHouse);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TempBag"))
                {
                    translator.PushxcuiUIWidgetHelpDragDropGroup(L, xc.ui.UIWidgetHelp.DragDropGroup.TempBag);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ui.UIWidgetHelp.DragDropGroup!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ui.UIWidgetHelp.DragDropGroup! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcuiuguiUINoticeWindowEWindowTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UINoticeWindow.EWindowType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UINoticeWindow.EWindowType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.ui.ugui.UINoticeWindow.EWindowType), L, null, 16, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WT_No_Button", xc.ui.ugui.UINoticeWindow.EWindowType.WT_No_Button);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SH_CloseBtn", xc.ui.ugui.UINoticeWindow.EWindowType.SH_CloseBtn);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SH_OKBtn", xc.ui.ugui.UINoticeWindow.EWindowType.SH_OKBtn);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SH_CancelBtn", xc.ui.ugui.UINoticeWindow.EWindowType.SH_CancelBtn);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SH_DisableClose", xc.ui.ugui.UINoticeWindow.EWindowType.SH_DisableClose);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "SH_Toggle", xc.ui.ugui.UINoticeWindow.EWindowType.SH_Toggle);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WT_OK", xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WT_OK_Toggle", xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Toggle);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WT_Cancel", xc.ui.ugui.UINoticeWindow.EWindowType.WT_Cancel);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WT_OK_Cancel", xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WT_OK_Cancel_Toggle", xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel_Toggle);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WT_OK_DisableCloseBtn", xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WT_Cancel_DisableCloseBtn", xc.ui.ugui.UINoticeWindow.EWindowType.WT_Cancel_DisableCloseBtn);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WT_OK_Cancel_DisableCloseBtn", xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel_DisableCloseBtn);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UINoticeWindow.EWindowType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.ui.ugui.UINoticeWindow.EWindowType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcuiuguiUINoticeWindowEWindowType(L, (xc.ui.ugui.UINoticeWindow.EWindowType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "WT_No_Button"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.WT_No_Button);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SH_CloseBtn"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.SH_CloseBtn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SH_OKBtn"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.SH_OKBtn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SH_CancelBtn"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.SH_CancelBtn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SH_DisableClose"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.SH_DisableClose);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SH_Toggle"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.SH_Toggle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WT_OK"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WT_OK_Toggle"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Toggle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WT_Cancel"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.WT_Cancel);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WT_OK_Cancel"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WT_OK_Cancel_Toggle"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel_Toggle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WT_OK_DisableCloseBtn"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WT_Cancel_DisableCloseBtn"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.WT_Cancel_DisableCloseBtn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WT_OK_Cancel_DisableCloseBtn"))
                {
                    translator.PushxcuiuguiUINoticeWindowEWindowType(L, xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel_DisableCloseBtn);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.ui.ugui.UINoticeWindow.EWindowType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.ui.ugui.UINoticeWindow.EWindowType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcGoodsHelperItemMainTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.GoodsHelper.ItemMainType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.GoodsHelper.ItemMainType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.GoodsHelper.ItemMainType), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NULLTYPE", xc.GoodsHelper.ItemMainType.NULLTYPE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ITEM", xc.GoodsHelper.ItemMainType.ITEM);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EQUIP", xc.GoodsHelper.ItemMainType.EQUIP);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "COIN", xc.GoodsHelper.ItemMainType.COIN);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsHelper.ItemMainType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.GoodsHelper.ItemMainType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcGoodsHelperItemMainType(L, (xc.GoodsHelper.ItemMainType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "NULLTYPE"))
                {
                    translator.PushxcGoodsHelperItemMainType(L, xc.GoodsHelper.ItemMainType.NULLTYPE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ITEM"))
                {
                    translator.PushxcGoodsHelperItemMainType(L, xc.GoodsHelper.ItemMainType.ITEM);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EQUIP"))
                {
                    translator.PushxcGoodsHelperItemMainType(L, xc.GoodsHelper.ItemMainType.EQUIP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "COIN"))
                {
                    translator.PushxcGoodsHelperItemMainType(L, xc.GoodsHelper.ItemMainType.COIN);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.GoodsHelper.ItemMainType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.GoodsHelper.ItemMainType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcTaskDefineEAutoRunTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.TaskDefine.EAutoRunType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.TaskDefine.EAutoRunType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.TaskDefine.EAutoRunType), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", xc.TaskDefine.EAutoRunType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "AutoRun", xc.TaskDefine.EAutoRunType.AutoRun);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ForceAutoRun", xc.TaskDefine.EAutoRunType.ForceAutoRun);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ForceAutoRun2", xc.TaskDefine.EAutoRunType.ForceAutoRun2);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TaskDefine.EAutoRunType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.TaskDefine.EAutoRunType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcTaskDefineEAutoRunType(L, (xc.TaskDefine.EAutoRunType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushxcTaskDefineEAutoRunType(L, xc.TaskDefine.EAutoRunType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoRun"))
                {
                    translator.PushxcTaskDefineEAutoRunType(L, xc.TaskDefine.EAutoRunType.AutoRun);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ForceAutoRun"))
                {
                    translator.PushxcTaskDefineEAutoRunType(L, xc.TaskDefine.EAutoRunType.ForceAutoRun);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ForceAutoRun2"))
                {
                    translator.PushxcTaskDefineEAutoRunType(L, xc.TaskDefine.EAutoRunType.ForceAutoRun2);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.TaskDefine.EAutoRunType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.TaskDefine.EAutoRunType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcVoiceControlComponentStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.VoiceControlComponent.State), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.VoiceControlComponent.State), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.VoiceControlComponent.State), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Idle", xc.VoiceControlComponent.State.Idle);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Recording", xc.VoiceControlComponent.State.Recording);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Cancel", xc.VoiceControlComponent.State.Cancel);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.VoiceControlComponent.State));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.VoiceControlComponent.State), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcVoiceControlComponentState(L, (xc.VoiceControlComponent.State)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Idle"))
                {
                    translator.PushxcVoiceControlComponentState(L, xc.VoiceControlComponent.State.Idle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Recording"))
                {
                    translator.PushxcVoiceControlComponentState(L, xc.VoiceControlComponent.State.Recording);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Cancel"))
                {
                    translator.PushxcVoiceControlComponentState(L, xc.VoiceControlComponent.State.Cancel);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.VoiceControlComponent.State!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.VoiceControlComponent.State! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcEquipBaptizeInfoEquipBaptizeStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.EquipBaptizeInfo.EquipBaptizeState), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.EquipBaptizeInfo.EquipBaptizeState), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.EquipBaptizeInfo.EquipBaptizeState), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NO_Open", xc.EquipBaptizeInfo.EquipBaptizeState.NO_Open);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Open", xc.EquipBaptizeInfo.EquipBaptizeState.Open);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Lock", xc.EquipBaptizeInfo.EquipBaptizeState.Lock);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.EquipBaptizeInfo.EquipBaptizeState));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.EquipBaptizeInfo.EquipBaptizeState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcEquipBaptizeInfoEquipBaptizeState(L, (xc.EquipBaptizeInfo.EquipBaptizeState)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "NO_Open"))
                {
                    translator.PushxcEquipBaptizeInfoEquipBaptizeState(L, xc.EquipBaptizeInfo.EquipBaptizeState.NO_Open);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Open"))
                {
                    translator.PushxcEquipBaptizeInfoEquipBaptizeState(L, xc.EquipBaptizeInfo.EquipBaptizeState.Open);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Lock"))
                {
                    translator.PushxcEquipBaptizeInfoEquipBaptizeState(L, xc.EquipBaptizeInfo.EquipBaptizeState.Lock);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.EquipBaptizeInfo.EquipBaptizeState!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.EquipBaptizeInfo.EquipBaptizeState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcInteractiveTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.InteractiveType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.InteractiveType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.InteractiveType), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "None", xc.InteractiveType.None);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Team", xc.InteractiveType.Team);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.InteractiveType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.InteractiveType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcInteractiveType(L, (xc.InteractiveType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushxcInteractiveType(L, xc.InteractiveType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Team"))
                {
                    translator.PushxcInteractiveType(L, xc.InteractiveType.Team);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.InteractiveType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.InteractiveType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcFriendTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.FriendType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.FriendType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.FriendType), L, null, 6, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Closer", xc.FriendType.Closer);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Friend", xc.FriendType.Friend);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Enemy", xc.FriendType.Enemy);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Black", xc.FriendType.Black);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.FriendType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.FriendType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcFriendType(L, (xc.FriendType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Closer"))
                {
                    translator.PushxcFriendType(L, xc.FriendType.Closer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Friend"))
                {
                    translator.PushxcFriendType(L, xc.FriendType.Friend);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Enemy"))
                {
                    translator.PushxcFriendType(L, xc.FriendType.Enemy);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Black"))
                {
                    translator.PushxcFriendType(L, xc.FriendType.Black);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.FriendType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.FriendType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcMailInfoJumpTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.MailInfo.JumpType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.MailInfo.JumpType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.MailInfo.JumpType), L, null, 9, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRADE_FOCUS", xc.MailInfo.JumpType.TRADE_FOCUS);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRADE_DARK", xc.MailInfo.JumpType.TRADE_DARK);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRADE_SUIT", xc.MailInfo.JumpType.TRADE_SUIT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRADE_SELL", xc.MailInfo.JumpType.TRADE_SELL);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRADE_AUCTION", xc.MailInfo.JumpType.TRADE_AUCTION);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRADE_COLLECT", xc.MailInfo.JumpType.TRADE_COLLECT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TRADE_CROSS_COLLECT", xc.MailInfo.JumpType.TRADE_CROSS_COLLECT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MailInfo.JumpType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.MailInfo.JumpType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcMailInfoJumpType(L, (xc.MailInfo.JumpType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "TRADE_FOCUS"))
                {
                    translator.PushxcMailInfoJumpType(L, xc.MailInfo.JumpType.TRADE_FOCUS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRADE_DARK"))
                {
                    translator.PushxcMailInfoJumpType(L, xc.MailInfo.JumpType.TRADE_DARK);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRADE_SUIT"))
                {
                    translator.PushxcMailInfoJumpType(L, xc.MailInfo.JumpType.TRADE_SUIT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRADE_SELL"))
                {
                    translator.PushxcMailInfoJumpType(L, xc.MailInfo.JumpType.TRADE_SELL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRADE_AUCTION"))
                {
                    translator.PushxcMailInfoJumpType(L, xc.MailInfo.JumpType.TRADE_AUCTION);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRADE_COLLECT"))
                {
                    translator.PushxcMailInfoJumpType(L, xc.MailInfo.JumpType.TRADE_COLLECT);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TRADE_CROSS_COLLECT"))
                {
                    translator.PushxcMailInfoJumpType(L, xc.MailInfo.JumpType.TRADE_CROSS_COLLECT);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.MailInfo.JumpType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.MailInfo.JumpType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcSceneHelpLoadQuadTreeSceneStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.SceneHelp.LoadQuadTreeSceneState), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.SceneHelp.LoadQuadTreeSceneState), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.SceneHelp.LoadQuadTreeSceneState), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NoStartLoading", xc.SceneHelp.LoadQuadTreeSceneState.NoStartLoading);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Loading", xc.SceneHelp.LoadQuadTreeSceneState.Loading);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "LoadFinished", xc.SceneHelp.LoadQuadTreeSceneState.LoadFinished);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.SceneHelp.LoadQuadTreeSceneState));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.SceneHelp.LoadQuadTreeSceneState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcSceneHelpLoadQuadTreeSceneState(L, (xc.SceneHelp.LoadQuadTreeSceneState)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "NoStartLoading"))
                {
                    translator.PushxcSceneHelpLoadQuadTreeSceneState(L, xc.SceneHelp.LoadQuadTreeSceneState.NoStartLoading);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Loading"))
                {
                    translator.PushxcSceneHelpLoadQuadTreeSceneState(L, xc.SceneHelp.LoadQuadTreeSceneState.Loading);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LoadFinished"))
                {
                    translator.PushxcSceneHelpLoadQuadTreeSceneState(L, xc.SceneHelp.LoadQuadTreeSceneState.LoadFinished);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.SceneHelp.LoadQuadTreeSceneState!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.SceneHelp.LoadQuadTreeSceneState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcInstanceManagerInstaneOpenStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.InstanceManager.InstaneOpenState), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.InstanceManager.InstaneOpenState), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.InstanceManager.InstaneOpenState), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "NotOpen", xc.InstanceManager.InstaneOpenState.NotOpen);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Open", xc.InstanceManager.InstaneOpenState.Open);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.InstanceManager.InstaneOpenState));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.InstanceManager.InstaneOpenState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcInstanceManagerInstaneOpenState(L, (xc.InstanceManager.InstaneOpenState)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "NotOpen"))
                {
                    translator.PushxcInstanceManagerInstaneOpenState(L, xc.InstanceManager.InstaneOpenState.NotOpen);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Open"))
                {
                    translator.PushxcInstanceManagerInstaneOpenState(L, xc.InstanceManager.InstaneOpenState.Open);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.InstanceManager.InstaneOpenState!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.InstanceManager.InstaneOpenState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcInstanceManagerERewardStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.InstanceManager.ERewardState), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.InstanceManager.ERewardState), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.InstanceManager.ERewardState), L, null, 5, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "RS_UnGot", xc.InstanceManager.ERewardState.RS_UnGot);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "RS_Got", xc.InstanceManager.ERewardState.RS_Got);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "RS_UnFinished", xc.InstanceManager.ERewardState.RS_UnFinished);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.InstanceManager.ERewardState));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.InstanceManager.ERewardState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcInstanceManagerERewardState(L, (xc.InstanceManager.ERewardState)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "RS_UnGot"))
                {
                    translator.PushxcInstanceManagerERewardState(L, xc.InstanceManager.ERewardState.RS_UnGot);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RS_Got"))
                {
                    translator.PushxcInstanceManagerERewardState(L, xc.InstanceManager.ERewardState.RS_Got);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RS_UnFinished"))
                {
                    translator.PushxcInstanceManagerERewardState(L, xc.InstanceManager.ERewardState.RS_UnFinished);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.InstanceManager.ERewardState!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.InstanceManager.ERewardState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcEHookRangeTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.EHookRangeType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.EHookRangeType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.EHookRangeType), L, null, 4, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "InRange", xc.EHookRangeType.InRange);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FixedPos", xc.EHookRangeType.FixedPos);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.EHookRangeType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.EHookRangeType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcEHookRangeType(L, (xc.EHookRangeType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "InRange"))
                {
                    translator.PushxcEHookRangeType(L, xc.EHookRangeType.InRange);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FixedPos"))
                {
                    translator.PushxcEHookRangeType(L, xc.EHookRangeType.FixedPos);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.EHookRangeType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.EHookRangeType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class xcCustomDataTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    XUtils.BeginObjectRegister(typeof(xc.CustomDataType), L, translator, 0, 0, 0, 0);
			XUtils.EndObjectRegister(typeof(xc.CustomDataType), L, translator, null, null, null, null, null);
			
			XUtils.BeginClassRegister(typeof(xc.CustomDataType), L, null, 8, 0, 0);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WorldMapLock", xc.CustomDataType.WorldMapLock);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "TargetSysLock", xc.CustomDataType.TargetSysLock);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "WorldBossExpEnter", xc.CustomDataType.WorldBossExpEnter);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "IsOpenSysMount", xc.CustomDataType.IsOpenSysMount);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "IsFirstGetElfin", xc.CustomDataType.IsFirstGetElfin);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GodEquipPosUnlock", xc.CustomDataType.GodEquipPosUnlock);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.CustomDataType));
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "__CastFrom", __CastFrom);
            
            XUtils.EndClassRegister(typeof(xc.CustomDataType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushxcCustomDataType(L, (xc.CustomDataType)LuaAPI.xlua_tointeger(L, 1));
            }
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "WorldMapLock"))
                {
                    translator.PushxcCustomDataType(L, xc.CustomDataType.WorldMapLock);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TargetSysLock"))
                {
                    translator.PushxcCustomDataType(L, xc.CustomDataType.TargetSysLock);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WorldBossExpEnter"))
                {
                    translator.PushxcCustomDataType(L, xc.CustomDataType.WorldBossExpEnter);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IsOpenSysMount"))
                {
                    translator.PushxcCustomDataType(L, xc.CustomDataType.IsOpenSysMount);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IsFirstGetElfin"))
                {
                    translator.PushxcCustomDataType(L, xc.CustomDataType.IsFirstGetElfin);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GodEquipPosUnlock"))
                {
                    translator.PushxcCustomDataType(L, xc.CustomDataType.GodEquipPosUnlock);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for xc.CustomDataType!");
                }
            }
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for xc.CustomDataType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}