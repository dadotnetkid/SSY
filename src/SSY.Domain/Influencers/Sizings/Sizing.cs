using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSY.UserDetails;

namespace SSY.Influencers.Sizings
{
    public class Sizing : FullAuditedAggregateRoot<Guid>
    {
        public Sizing(Guid? userId, string toziUser, string toziId, string toziCode, string toziObj, decimal toziTopSize, decimal toziBottomSize, decimal toziDressSize, decimal toziHeight, decimal toziWeight, decimal neckGirth, decimal armLength, decimal shoulderLenth, decimal armholeGirth, decimal acrossFront, decimal acrossBack, decimal aboveBustGirth, decimal bustGirth, decimal chestWidth, decimal backWaistLength, decimal waistGirth, decimal lowWaistGirth, decimal lowerWaistGirth, decimal hipGirth, decimal crotchLength, decimal kneeGirth, decimal calfGirth, decimal inseamInLeg, decimal inseamInLegAngkle, decimal sideSeam)
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

        public virtual Guid? UserId { get; protected set; }
        public virtual string ToziUser { get; protected set; }

        public virtual string ToziId { get; protected set; }

        public virtual string ToziCode { get; protected set; }

        public virtual string ToziObj { get; protected set; }
        public virtual decimal ToziTopSize { get; protected set; }
        public virtual decimal ToziBottomSize { get; protected set; }
        public virtual decimal ToziDressSize { get; protected set; }
        public virtual decimal ToziHeight { get; protected set; }
        public virtual decimal ToziWeight { get; protected set; }

        public virtual decimal NeckGirth { get; protected set; }
        [Description("From Mid Shoulder")]
        public virtual decimal ArmLength { get; protected set; }

        public virtual decimal ShoulderLenth { get; protected set; }
        public virtual decimal ArmholeGirth { get; protected set; }
        public virtual decimal AcrossFront { get; protected set; }
        public virtual decimal AcrossBack { get; protected set; }
        public virtual decimal AboveBustGirth { get; protected set; }
        public virtual decimal BustGirth { get; protected set; }
        public virtual decimal ChestWidth { get; protected set; }
        public virtual decimal BackWaistLength { get; protected set; }

        public virtual decimal WaistGirth { get; protected set; }
        public virtual decimal LowWaistGirth { get; protected set; }
        public virtual decimal LowerWaistGirth { get; protected set; }
        public virtual decimal HipGirth { get; protected set; }
        [Description("To Low Waist")]
        public virtual decimal CrotchLength { get; protected set; }
        public virtual decimal KneeGirth { get; protected set; }
        public virtual decimal CalfGirth { get; protected set; }
        public virtual decimal InseamInLeg { get; protected set; }
        public virtual decimal InseamInLegAngkle { get; protected set; }
        public virtual decimal SideSeam { get; protected set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
