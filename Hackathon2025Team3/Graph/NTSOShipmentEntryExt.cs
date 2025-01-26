using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.SO;
using PX.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Hackathon2025Team3.Graph
{
    public class NTSOShipmentEntryExt : PXGraphExtension<SOShipmentEntry>
    {
        public static bool IsActive() => true;



        #region Views
        public SelectFrom<NTNoteGroups>.Where<NTNoteGroups.noteid.IsEqual<SOShipment.noteID.FromCurrent>>.View NTNotesGroups;

        public SelectFrom<NTNote>.Where<NTNote.groupID.IsEqual<NTNoteGroups.groupID.FromCurrent>>.View NTNotes;
        #endregion


        #region event handlers
        public virtual void _(Events.RowInserted<SOShipment> e)
        {
            SOShipment Row = (SOShipment)e.Row;
            if (Row == null)
            {
                return;
            }

            if (Row.NoteID != null)
            {
                if (NTNotesGroups.Select().Count == 0)
                {
                    NTNoteGroups NewNoteGroup = new NTNoteGroups();
                    NewNoteGroup.GroupID = Guid.NewGuid();
                    NewNoteGroup.Noteid = Row.NoteID;
                    NTNotesGroups.Insert(NewNoteGroup);
                }
            }
        }
        #endregion
    }
}