using System;
using PX.Data;

namespace Hackathon2025Team3
{
    [Serializable]
    [PXCacheName("NTNote")]
    public class NTNote : PXBqlTable, IBqlTable
    {
        #region GroupID
        [PXDBGuid]
        [PXUIField(DisplayName = "Group ID")]
        public virtual Guid? GroupID { get; set; }
        public abstract class groupID : PX.Data.BQL.BqlGuid.Field<groupID> { }
        #endregion

        #region Notekey
        [PXDBIdentity(IsKey =true)]
        public virtual int? Notekey { get; set; }
        public abstract class notekey : PX.Data.BQL.BqlInt.Field<notekey> { }
        #endregion

        #region NoteText
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Note Text")]
        public virtual string NoteText { get; set; }
        public abstract class noteText : PX.Data.BQL.BqlString.Field<noteText> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion
    }
}