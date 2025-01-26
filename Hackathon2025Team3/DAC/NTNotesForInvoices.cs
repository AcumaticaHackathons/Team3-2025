using System;
using PX.Data;

namespace Hackathon2025Team3
{
  [Serializable]
  [PXCacheName("NTNotesForInvoices")]
  public class NTNotesForInvoices : PXBqlTable, IBqlTable
  {
    #region Ordernbr
    [PXDBString(15, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Ordernbr")]
    public virtual string Ordernbr { get; set; }
    public abstract class ordernbr : PX.Data.BQL.BqlString.Field<ordernbr> { }
    #endregion

    #region OrderType
    [PXDBString(2, IsFixed = true, InputMask = "")]
    [PXUIField(DisplayName = "Order Type")]
    public virtual string OrderType { get; set; }
    public abstract class orderType : PX.Data.BQL.BqlString.Field<orderType> { }
    #endregion

    #region Refnbr
    [PXDBString(15, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Refnbr")]
    public virtual string Refnbr { get; set; }
    public abstract class refnbr : PX.Data.BQL.BqlString.Field<refnbr> { }
    #endregion

    #region ShipmentNbr
    [PXDBString(15, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Shipment Nbr")]
    public virtual string ShipmentNbr { get; set; }
    public abstract class shipmentNbr : PX.Data.BQL.BqlString.Field<shipmentNbr> { }
    #endregion

    #region GroupID
    [PXDBGuid()]
    [PXUIField(DisplayName = "Group ID")]
    public virtual Guid? GroupID { get; set; }
    public abstract class groupID : PX.Data.BQL.BqlGuid.Field<groupID> { }
    #endregion

    #region Notekey
    [PXDBInt()]
    [PXUIField(DisplayName = "Notekey")]
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