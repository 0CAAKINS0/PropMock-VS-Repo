using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PropMockModels
{
    public class Enums
    {
        public enum TaxOrderType
        {    
            TC = 4,
            TCB = 5,
            TCH = 6
        }

        public enum OrderType
        {
            Lien_Search = 1,
            Lien_Search_Without_Permits = 2,
            Estoppel = 3,
            TC = 4,
            TCB = 5,
            TCH = 6,
            Release_Tracking = 7,
            Curative_Services = 8
        }

        public enum States
        {
            [EnumMember(Value = "AL")]
            AL,
            [EnumMember(Value = "AK")]
            AK,
            [EnumMember(Value = "AZ")]
            AZ,
            [EnumMember(Value = "AR")]
            AR,
            [EnumMember(Value = "CA")]
            CA,
            [EnumMember(Value = "CO")]
            CO,
            [EnumMember(Value = "CT")]
            CT,
            [EnumMember(Value = "DE")]
            DE,
            [EnumMember(Value = "District of Columbia")]
            DC,
            [EnumMember(Value = "FL")]
            FL,
            [EnumMember(Value = "GA")]
            GA,
            [EnumMember(Value = "HI")]
            HI,
            [EnumMember(Value = "ID")]
            ID,
            [EnumMember(Value = "IL")]
            IL,
            [EnumMember(Value = "IN")]
            IN,
            [EnumMember(Value = "IA")]
            IA,
            [EnumMember(Value = "KS")]
            KS,
            [EnumMember(Value = "KY")]
            KY,
            [EnumMember(Value = "LA")]
            LA,
            [EnumMember(Value = "ME")]
            ME,
            [EnumMember(Value = "MA")]
            MA,
            [EnumMember(Value = "MD")]
            MD,
            [EnumMember(Value = "MI")]
            MI,
            [EnumMember(Value = "MN")]
            MN,
            [EnumMember(Value = "MS")]
            MS,
            [EnumMember(Value = "MO")]
            MO,
            [EnumMember(Value = "MT")]
            MT,
            [EnumMember(Value = "NE")]
            NE,
            [EnumMember(Value = "NV")]
            NV,
            [EnumMember(Value = "NH")]
            NH,
            [EnumMember(Value = "NJ")]
            NJ,
            [EnumMember(Value = "NM")]
            NM,
            [EnumMember(Value = "NY")]
            NY,
            [EnumMember(Value = "NC")]
            NC,
            [EnumMember(Value = "ND")]
            ND,
            [EnumMember(Value = "OH")]
            OH,
            [EnumMember(Value = "OK")]
            OK,
            [EnumMember(Value = "OR")]
            OR,
            [EnumMember(Value = "PA")]
            PA,
            [EnumMember(Value = "RI")]
            RI,
            [EnumMember(Value = "SC")]
            SC,
            [EnumMember(Value = "SD")]
            SD,
            [EnumMember(Value = "TN")]
            TN,
            [EnumMember(Value = "TX")]
            TX,
            [EnumMember(Value = "UT")]
            UT,
            [EnumMember(Value = "VA")]
            VA,
            [EnumMember(Value = "VT")]
            VT,
            [EnumMember(Value = "WA")]
            WA,
            [EnumMember(Value = "WI")]
            WI,
            [EnumMember(Value = "WV")]
            WV,
            [EnumMember(Value = "WY")]
            WY
        }
        public enum Status
        {
            Canceled = 0,
            New = 1,
            Assigned = 2,
            Processing = 3,
            Waiting = 4,
            Completed = 5
        }
        public enum Researcher
        {
            Unassigned = 0,
            Carter_Akins = 1,
            That_Dude = 2,
            The_Other_Guy = 3,
        }
    }
}

