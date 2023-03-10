using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SSY.Influencer.Sizings.Dto
{
    public class SizingsDto:FullAuditedEntityDto<Guid>
    {
        public SizingsDto()
        {

        }
        public SizingsDto(Guid userId, string toziUser, string toziId, string toziCode, string toziObj, decimal toziTopSize, decimal toziBottomSize, decimal toziDressSize, decimal toziHeight, decimal toziWeight, decimal neckGirth, decimal armLength, decimal shoulderLenth, decimal armholeGirth, decimal acrossFront, decimal acrossBack, decimal aboveBustGirth, decimal bustGirth, decimal chestWidth, decimal backWaistLength, decimal waistGirth, decimal lowWaistGirth, decimal lowerWaistGirth, decimal hipGirth, decimal crotchLength, decimal kneeGirth, decimal calfGirth, decimal inseamInLeg, decimal inseamInLegAngkle, decimal sideSeam)
        {
            UserId = userId;
            ToziUser = toziUser;
            ToziId = toziId;
            ToziCode = toziCode;
            ToziObj = toziObj;
            ToziTopSize = toziTopSize;
            ToziBottomSize = toziBottomSize;
            ToziDressSize = toziDressSize;
            ToziHeight = toziHeight;
            ToziWeight = toziWeight;
            NeckGirth = neckGirth;
            ArmLength = armLength;
            ShoulderLenth = shoulderLenth;
            ArmholeGirth = armholeGirth;
            AcrossFront = acrossFront;
            AcrossBack = acrossBack;
            AboveBustGirth = aboveBustGirth;
            BustGirth = bustGirth;
            ChestWidth = chestWidth;
            BackWaistLength = backWaistLength;
            WaistGirth = waistGirth;
            LowWaistGirth = lowWaistGirth;
            LowerWaistGirth = lowerWaistGirth;
            HipGirth = hipGirth;
            CrotchLength = crotchLength;
            KneeGirth = kneeGirth;
            CalfGirth = calfGirth;
            InseamInLeg = inseamInLeg;
            InseamInLegAngkle = inseamInLegAngkle;
            SideSeam = sideSeam;
        }
        public virtual Guid UserId { get; set; }
        public virtual string ToziUser { get;  set; }

        public virtual string ToziId { get;  set; }

        public virtual string ToziCode { get;  set; }

        public virtual string ToziObj { get;  set; }
        public virtual decimal ToziTopSize { get;  set; }
        public virtual decimal ToziBottomSize { get;  set; }
        public virtual decimal ToziDressSize { get;  set; }
        public virtual decimal ToziHeight { get;  set; }
        public virtual decimal ToziWeight { get;  set; }

        public virtual decimal NeckGirth { get;  set; }
        [Description("From Mid Shoulder")]
        public virtual decimal ArmLength { get;  set; }

        public virtual decimal ShoulderLenth { get;  set; }
        public virtual decimal ArmholeGirth { get;  set; }
        public virtual decimal AcrossFront { get;  set; }
        public virtual decimal AcrossBack { get;  set; }
        public virtual decimal AboveBustGirth { get;  set; }
        public virtual decimal BustGirth { get;  set; }
        public virtual decimal ChestWidth { get;  set; }
        public virtual decimal BackWaistLength { get;  set; }

        public virtual decimal WaistGirth { get;  set; }
        public virtual decimal LowWaistGirth { get;  set; }
        public virtual decimal LowerWaistGirth { get;  set; }
        public virtual decimal HipGirth { get;  set; }
        [Description("To Low Waist")]
        public virtual decimal CrotchLength { get;  set; }
        public virtual decimal KneeGirth { get;  set; }
        public virtual decimal CalfGirth { get;  set; }
        public virtual decimal InseamInLeg { get;  set; }
        public virtual decimal InseamInLegAngkle { get;  set; }
        public virtual decimal SideSeam { get;  set; }
    }
}
