using System;
using UnityEngine;

namespace xc
{
    public class ModelInfo
    {
        /// <summary>
        /// 模型ID
        /// </summary>
        public readonly uint Id;

        /// <summary>
        /// 模型Prefab路径
        /// </summary>
        public readonly string Model;

        /// <summary>
        /// UI上的模型Prefab路径
        /// </summary>
        public readonly string UIModel;

        /// <summary>
        /// 头像
        /// </summary>
        public readonly string Icon;

        /// <summary>
        /// 模型缩放
        /// </summary>
        public readonly float Scale;

        /// <summary>
        /// 模型在场景里面的位置偏移
        /// </summary>
        public readonly Vector3 PosOffsetInScene;

        /// <summary>
        /// 模型在对话框里面的摄像机偏移
        /// </summary>
        public readonly Vector3 CamOffsetInDialogWnd;

        /// <summary>
        /// 模型在对话框里面的摄像机旋转
        /// </summary>
        public readonly Vector3 CamRotateInDialogWnd;

        /// <summary>
        /// 模型在获得碎片界面的偏移
        /// </summary>
        public readonly Vector3 ModelOffsetInChipWin;

        /// <summary>
        /// 模型在获得碎片界面的角度
        /// </summary>
        public readonly Vector3 ModelAngleInChipWin;

        public readonly string ModelShowAction;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ModelInfo(uint id, string model, string uiModel, string icon, float scale, Vector3 posOffsetInScene, 
            Vector3 camOffsetInDialogWnd, Vector3 camRotateInDialogWnd, 
            Vector3 modelOffsetInChipWin, Vector3 modelAngleInChipWin, string modelShowAction)
        {
            Id = id;
            Model = model;
            UIModel = uiModel;
            Icon = icon;
            Scale = scale;
            PosOffsetInScene = posOffsetInScene;
            CamOffsetInDialogWnd = camOffsetInDialogWnd;
            CamRotateInDialogWnd = camRotateInDialogWnd;
            ModelOffsetInChipWin = modelOffsetInChipWin;
            ModelAngleInChipWin = modelAngleInChipWin;
            ModelShowAction = modelShowAction;
        }
    }
}