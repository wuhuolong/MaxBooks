//----------------------------------------
// File: AvatarProperty.cs
// Desc: 换装属性的字段
// Author: raouri
// Date: 2017.10.28
//----------------------------------------
using System;
using System.Collections.Generic;

namespace xc
{
    /// <summary>
    /// 换装相关的属性
    /// </summary>
    public class AvatarProperty
    {
        /// <summary>
        /// 实际穿上的装备id(可能为EquipBodyId或者FashionBodyId)
        /// </summary>
        public uint BodyId;

        /// <summary>
        /// 实际穿上的武器id(可能为EquipWeaponId或者FashionWeaponId或者LightWeaponId)
        /// </summary>
        public uint WeaponId;

        /// <summary>
        /// 装备ID
        /// </summary>
        public uint EquipBodyId;

        /// <summary>
        /// 武器ID
        /// </summary>
        public uint EquipWeaponId;

        /// <summary>
        /// 时装装备id
        /// </summary>
        public uint FashionBodyId;

        /// <summary>
        /// 时装武器id
        /// </summary>
        public uint FashionWeaponId;

        /// <summary>
        /// 时装翅膀id
        /// </summary>
        public uint FashionWingId;

        /// <summary>
        /// 套装的特效ID列表
        /// </summary>
        public List<uint> SuitEffectIds;

        /// <summary>
        /// 翅膀的资源路径
        /// </summary>
        public string WingResPath;

        public uint ElfinId;    //小精灵ID
        public string ElfinResPath; //小精灵资源路径

        public uint FashionMagicalPetId;    //神宠ID
        public string MagicalPetResPath; //神宠资源路径

        public uint FashionFootprintId;//足迹ID
        public uint FashionPhotoFrameId;//相框ID
        public uint FashionBubbleId;//气泡ID
        public uint LightWeaponId;//光武ID
        public uint BackAttachmentID; // 背饰ID

        /// <summary>
        /// 职业类型
        /// </summary>
        public Actor.EVocationType Vocation;

        public AvatarProperty(AvatarProperty other)
        {
            BodyId = other.BodyId;
            WeaponId = other.WeaponId;
            FashionWingId = other.FashionWingId;
            FashionBodyId = other.FashionBodyId;
            FashionWeaponId = other.FashionWeaponId;
            EquipBodyId = other.EquipBodyId;
            EquipWeaponId = other.EquipWeaponId;

            if (other.SuitEffectIds != null)
            {
                SuitEffectIds = new List<uint>(other.SuitEffectIds);
            }

            WingResPath = other.WingResPath;

            Vocation = other.Vocation;

            ElfinId = other.ElfinId;
            ElfinResPath = other.ElfinResPath;

            FashionMagicalPetId = other.FashionMagicalPetId;
            MagicalPetResPath = other.MagicalPetResPath;

            FashionFootprintId = other.FashionFootprintId;
            FashionBubbleId = other.FashionBubbleId;
            FashionPhotoFrameId = other.FashionPhotoFrameId;
            LightWeaponId = other.LightWeaponId;
            BackAttachmentID = other.BackAttachmentID;
        }

        public AvatarProperty()
        {
            SuitEffectIds = new List<uint>();
        }

        public AvatarProperty Clone()
        {
            return new AvatarProperty(this);
        }


        public List<uint> GetEquipModleIds()
        {
            return new List<uint> { EquipBodyId, EquipWeaponId, ElfinId };
        }

        public List<uint> GetFashionModleIds()
        {
            return new List<uint> { FashionBodyId, FashionWeaponId, FashionWingId, FashionMagicalPetId, FashionFootprintId, FashionBubbleId, FashionPhotoFrameId, LightWeaponId, BackAttachmentID };
        }


        public void SetEquipPart(DBAvatarPart.BODY_PART part, uint id)
        {
            if (part == DBAvatarPart.BODY_PART.BODY)
                EquipBodyId = id;

            if (part == DBAvatarPart.BODY_PART.WEAPON)
                EquipWeaponId = id;

            if (part == DBAvatarPart.BODY_PART.ELFIN)
                ElfinId = id;
        }

        public void SetFashionPart(DBAvatarPart.BODY_PART part, uint id)
        {
            if (part == DBAvatarPart.BODY_PART.BODY)
                FashionBodyId = id;

            if (part == DBAvatarPart.BODY_PART.WEAPON)
                FashionWeaponId = id;

            if (part == DBAvatarPart.BODY_PART.WING)
                FashionWingId = id;

            if (part == DBAvatarPart.BODY_PART.MAGICAL_PET)
                FashionMagicalPetId = id;

            if (part == DBAvatarPart.BODY_PART.FOOTPRINT)
                FashionFootprintId = id;

            if (part == DBAvatarPart.BODY_PART.PHOTO_FRAME)
                FashionPhotoFrameId = id;

            if (part == DBAvatarPart.BODY_PART.BUBBLE)
                FashionBubbleId = id;

            if (part == DBAvatarPart.BODY_PART.LIGHT_WEAPON)
                LightWeaponId = id;
            if (part == DBAvatarPart.BODY_PART.BACK_ATTACHMENT)
                BackAttachmentID = id;
        }

        public void AddSuitEffectId(uint id)
        {
            if (SuitEffectIds == null)
            {
                SuitEffectIds = new List<uint>();
            }
            if (!SuitEffectIds.Contains(id))
            {
                SuitEffectIds.Add(id);
            }
        }

        public void RemoveSuitEffectId(uint id)
        {
            if (SuitEffectIds != null)
            {
                SuitEffectIds.Remove(id);
            }
        }
    }
}
