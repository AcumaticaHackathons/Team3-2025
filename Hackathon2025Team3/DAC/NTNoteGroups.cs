using System;
using PX.Data;

namespace Hackathon2025Team3
{
  [Serializable]
  [PXCacheName("NTNoteGroups")]
  public class NTNoteGroups : PXBqlTable, IBqlTable
  {
    #region GroupID
    [PXDBGuid(IsKey = true)]
    [PXUIField(DisplayName = "Group ID")]
    public virtual Guid? GroupID { get; set; }
    public abstract class groupID : PX.Data.BQL.BqlGuid.Field<groupID> { }
    #endregion

    #region Noteid
    [PXNote()]
    public virtual Guid? Noteid { get; set; }
    public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
    #endregion
  }
}